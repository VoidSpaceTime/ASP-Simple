namespace CommonsDomain.DTO.Identity
{
    public record UserResponse(Guid Id, string PhoneNumber, DateTime CreationTime);
    public record UserIdResponse(Guid Id);
}
