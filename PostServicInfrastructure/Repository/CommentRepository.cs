using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Repository
{
    public class CommentRepository<T> : BaseRepository<Comment>
    {
        public CommentRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
