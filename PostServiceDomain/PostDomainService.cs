using JWT;
using Microsoft.Extensions.Options;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostServiceDomain
{
    public class PostDomainService
    {
        private readonly IOptions<JWTOptions> optJWT;
        private readonly ITokenService tokenService;
        private readonly IPostRepository repositoryPost;
        private readonly ICommentRepository repositoryComent;

        public PostDomainService(IOptions<JWTOptions> optJWT, ITokenService tokenService, IPostRepository repositoryPost, ICommentRepository repositoryComent)
        {
            this.optJWT = optJWT;
            this.tokenService = tokenService;
            this.repositoryPost = repositoryPost;
            this.repositoryComent = repositoryComent;
        }
        public async Task<Post> SearchPostByNameAsync(string name, User user)
        {
            return await repositoryPost.QueryAsync(o => o.Title.Contains(name) && user.Id == o.OwnerUser.Id);
        }
        public async Task<List<Post>> SearchPostListByNameAsync(string name, User user)
        {
            return await repositoryPost.QueryListAsync(o => o.Title.Contains(name) && user.Id == o.Id);
        }
        public async Task<List<Comment>> SearchCommentListByNameAsync(string name, Post post)
        {
            return await repositoryComent.QueryListAsync(o => o.OwnerPost.Id == post.Id);
        }
        public async Task<bool> CreatePostAsync(Post post, User user)
        {
            post.Status = (int)PublicationStatusEnum.Wait;
            var result = await repositoryPost.AddAsync(post);
            return result;
        }

    }
}
