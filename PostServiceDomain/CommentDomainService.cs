using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostServiceDomain
{
    class CommentDomainService
    {
        private readonly ICommentRepository repositoryComent;

        public CommentDomainService(ICommentRepository repositoryComent)
        {
            this.repositoryComent = repositoryComent;
        }

        /// <summary>
        /// 根据帖子搜索评论列表
        public async Task<List<Comment>> GetCommentListByPostAsync(Guid postId, bool isDeleted = false)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPostId == postId && o.IsDeleted != isDeleted);
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
