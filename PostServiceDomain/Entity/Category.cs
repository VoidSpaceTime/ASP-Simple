namespace PostServiceDomain.Entity
{
    public record Category
    {
        public Category()
        {
            OwnerPost = new Post(); // 初始化 OwnerPost
        }
        public long Id { get; set; }
        public required string Name { get; set; }
        public Post OwnerPost { get; set; }
    }
}
