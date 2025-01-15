using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Repository
{
    public class PostRepository<T> : BaseRepository<Post>

    {
        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
