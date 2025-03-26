using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigurationProvider.EntityConfigurations
{
    public class RabbitMQOptions
    {
        public required string HostName { get; set; }
        public required string ExchangeName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
