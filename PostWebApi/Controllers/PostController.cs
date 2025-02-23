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
using PostWebApi.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
            var result = posts.Select(o => new PostResponse(o.Title, o.Context, o.UserId)).ToList();
            return await Task.FromResult(result);
        }
        private async Task<PostResponse> ConvertRespositoryPost(Post post)
        {
            var result = new PostResponse(post.Title, post.Context, post.UserId);
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
        public async Task<JsonResponseL> GetPostAllList(int status)
        {
            var res = new JsonResponseL();
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true && o.Status == status);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<JsonResponseL> GetPostListByUser(UserResponse userResponse, int status)
        {
            var res = new JsonResponseL();
            var posts = await postService.GetPostListByUserAsync(userResponse.Id, status);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpGet]
        public async Task<JsonResponseL> GetPostListByUser()
        {
            var res = new JsonResponseL();
            var userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var posts = await postService.GetPostListByUserAsync(userId);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<JsonResponseL> GetPostListByTitle(string title)
        {
            var res = new JsonResponseL();
            var posts = await postService.GetPostListByNameAsync(title);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<JsonResponseL> CreatePostByUser(PostSubmitRequest postSubmitRequest)
        {
            var res = new JsonResponseL();
            var result = Guid.TryParse(postSubmitRequest.UserId, out Guid userId);
            //var response = await requestClient.GetResponse<User>(new UserIdResponse(guid), timeout: RequestTimeout.After(s: 30));
            //var user = response.Message;

            if (result != true)
            {
                return res.Fail("创建失败");
            }
            var post = new Post(postSubmitRequest.Title, postSubmitRequest.Content, userId);
            if (postSubmitRequest.Categorys.Count >= 1)
            {
                post.Categorys.AddRange(postSubmitRequest.Categorys.Select(o => new Category() { Name = o, OwnerPost = post }).ToList());
            }
            //var tags = postResponse.Tags;

            var r = await postService.CreatePostAsync(post);
            if (r == false)
            {
                return res.Fail("创建失败");
            }
            return res.Succeed();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResponseL> ModifyPostStatus(PostRequest postRequest)
        {
            var res = new JsonResponseL();
            var post = await postRepository.FindAsync(Guid.Parse(postRequest.PostId));
            post.Status = postRequest.Status;
            var result = await postRepository.UpdateAsync(post);
            if (result)
            {
                return res.Succeed();
            }
            return res.Fail("处理错误");

        }
    }
}
