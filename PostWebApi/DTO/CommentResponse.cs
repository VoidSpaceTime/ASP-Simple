namespace PostWebApi.DTO
{
    public record CommentResponse (string Content, string UserId, string PostId, DateTime CraetDateTime);

}
