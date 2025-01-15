using PostServiceDomain.Entity;

namespace PostWebApi.DTO
{
    public class PostResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Id { get; set; }

        public string UeserId { get; init; }
        public List<CommentResponse> Comments { get; set; } = new List<CommentResponse>();
        public string Status { get; set; }
        public string Category { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
