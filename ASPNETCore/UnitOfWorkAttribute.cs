using Microsoft.EntityFrameworkCore;

namespace ASPNETCore
{
    // 指定该特性可以应用于类和方法，且不允许多次应用，允许继承
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UnitOfWorkAttribute : Attribute
    {
        // 用于存储DbContext类型的数组
        public Type[] DbContextTypes { get; init; }

        // 构造函数，接受多个DbContext类型作为参数
        public UnitOfWorkAttribute(params Type[] dbContextTypes)
        {
            this.DbContextTypes = dbContextTypes;
            // 遍历每个传入的类型，确保它们都继承自DbContext
            foreach (var type in dbContextTypes)
            {
                if (!typeof(DbContext).IsAssignableFrom(type))
                {
                    // 如果类型没有继承自DbContext，则抛出异常
                    throw new ArgumentException($"{type} must inherit from DbContext");
                }
            }
        }
    }
}
