using PostServiceDomain.Entity;
using PostServiceDomain.Interface;

namespace PostServiceDomain
{
    public class PostDomainService
    {
        private readonly IPostRepository repositoryPost;
        private readonly ICommentRepository repositoryComent;

        public PostDomainService(IPostRepository repositoryPost, ICommentRepository repositoryComent)
        {
            this.repositoryPost = repositoryPost;
            this.repositoryComent = repositoryComent;
        }
        /// <summary>
        /// 根据名称搜索全部帖子
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>      
        public async Task<Post> GetAllPostByNameAsync(string name)
        {
            return await repositoryPost.QueryAsync(o => o.Title.Contains(name));
        }
        /// <summary>
        /// 根据名称搜索帖子
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<Post> GetPostByNameAsync(string name, PublicationStatusEnum status = PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && o.Status == status);
        }
        public async Task<Post> GetAllPostByIdAsync(Guid Id)
        {
            return await repositoryPost.QueryAsync(o => o.Id == Id);
        }
        public async Task<Post> GetPostByIdAsync(Guid Id, PublicationStatusEnum status = PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryAsync(o => o.Id == Id && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 根据名称搜索帖子列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetPostListByNameAsync(string name, PublicationStatusEnum status = PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 根据用户搜索帖子列表
        /// </summary>
        /// <param name="user"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetPostListByUserAsync(Guid userId, PublicationStatusEnum status = PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 根据帖子返回所有评论列表
        /// </summary>
        /// <param name="post"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Comment>> GetAllCommentListByPostAsync(Guid postId)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPostId == postId);
        }
        /// <summary>
        /// 根据帖子搜索评论列表
        /// </summary>
        /// <param name="post"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Comment>> GetCommentListByPostAsync(Guid postId, PublicationStatusEnum status = PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPostId == postId && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 创建帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> CreatePostAsync(Post post)
        {
            post.Status = PublicationStatusEnum.Wait;
            var result = await repositoryPost.AddAsync(post);
            return result;
        }
        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            comment.Status = PublicationStatusEnum.Pass;
            var result = await repositoryComent.AddAsync(comment);
            return result;
        }
        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> DeletedPostAsync(Post post)
        {
            post.Status = PublicationStatusEnum.Fail;
            post.SoftDelete();
            return await repositoryPost.UpdateAsync(post);
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<bool> DeletedCommentAsync(Comment comment)
        {
            comment.Status = PublicationStatusEnum.Fail;
            return await repositoryComent.DeleteAsync(comment);
        }
        /// <summary>
        /// 修改帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> ModifyPostAsync(Post post)
        {
            return await repositoryPost.UpdateAsync(post);
        }
    }
}
