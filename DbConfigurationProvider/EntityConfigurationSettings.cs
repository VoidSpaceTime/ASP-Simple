namespace DbConfigurationProvider
{
    // 配置数据 KV 类型
    public record EntityConfigurationSettings(string Key, string? Value);

    public class EntityConfigurationOptions
    {
        public required string ASPSimpleDB { get; set; }

    }
}
