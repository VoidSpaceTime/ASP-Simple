namespace FileServiceWebAPI.DTO
{

    public record FileExistsResponse(bool IsExists, Uri? Url);
}
