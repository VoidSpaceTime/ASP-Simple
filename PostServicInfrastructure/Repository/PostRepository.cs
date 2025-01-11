using PostServiceDomain.Entity;
using System.Data;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServicInfrastructure.Repository
{
    public class PostRepository<T> : BaseRepository<Post>

    {
        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
