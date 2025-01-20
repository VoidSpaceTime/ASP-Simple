namespace PostWebApi.DTO
{
    public class CommentRequest
    {
        public string? UserId { get; init; }
        public string? PostId { get; set; }
    }
}
