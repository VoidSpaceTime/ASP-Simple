namespace PostWebApi.DTO
{
    public record PostQueryRequest(
        Guid? UserId,
        string? Title,
        List<string>? Tags,
        List<string>? Categories,
        int PageIndex,
        int PageSize,
        string OrderBy);

    public enum PostQueryEnum
    {
        ByUser,
        ByTitle,
        ByTags,
        ByCategories
    }
    public enum PostQueryOrderbyEnum
    {
        ByCreateTime,
    }



}
