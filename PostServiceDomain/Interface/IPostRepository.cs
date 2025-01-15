using PostServiceDomain.Entity;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServiceDomain.Interface
{
    public interface IPostRepository : IBaseRepository<Post>
    {
    }
}
