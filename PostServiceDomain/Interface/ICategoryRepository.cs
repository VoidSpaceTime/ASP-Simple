using PostServiceDomain.Entity;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServiceDomain.Interface
{
    interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
