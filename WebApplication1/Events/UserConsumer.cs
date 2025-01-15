
using IdentityServiceDomain;
using IdentityServiceDomain.Interface;
using MassTransit;

namespace WebApplication1.Events
{
    public class UserConsumer : IConsumer<string>
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;

        public UserConsumer(IIdRepository repository, IdDomainService idService)
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
