using CommonsDomain.Entities;
using CommonsDomain.Models;

namespace PostServiceDomain.Entity
{
    public record Post : AggregateRootEntity
    {
        public Post()
        {
            Title = string.Empty;
            Content = string.Empty;
            Comments = new List<Comment>();
            CoverImageUrl = new Uri("about:blank");
            Files = new List<Uri>();
        } // 无参数构造函数

        public string Title { get; set; } // 标题
        public string Content { get; set; } // 文本内容
        public Guid UserId { get; init; } // 用户ID
        public List<Guid> CommentsId { get; set; } = new List<Guid>();// 评论ID
        public virtual ICollection<Comment> Comments { get; set; } //评论级联 需要懒加载 ** 聚合根之间 使用ID进行关联 , 不应该直接引用对象
        public PublicationStatusEnum Status { get; set; } // 状态码
        public List<string> Categories { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>(); // 标签列表
        public Uri CoverImageUrl { get; set; } // 封面链接
        public List<Uri> Files { get; set; } // 文件列表

        public bool IsVideo = false; // 是否为视频

        public static Post Create(string title, string content, Guid userId, List<string> categories, List<string> tags, Uri coverImageUrl, List<Uri> files, bool isVideo = false)
        {
            return new Post()
            {
                Title = title,
                Content = content,
                UserId = userId,
                Status = PublicationStatusEnum.Wait,
                Categories = categories,
                Tags = tags,
                CoverImageUrl = coverImageUrl,
                Files = files,
                IsVideo = isVideo,
                Comments = new List<Comment>(),
            };
        }
        public Post AddComment(Comment comment)
        {
            this.Comments.Add(comment);
            CommentsId.Add(comment.Id);
            return this;
        }
        //public Post DeleteComment(Comment comment)
        //{
        //    this.Comments.Remove(comment);
        //    return this;
        //}
        public Post UpdateContent(string content)
        {
            this.Content = content;
            return this;
        }
        public Post UpdateTitle(string title)
        {
            this.Title = title;
            return this;
        }
        public Post UpdateStatus(PublicationStatusEnum status)
        {
            this.Status = status;
            return this;
        }
        public Post UpdateStatusPass()
        {
            return UpdateStatus(PublicationStatusEnum.Pass);
        }
        public Post UpdateStatusWait()
        {
            return UpdateStatus(PublicationStatusEnum.Wait);
        }
        public Post UpdateStatusFail()
        {
            return UpdateStatus(PublicationStatusEnum.Fail);
        }
        public PublicationStatusEnum GetStatus() { return this.Status; }


        /*
         基础信息
        Summary/Excerpt (string) - 文章摘要/简介
        Slug (string) - URL友好的文章别名
        SEO 相关
        MetaTitle (string) - SEO标题（可与标题不同）
        MetaDescription (string) - SEO描述
        Keywords (string/List<string>) - 关键词列表
        内容呈现
        ReadTime (int) - 阅读时间（分钟）
        ContentType (enum) - 内容类型（Markdown/HTML/富文本等）
        Format (enum) - 文章形式（标准/画廊/视频/音频等）
        交互与统计
        ViewCount (int) - 阅读数
        LikeCount (int) - 点赞数
        ShareCount (int) - 分享数
        FeaturedOrder (int?) - 推荐顺序（为空表示非推荐文章）
        权限与关联
        Visibility (enum) - 可见性（公开/私有/密码保护）
        Password (string) - 访问密码（当可见性为密码保护时使用）
        AuthorInfo (Author) - 作者信息（扩展UserID）
        Tags (List<Tag>) - 标签列表（与Categories区分）
        系统与维护
        RevisionHistory (List<Revision>) - 修订历史
        StatusMessage (string) - 状态说明（如被拒原因）
         */
    }
}
