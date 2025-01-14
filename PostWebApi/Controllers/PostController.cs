using CommonsDomain.Enum;
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

        public PostController(PostDomainService postService, IPostRepository postRepository)
        {
            this.postService = postService;
            this.postRepository = postRepository;
        }
        [HttpPost]
        public async Task<ActionResult<List<Post>>> GetPostListByUser(UserResponse userResponse)
        {
            var posts = await postService.SearchPostListByUserAsync(userResponse.Id);
            return Ok(posts);
        }
        [HttpPost]
        public async Task<ActionResult<List<Post>>> GetPostListByTitle(string title)
        {
            var posts = await postService.SearchPostListByNameAsync(title);
            return Ok(posts);
        }


    }
}
