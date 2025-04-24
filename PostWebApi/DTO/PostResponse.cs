using PostServiceDomain.Entity;

namespace PostWebApi.DTO
{
    public record PostResponse(Guid Id,string Titile,string Content,Guid UserId,List<string> Categories,List<string> Tags);

}
