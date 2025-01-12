namespace PostWebApi.DTO
{
    public class CommentResponse
    {
        public string Context { get; set; }
        public Guid UserId { get; init; }
        public Guid PostId { get; set; }
        public string Status { get; set; }
    }
}
