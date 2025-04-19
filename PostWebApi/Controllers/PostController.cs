using ASPNETCore;
using CommonsDomain.DTO;
using CommonsDomain.DTO.Identity;
using CommonsDomain.Entities;
using CommonsDomain.Enum;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostServicInfrastructure;
using PostWebApi.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UnitOfWork(typeof(PostDbContext))]
    //[Authorize(Roles = $"{nameof(RolesEnum.User)},{nameof(RolesEnum.Admin)}")]
    public class PostController : ControllerBase
    {
        private readonly PostDomainService postService;
        private readonly IPostRepository postRepository;
        private readonly IRequestClient<UserIdResponse> requestClient;

        public PostController(PostDomainService postService, IPostRepository postRepository, IRequestClient<UserIdResponse> requestClient)
        {
            this.postService = postService;
            this.postRepository = postRepository;
            this.requestClient = requestClient;
        }
        private async Task<List<PostResponse>> ConvertRespositoryPost(List<Post> posts)
        {
            var result = posts.Select(o => new PostResponse(o.Title, o.Content, o.UserId)).ToList();
            return await Task.FromResult(result);
        }
        private async Task<PostResponse> ConvertRespositoryPost(Post post)
        {
            var result = new PostResponse(post.Title, post.Content, post.UserId);
            return await Task.FromResult(result);
        }
        [HttpGet]
        public async Task<JsonResponseL> GetPostAllList()
        {
            var res = new JsonResponseL();
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<JsonResponseL> GetPostAllList(PublicationStatusEnum status)
        {
            var res = new JsonResponseL();
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true && o.Status == status);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<JsonResponseL> GetPostListByUser(UserResponse userResponse)
        {
            var res = new JsonResponseL();
            var posts = await postService.QueryPostListByUserAsync(userResponse.Id);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpGet]
        public async Task<JsonResponseL> GetPostListByUser()
        {
            var res = new JsonResponseL();
            var userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var posts = await postService.QueryPostListByUserAsync(userId);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<JsonResponseL> GetPostListByTitle(string title)
        {
            var res = new JsonResponseL();
            var posts = await postService.QueryPostListByNameAsync(title);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<JsonResponseL> CreatePostByUser(PostSubmitRequest postSubmitRequest)
        {
            var res = new JsonResponseL();
            var result = Guid.TryParse(postSubmitRequest.UserId, out Guid userId);

            if (result != true)
            {
                return res.Fail("创建失败");
            }
            var post = Post.Create(postSubmitRequest.Title, postSubmitRequest.Content, userId, postSubmitRequest.Categories, postSubmitRequest.Tags, postSubmitRequest.ConvertUri, postSubmitRequest.Files);
            //if (postSubmitRequest.Categories.Count >= 1)
            //{
            //    post.Categories.AddRange(postSubmitRequest.Categories);
            //    post.Tags.AddRange(postSubmitRequest.Tags);
            //}
            //var tags = postResponse.Tags;

            await postService.CreatePostAsync(post);
            return res.Succeed(post.Id);

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResponseL> ModifyPostStatus(PostRequest postRequest)
        {
            var res = new JsonResponseL();
            var post = await postRepository.FindAsync(Guid.Parse(postRequest.PostId));
            post.Status = postRequest.Status;
            await postRepository.UpdateAsync(post);
            return res.Succeed();
        }
    }
}
