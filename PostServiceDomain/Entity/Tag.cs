namespace PostServiceDomain.Entity
{
    public record Tag
    {
        public Tag() { } // 无参数构造函数
        public long Id { get; set; }
        public required string Name { get; set; }
        public Guid OwnerPostId { get; set; }
        public static Tag Create(string name, Guid ownerPostId)
        {
            return new Tag()
            {
                Name = name,
                OwnerPostId = ownerPostId,
            };
        }
    }
}
