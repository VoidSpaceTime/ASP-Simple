using PostServiceDomain.Entity;
using PostServiceDomain.Interface;

namespace PostServicInfrastructure.Repository
{
    public class PostRepository : BaseRepository<Post> , IPostRepository

    {
        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
