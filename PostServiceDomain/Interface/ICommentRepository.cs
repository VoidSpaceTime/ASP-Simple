using CommonsDomain.Interface;
using PostServiceDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServiceDomain.Interface
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
