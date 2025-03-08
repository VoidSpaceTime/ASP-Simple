using DbConfigurationProvider.EntityConfigurations;
using JWT;

namespace DbConfigurationProvider
{
    // 配置数据 KV 类型
    public record EntityConfigurationSettings(string Key, string? Value);

    public class EntityConfigurationOptions
    {
        public string? ASPSimpleDB { get; set; }
        public JWTOptions? JWTOptions { get; set; }
        public string? RedisConnection { get; set; }
        public string? MinioEndpoint { get; set; }
        public RabbitMQOptions? RabbitMqConnection { get; set; }
        public string? ElasticSearchConnection { get; set; }
        public string? CorsConifg { get; set; }
    }
}
