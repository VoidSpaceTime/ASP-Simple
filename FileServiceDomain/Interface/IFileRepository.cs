using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileServiceDomain.Interface.IBaseRepository;

namespace FileServiceDomain.Interface
{
    interface IFileRepository : IBaseRepository<File>
    {


    }
}
