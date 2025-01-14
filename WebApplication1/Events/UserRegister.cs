
using IdentityServiceDomain.Interface;
using IdentityServiceDomain;
using MassTransit;
using System.Text.Json;
using CommonsDomain.DTO.Identity;

namespace WebApplication1.Events
{
    public class UserRegister : IConsumer<UserResponse>
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;

        public UserRegister(IIdRepository repository, IdDomainService idService)
        {
            this.repository = repository;
            this.idService = idService;
        }

        public Task Consume(ConsumeContext<UserResponse> context)
        {
            var user = repository.FindByIdAsync(context.Message.Id);
            if (user != null)
            {
                context.RespondAsync(user);
            }
            return Task.CompletedTask;
        }
    }
}
