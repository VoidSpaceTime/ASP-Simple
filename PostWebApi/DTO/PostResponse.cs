using PostServiceDomain.Entity;

namespace PostWebApi.DTO
{
    public record PostResponse
    {
    
        public PostResponse(string title, string content, Guid userId)
        {
            Title = title;
            Content = content;
            UserId = userId;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; init; }
        //public List<CommentResponse>? Comments { get; set; }
        public List<string> Categorys { get; set; } = new List<string> { };
        //public List<string> Tags { get; set; } = new List<string> { "无" };
    }
}
