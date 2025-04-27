using PostServiceDomain.Entity;
using PostServiceDomain.Interface;

namespace PostServicInfrastructure.Repository
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
