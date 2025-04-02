﻿using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System.Linq.Expressions;

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
        /// 根据ID搜索帖子
        public async Task<Post> GetAllPostByIdAsync(Guid Id)
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
        public async Task<List<Post>> GetPostAllListByNameAsync(string name, List<PublicationStatusEnum> status, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)));
        }
        public async Task<(List<Post>, int)> GetPostListByNameAsync(string name, List<PublicationStatusEnum> status, int pageIndex, int pageSize, Expression<Func<Post, object>> orderbyWhere, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)), pageIndex, pageSize, orderbyWhere);
        }


        /// <summary>
        /// 根据用户搜索帖子列表
        /// </summary>
        /// <param name="user"></param>
        /// <param name="status"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetPostListByUserAsync(Guid userId, List<PublicationStatusEnum> status, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.UserId == userId && o.IsDeleted != isDeleted && (status.Count == 0 || status.Contains(o.Status)));
        }

        /// <summary>
        /// 根据帖子搜索评论列表
        public async Task<List<Comment>> GetCommentListByPostAsync(Guid postId, PublicationStatusEnum status = PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPostId == postId && o.IsDeleted != isDeleted && o.Status == status);
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

        /// 评论

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
        /// 创建评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task CreateCommentAsync(Comment comment)
        {
            await repositoryComent.AddAsync(comment);
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task HardDeletedCommentAsync(Comment comment)
        {
            await repositoryComent.HardDeleteAsync(comment);
        }
    }
}
