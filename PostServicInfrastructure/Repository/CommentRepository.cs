using PostServiceDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostServicInfrastructure.Repository
{
    public class CommentRepository<T> : BaseRepository<Comment>
    {
        public CommentRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}
