namespace PostWebApi.DTO
{
    public record PostQueryRequest(
        string? UserId,
        string? Title,
        string? Tag,
        string? Category,
        int PageIndex,
        int PageSize,
        string OrderBy);
}
