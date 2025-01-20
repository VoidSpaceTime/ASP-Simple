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
        public async Task<ActionResult<List<PostResponse>>> GetPostAllList()
        {
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true);
            return Ok(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<ActionResult<List<PostResponse>>> GetPostAllList(int status)
        {
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true && o.Status == status);
            return Ok(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<ActionResult<List<PostResponse>>> GetPostListByUser(UserResponse userResponse, int status)
        {
            var posts = await postService.GetPostListByUserAsync(userResponse.Id, status);
            return Ok(this.ConvertRespositoryPost(posts));
        }
        [HttpGet]
        public async Task<ActionResult<List<PostResponse>>> GetPostListByUser()
        {
            var userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var posts = await postService.GetPostListByUserAsync(userId);
            return Ok(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<ActionResult<List<PostResponse>>> GetPostListByTitle(string title)
        {
            var posts = await postService.GetPostListByNameAsync(title);
            return Ok(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostByUser(PostSubmitRequest postSubmitRequest)
        {
            var result = Guid.TryParse(postSubmitRequest.UserId, out Guid userId);
            //var response = await requestClient.GetResponse<User>(new UserIdResponse(guid), timeout: RequestTimeout.After(s: 30));
            //var user = response.Message;

            if (result != true)
            {
                return BadRequest("创建失败");
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
                return BadRequest("创建失败");
            }
            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ModifyPostStatus(PostRequest postRequest)
        {
            var post = await postRepository.FindAsync(Guid.Parse(postRequest.PostId));
            post.Status = postRequest.Status;
            var result = await postRepository.UpdateAsync(post);
            if (result)
            {
                return Ok();
            }
            return BadRequest("处理错误");

        }
    }
}
