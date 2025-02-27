using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceInfrastructure.Services
{
    class MinioStorageOptions
    {
        required public string Endpoint { get; set; }
        required public string AccessKey { get; set; }
        required public string SecretKey { get; set; }
    }
}
