namespace PostServiceDomain.Entity
{
    public record Category
    {
        public Category()
        {
        }
        public long Id { get; set; }
        public required string Name { get; set; }
        public Guid OwnerPostId { get; set; }
    }

}
