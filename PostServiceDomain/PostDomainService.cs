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
        public async Task<Post> SearchPostByNameAsync(string name, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && o.Status == status);
        }
        public async Task<List<Post>> SearchPostListByNameAsync(string name, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && o.IsDeleted != isDeleted && o.Status == status);
        }
        public async Task<List<Post>> SearchPostListByUserAsync(User user, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryPost.QueryListAsync(o => o.OwnerUser.Id == user.Id && o.IsDeleted != isDeleted && o.Status == status);
        }
        public async Task<List<Comment>> SearchCommentListByPostAsync(Post post, int status = (int)PublicationStatusEnum.Pass, bool isDeleted = false)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPost.Id == post.Id && o.IsDeleted != isDeleted && o.Status == status);
        }
        public async Task<bool> CreatePostAsync(Post post)
        {
            post.Status = (int)PublicationStatusEnum.Wait;
            var result = await repositoryPost.AddAsync(post);
            return result;
        }
        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            comment.Status = (int)PublicationStatusEnum.Pass;
            var result = await repositoryComent.AddAsync(comment);
            return result;
        }
        public async Task<bool> DeletedPostAsync(Post post)
        {
            post.Status = (int)PublicationStatusEnum.Fail;
            post.SoftDelete();
            return await repositoryPost.UpdateAsync(post);
        }
        public async Task<bool> DeletedCommentAsync(Comment comment)
        {
            comment.Status = (int)PublicationStatusEnum.Fail;
            return await repositoryComent.DeleteAsync(comment);
        }
        public async Task<bool> ModifyPostAsync(Post post)
        {
            return await repositoryPost.UpdateAsync(post);
        }
    }
}
