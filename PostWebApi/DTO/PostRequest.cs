using PostServiceDomain;

namespace PostWebApi.DTO
{
    public record PostRequest(string PostId, PublicationStatusEnum Status);

}
