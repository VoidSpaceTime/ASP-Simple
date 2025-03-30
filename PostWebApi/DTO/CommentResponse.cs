namespace PostWebApi.DTO
{
    public record CommentResponse(string Content, string UserId, string PostId, string? ReplyUserId, string? ReplyCommentId, DateTime CraetDateTime);

}
