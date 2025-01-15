using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostWebApi.DTO;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly PostDomainService postService;
        private readonly ICommentRepository commentRepository;
        private readonly IRequestClient<User> requestClient;

        public CommentController(PostDomainService postService, ICommentRepository commentRepository)
        {
            this.postService = postService;
            this.commentRepository = commentRepository;
        }
        [HttpPost]
        public async Task<ActionResult<List<CommentResponse>>> GetCommentListByPost(PostResponse postResponse)
        {
            if (Guid.TryParse(postResponse.Id, out Guid userId))
            {
                var comments = await postService.GetCommentListByPostAsync(userId);
                return Ok(comments);
            }
            return BadRequest("用户不存在");
        }
        [HttpPost]
        public async Task<ActionResult> CreatCommentByPost(CommentResponse commentResponse)
        {
            var response = await requestClient.GetResponse<User>(commentResponse.UserId);
            var user = response.Message;
            if (Guid.TryParse(commentResponse.PostId, out Guid userId) && user != null)
            {
                var post = await postService.GetPostByIdAsync(userId);
                var comment = new Comment(post, commentResponse.Content, user);
                var result = await postService.CreateCommentAsync(comment);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest("创建失败");
        }


    }
}
