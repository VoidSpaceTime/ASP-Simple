using CommonsDomain.DTO.Identity;
using CommonsDomain.Enum;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostWebApi.DTO;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(RolesEnum.User)},{nameof(RolesEnum.Admin)}")]
    public class PostController : ControllerBase
    {
        private readonly PostDomainService postService;
        private readonly IPostRepository postRepository;
        private readonly IRequestClient<User> requestClient;
        //private readonly IPublishEndpoint publishEndpoint;

        public PostController(PostDomainService postService, IPostRepository postRepository)
        {
            this.postService = postService;
            this.postRepository = postRepository;
        }
        [HttpPost]
        public async Task<ActionResult<List<Post>>> GetPostListByUser(UserResponse userResponse)
        {
            var user = requestClient.GetResponse<User>(userResponse);
            if (user == null)
            {
                return BadRequest("空");
            }
            var posts = await postService.SearchPostListByUserAsync(userResponse.Id);
            return Ok(posts);
        }
        [HttpPost]
        public async Task<ActionResult<List<Post>>> GetPostListByTitle(string title)
        {
            var posts = await postService.SearchPostListByNameAsync(title);
            return Ok(posts);
        }
        [HttpPost]
        public async Task<ActionResult> CreatPostByUser(PostResponse postResponse,UserResponse userResponse)
        {
            var response = await requestClient.GetResponse<User>(userResponse);
            var user = response.Message;

            if (user == null)
            {
                return BadRequest("创建失败");
            }
            var post = new Post(postResponse.Title, postResponse.Content, user);
            var r = await postService.CreatePostAsync(post);
            if (r == false)
            {
                return BadRequest("创建失败");
            }
            return Ok();
        }


    }
}
