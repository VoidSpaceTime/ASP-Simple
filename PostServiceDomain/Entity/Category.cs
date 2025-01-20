namespace PostServiceDomain.Entity
{
    public record Category
    {
        public Category() { } // 无参数构造函数
        public long Id { get; set; }
        public required string Name { get; set; }
        public Post OwnerPost { get; set; }
    }
}
