using JWT;
using Microsoft.Extensions.Options;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
        /// 根据名称搜索帖子
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<Post> SearchPostByNameAsync(string name, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 根据名称搜索帖子列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Post>> SearchPostListByNameAsync(string name, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
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
        public async Task<List<Post>> SearchPostListByUserAsync(Guid userId, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.OwnerUser.Id == userId && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 根据用户搜索评论列表
        /// </summary>
        /// <param name="post"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Comment>> SearchCommentListByPostAsync(Guid postId, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPost.Id == postId && o.IsDeleted != isDeleted && o.Status == status);
        }
        /// <summary>
        /// 创建帖子
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> CreatePostAsync(Post post)
        {
            post.Status = (int)PublicationStatusEnum.Wait;
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
            comment.Status = (int)PublicationStatusEnum.Pass;
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
            post.Status = (int)PublicationStatusEnum.Fail;
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
            comment.Status = (int)PublicationStatusEnum.Fail;
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
