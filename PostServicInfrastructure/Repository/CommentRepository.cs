using PostServiceDomain.Entity;
using PostServiceDomain.Interface;

namespace PostServicInfrastructure.Repository
{
    public class CommentRepository : BaseRepository<Comment> , ICommentRepository
    {
        public CommentRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
