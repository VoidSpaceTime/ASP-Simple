using CommonsDomain.Entities;

namespace PostWebApi.DTO
{
    public record PostSubmitRequest(string Title, string Content, string UserId, Uri ConvertUri, List<Uri> Files, List<string> Tags, List<string> Categories);
}
