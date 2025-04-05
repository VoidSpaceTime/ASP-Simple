namespace PostServiceDomain.Entity
{
    public record Category
    {
        public Category()
        {
        }
        public long Id { get; set; }
        public required string Name { get; set; }
        public List<Guid> OwnerPostId { get; set; } = new List<Guid>();
        public static Category Create(string name)
        {
            return new Category()
            {
                Name = name,
            };
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public Category AddPost(Guid postId)
        {
            if (!OwnerPostId.Contains(postId))
            {
                OwnerPostId.Add(postId);
            }
            return this;
        }
        public Category RemovePost(Guid postId)
        {
            if (OwnerPostId.Contains(postId))
            {
                OwnerPostId.Remove(postId);
            }
            return this;
        }
    }
}
