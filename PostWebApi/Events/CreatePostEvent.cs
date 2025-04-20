using CommonsDomain.ETO;
using MassTransit;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;

namespace PostWebApi.Events
{
    public class CreatePostEvent : IConsumer<CreatePostEto>
    {
        private readonly TagDomainService tagDomainService;
        private readonly CategoryDomainService categoryDomainService;

        public CreatePostEvent(TagDomainService tagDomainService, CategoryDomainService categoryDomainService)
        {
            this.tagDomainService = tagDomainService;
            this.categoryDomainService = categoryDomainService;
        }

        public async Task Consume(ConsumeContext<CreatePostEto> context)
        {
            await tagDomainService.AddTag(context.Message.Tags, context.Message.Id);
            await categoryDomainService.AddCategoryAsync(context.Message.Categories, context.Message.Id);
        }
    }
}
