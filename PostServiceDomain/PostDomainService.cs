using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System.Linq.Expressions;

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

        /// <summary>
        /// 根据名称搜索帖子列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Post>> QueryPostListByNameAsync(string name, List<PublicationStatusEnum> status, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)));
        }

        public async Task<List<Post>> QueryPostListByNameAsync(string name, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted);
        }

        public async Task<(List<Post>, int)> QueryPostListByNameAsync(string name, List<PublicationStatusEnum> status, int pageIndex, int pageSize, Expression<Func<Post, object>> orderbyWhere, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)), pageIndex, pageSize, orderbyWhere);
        }

        /// <summary>
        /// 根据用户搜索帖子列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Post>> QueryPostListByUserAsync(Guid userId, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != isDeleted);
        }

        public async Task<(List<Post>, int)> QueryPostListByUserAsync(Guid userId, List<PublicationStatusEnum> status, int pageIndex, int pageSize, Expression<Func<Post, object>> orderbyWhere, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)), pageIndex, pageSize, orderbyWhere);
        }

        public async Task<List<Post>> QueryPostListByUserAsync(Guid userId, List<PublicationStatusEnum> status, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)));
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
