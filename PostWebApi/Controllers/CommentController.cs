using CommonsDomain.DTO.Identity;
using CommonsDomain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostWebApi.DTO;
using System;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly PostDomainService postService;
        private readonly ICommentRepository commentRepository;
        private readonly IRequestClient<UserIdResponse> requestClient;

        public CommentController(PostDomainService postService, ICommentRepository commentRepository, IRequestClient<UserIdResponse> requestClient)
        {
            this.postService = postService;
            this.commentRepository = commentRepository;
            this.requestClient = requestClient;
        }
        private async Task<List<CommentResponse>> ConvertRespositoryComment(List<Comment> comments)
        {
            var result = comments.Select(o => new CommentResponse(o.OwnerPost.Id.ToString(), o.OwnerUser.Id.ToString(), o.Content, o.CreationTime)).ToList();
            return await Task.FromResult(result);
        }
        private async Task<CommentResponse> ConvertRespositoryComment(Comment comment)
        {
            var result = new CommentResponse(comment.OwnerPost.Id.ToString(), comment.OwnerUser.Id.ToString(), comment.Content, comment.CreationTime);
            return await Task.FromResult(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<CommentResponse>>> GetCommentListByPost(PostRequest postRequest)
        {
            if (Guid.TryParse(postRequest.PostId, out Guid postId))
            {
                var comments = await postService.GetCommentListByPostAsync(postId);
                return Ok(this.ConvertRespositoryComment(comments));
            }
            return BadRequest("帖子不存在");
        }
        [HttpPost]
        public async Task<ActionResult> CreatCommentByPost(CommentResponse commentResponse)
        {
            var response = await requestClient.GetResponse<User>(new UserIdResponse(Guid.Parse(commentResponse.UserId)));
            var user = response.Message;
            Guid.TryParse(commentResponse.PostId, out Guid postId);
            if (user != null)
            {
                var post = await postService.GetPostByIdAsync(postId);
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
