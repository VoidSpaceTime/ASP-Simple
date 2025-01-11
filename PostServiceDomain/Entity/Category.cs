using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostServiceDomain.Entity
{
    public record Category
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
