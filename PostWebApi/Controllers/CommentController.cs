using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
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

        public CommentController(PostDomainService postService, ICommentRepository commentRepository)
        {
            this.postService = postService;
            this.commentRepository = commentRepository;
        }
        [HttpPost]
        public async Task<ActionResult<List<CommentResponse>>> GetCommentListByPost(PostResponse postResponse)
        {
            var comments = await postService.SearchCommentListByPostAsync(postResponse.Id);
            return Ok(comments);
        }
        [HttpPost]
        public async Task<ActionResult> CreatCommentByPost(PostResponse postResponse)
        {
            var comments = await postService.SearchCommentListByPostAsync(postResponse.Id);
            return Ok();
        }
    }
}
