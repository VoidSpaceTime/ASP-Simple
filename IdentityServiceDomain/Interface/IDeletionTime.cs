using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServiceDomain.Interface
{
    internal interface IDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
