
using IdentityServiceDomain.Interface;
using IdentityServiceDomain;
using MassTransit;
using System.Text.Json;
using CommonsDomain.DTO.Identity;

namespace WebApplication1.Events
{
    public class UserRegister : IConsumer<string>
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;

        public UserRegister(IIdRepository repository, IdDomainService idService)
        {
            this.repository = repository;
            this.idService = idService;
        }

        public async Task Consume(ConsumeContext<string> context)
        {
            if (Guid.TryParse(context.Message, out Guid userId))
            {
                var user = await repository.FindByIdAsync(userId);
                if (user != null)
                {
                    await context.RespondAsync(user);
                }
            }
        }
    }
}
