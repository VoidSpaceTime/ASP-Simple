
using CommonsDomain.DTO.Identity;
using CommonsDomain.Entities;
using IdentityServiceDomain;
using IdentityServiceDomain.Interface;
using MassTransit;

namespace WebApplication1.Events
{
    /// <summary>
    /// Consumes user ID responses.
    /// </summary>
    public class UserConsumer : IConsumer<UserIdResponse>
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserConsumer"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="idService">The ID service.</param>
        public UserConsumer(IIdRepository repository, IdDomainService idService)
        {
            this.repository = repository;
            this.idService = idService;
        }

        /// <inheritdoc/>
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
