using PostServiceDomain.Entity;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServiceDomain.Interface
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
