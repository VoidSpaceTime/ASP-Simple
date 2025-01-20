using CommonsDomain.Entities;
using CommonsDomain.Models;

namespace PostServiceDomain.Entity
{
    public record Post : AggregateRootEntity
    {
        public Post() { } // 无参数构造函数
        public Post(string title, string context, Guid userId)
        {
            Title = title;
            Context = context;
            UserId = userId;
            Status = (int)PublicationStatusEnum.Wait;
        }

        public string Title { get; set; }
        public string Context { get; set; }


        public Guid UserId { get; init; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int Status { get; set; }
        public List<Category> Categorys { get; set; } = new List<Category>();
        //public List<Tag> Tags { get; set; } = new List<Tag>();

    }
}
