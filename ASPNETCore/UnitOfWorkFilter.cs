using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ASPNETCore
{
    class UnitOfWorkFilter : IAsyncActionFilter
    {
        private static UnitOfWorkAttribute? GetUoWAttr(ActionDescriptor actionDesc)
        {
            var caDesc = actionDesc as ControllerActionDescriptor;
            if (caDesc == null)
            {
                return null;
            }
            //try to get UnitOfWorkAttribute from controller,
            //if there is no UnitOfWorkAttribute on controller, 
            //try to get UnitOfWorkAttribute from action
            var uowAttr = caDesc.ControllerTypeInfo
                .GetCustomAttribute<UnitOfWorkAttribute>();
            if (uowAttr != null)
            {
                return uowAttr;
            }
            else
            {
                return caDesc.MethodInfo
                    .GetCustomAttribute<UnitOfWorkAttribute>();
            }
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var uowAttr = GetUoWAttr(context.ActionDescriptor);
            if (uowAttr == null)
            {
                await next();
                return;

            }

            // 使用TransactionScope来管理事务
            using TransactionScope txScope = new(TransactionScopeAsyncFlowOption.Enabled);
            // 创建一个DbContext列表，用于存储所有需要处理的DbContext实例
            List<DbContext> dbCtxs = new List<DbContext>();
            // 遍历UnitOfWorkAttribute中指定的所有DbContext类型
            foreach (var dbCtxType in uowAttr.DbContextTypes)
            {
                // 用HttpContext的RequestServices确保获取的是和请求相关的Scope实例
                var sp = context.HttpContext.RequestServices;
                // 获取指定类型的DbContext实例，并添加到列表中
                DbContext dbCtx = (DbContext)sp.GetRequiredService(dbCtxType);
                dbCtxs.Add(dbCtx);
            }
            // 执行下一个中间件或操作
            var result = await next();
            // 如果操作执行没有异常
            if (result.Exception == null)
            {
                // 遍历所有的DbContext实例，保存更改
                foreach (var dbCtx in dbCtxs)
                {
                    await dbCtx.SaveChangesAsync();
                }
                // 提交事务
                txScope.Complete();
            }
        }
    }
}
