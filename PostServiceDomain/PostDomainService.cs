using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System.Linq.Expressions;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServiceDomain
{
    public class PostDomainService
    {
        private readonly IPostRepository repositoryPost;

        public PostDomainService(IPostRepository repositoryPost)
        {
            this.repositoryPost = repositoryPost;
        }

        /// 根据ID搜索帖子
        public async Task<Post> GetPostByIdAsync(Guid Id)
        {
            return await repositoryPost.QueryAsync(o => o.Id == Id);
        }
        public async Task<List<Post>> QueryPostListByUserAsync(Guid userId, List<PublicationStatusEnum> status, bool IsSoftDelete = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != true && (status.Count == 0 || status.Contains(o.Status)) && o.IsDeleted == IsSoftDelete);
        }
        public async Task<(List<Post>, int)> QueryPostListByUserAsync(Guid userId, List<PublicationStatusEnum> status, int pageIndex, int pageSize,
            Expression<Func<Post, object>> orderbyWhere, bool isAscending = true, bool IsSoftDelete = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != true && (status.Count == 0 || status.Contains(o.Status)) && o.IsDeleted == IsSoftDelete,
                pageIndex, pageSize, orderbyWhere, isAscending);
        }



        /// <summary>
        /// 创建帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task CreatePostAsync(Post post)
        {
            post.Status = PublicationStatusEnum.Wait;
            await repositoryPost.AddAsync(post);
        }

        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task SoftDeletedPostAsync(Post post)
        {
            post.Status = PublicationStatusEnum.Fail;
            post.SoftDelete();
            await repositoryPost.UpdateAsync(post);
        }

        public async Task HardDeletedPostAsync(Post post)
        {
            post.SoftDelete();
            await repositoryPost.HardDeleteAsync(post);
        }

        /// <summary>
        /// 修改帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task ModifyPostAsync(Post post)
        {
            await repositoryPost.UpdateAsync(post);
        }
    }
}
