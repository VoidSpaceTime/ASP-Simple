using PostServiceDomain.Entity;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServiceDomain.Interface
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
