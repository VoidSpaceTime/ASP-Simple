using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigurationProvider.EntityConfigurations
{
    public record RabbitMQOptions(string HostName, string ExchangeName, string UserName, string Password);

}
