using CommonInitializer;
using IdentityService.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace IdentityService.WebAPI;
/// <summary>
/// 还可以通过实现 Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<TContext> 
/// 接口来告知工具如何创建 DbContext：如果在与派生的 DbContext 相同的项目中或在应用程序的启动项目中找到实现此接口的类，
/// 则这些工具会绕过创建 DbContext 的其他方式，转而使用设计时工厂。
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdDbContext>
{
    public IdDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = DbContextOptionsBuilderFactory.Create<IdDbContext>();
        return new IdDbContext(optionsBuilder.Options);
    }
}