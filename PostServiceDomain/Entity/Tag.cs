namespace PostServiceDomain.Entity
{
    public record Tag
    {
        public Tag() { } // 无参数构造函数
        public long Id { get; set; }
        public required string Name { get; set; }
        public List<Guid> Posts { get; set; } = new List<Guid>();
    }
}
