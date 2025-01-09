using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServiceDomain.Interface
{
    public interface IHasCreationTime
    {
        public DateTime CreationTime { get; }
    }
}
