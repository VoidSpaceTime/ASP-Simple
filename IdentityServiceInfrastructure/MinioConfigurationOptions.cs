using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServiceInfrastructure
{
    public record MinioConfigurationOptions
    {
        public string? Uri { get; set; }
    }
}
