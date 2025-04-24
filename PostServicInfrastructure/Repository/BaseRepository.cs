using CommonsDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServicInfrastructure.Repository
{

    public class BaseRepository<T> : IBaseRepository<T> where T : AggregateRootEntity
    {
        private readonly PostDbContext dbContext;

        public BaseRepository(PostDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 异步

        /// <summary>
        /// 查找 - 通过ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(Guid id)
        {
            return await dbContext.Set<T>().FirstAsync(o => o.IsDeleted == false && o.Id == id);
        }
        /// <summary>
        /// 查询实体对象 通过条件
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<T> QueryAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await dbContext.Set<T>().Where(whereLambda).Where(o => o.IsDeleted == false).FirstAsync();
        }


        /// <summary>
        /// 查询列表 通过条件
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryListAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await dbContext.Set<T>().Where(a => a.IsDeleted == false).Where(whereLambda).ToListAsync();
        }


        /// <summary>
        /// 查询列表 通过条件 包括删除数据 
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryListIncludeDeleteAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await dbContext.Set<T>().Where(whereLambda).ToListAsync();
        }
        /// <summary>
        /// 查询列表分页 - 通过条件
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderbyWhere"></param>
        /// <returns></returns>
        public async Task<(List<T>, int)> QueryListAsync(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, Expression<Func<T, object>> orderbyWhere, bool isAscending = true)
        {
            int count = await dbContext.Set<T>()
                   .Where(whereLambda)
                   .Where(a => a.IsDeleted == false)
                   .CountAsync();

            var list = await dbContext.Set<T>()
                   .Where(whereLambda)
                   .Where(a => a.IsDeleted == false)
                   .OrderBy(orderbyWhere)
                   .Skip((pageIndex - 1) * pageSize)
                   .Take(pageSize)
                   .ToListAsync();

            return (list, count);
        }
        // 因使用事务一致性,不在这里进行savechange操作
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await dbContext.AddAsync(entity);
            //var result = await dbContext.SaveChangesAsync();
            //return result > 0;
            return;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            dbContext.Update(entity);
            //var result = await dbContext.SaveChangesAsync();
            //return result > 0;
            await Task.CompletedTask;
            return;
        }
        /// <summary>
        /// 实体删除 (数据库删除)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task HardDeleteAsync(T entity)
        {
            dbContext.Remove(entity);
            //var result = await dbContext.SaveChangesAsync();
            //return result > 0;
            await Task.CompletedTask;
            return;
        }

        /// <summary>
        /// 条件删除 (数据库删除)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task HardDeleteByWhereAsync(Expression<Func<T, bool>> whereLambda)
        {
            List<T> list = await dbContext.Set<T>().Where(whereLambda).ToListAsync();
            dbContext.RemoveRange(list);
            //var result = await dbContext.SaveChangesAsync();
            //return result > 0;
            return;
        }
        #endregion

    }
}
