namespace PostWebApi.DTO
{
    public class CommentResponse
    {
        public string Content { get; set; }
        public string UserId { get; init; }
        public string PostId { get; set; }
        public string Status { get; set; }
    }
}
