using CommonsDomain.Entities;

namespace PostWebApi.DTO
{
    public record PostSubmitRequest
    {
        public PostSubmitRequest(string title, string content, string userId)
        {
            Title = title;
            Content = content;
            UserId = userId;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; init; }
        public Uri ConvertUri { get; set; }
        public List<Uri> Files { get; set; } = new List<Uri> { };

        public List<string> Tags { get; set; } = new List<string> { };
        public List<string> Categorys { get; set; } = new List<string> { };
    }
}
