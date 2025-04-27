using MassTransit;
using PostServiceDomain.Entity;
using PostServiceDomain;
using CommonsDomain.ETO;

namespace PostWebApi.Events
{

/*    public class HardDeletePost : IConsumer<HardDeletePostEto>
    {
        private readonly TagDomainService tagDomainService;
        private readonly CategoryDomainService categoryDomainService;

        public HardDeletePost(TagDomainService tagDomainService, CategoryDomainService categoryDomainService)
        {
            this.tagDomainService = tagDomainService;
            this.categoryDomainService = categoryDomainService;
        }

        public async Task Consume(ConsumeContext<HardDeletePostEto> context)
        {
            await tagDomainService.HardDeleteAsync(context.Message.Id);
            await categoryDomainService.DeletePostAsync(context.Message.Categories, context.Message.Id);
        }
    }*/
}
