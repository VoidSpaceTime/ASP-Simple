namespace PostWebApi.DTO
{
    public record PostResponseBase
    {        //public List<CommentResponse>? Comments { get; set; }
        public List<string> Categorys { get; set; } = new List<string> { };
        public string Content { get; set; }
        public int IdxPage { get; set; }
        //public List<string> Tags { get; set; } = new List<string> { "无" };
        public int IdxSize { get; set; }

        public string Title { get; set; }
        public Guid UserId { get; init; }
    }
}