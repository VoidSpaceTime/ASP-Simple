using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsDomain.ETO
{
    public record CreatePostEto(Guid Id, string Title, List<string> Tags, List<string> Categories);
}
