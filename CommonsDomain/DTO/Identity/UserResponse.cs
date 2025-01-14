using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsDomain.DTO.Identity
{
    public record UserResponse(Guid Id, string PhoneNumber, DateTime CreationTime);
}
