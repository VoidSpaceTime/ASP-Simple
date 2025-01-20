
using CommonsDomain.DTO.Identity;
using CommonsDomain.Entities;
using IdentityServiceDomain;
using IdentityServiceDomain.Interface;
using MassTransit;

namespace WebApplication1.Events
{
    public class UserConsumer : IConsumer<UserIdResponse>
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;

        public UserConsumer(IIdRepository repository, IdDomainService idService)
        {
            this.repository = repository;
            this.idService = idService;
        }

        public async Task Consume(ConsumeContext<UserIdResponse> context)
        {

            var user = await repository.FindByIdAsync(context.Message.Id);
            if (user != null)
            {
                await context.RespondAsync<User>(user);
            }
        }

    }
}
