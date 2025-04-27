using ASPNETCore;
using CommonsDomain.DTO;
using CommonsDomain.DTO.Identity;
using CommonsDomain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostServicInfrastructure;
using PostWebApi.DTO;
using System;
using static MassTransit.ValidationResultExtensions;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UnitOfWork(typeof(PostDbContext))]
    public class CommentController : ControllerBase
    {
        private readonly CommentDomainService commentService;
        private readonly IBaseRepository<Comment> commentRepository;
        private readonly IRequestClient<UserIdResponse> requestClient;

        public CommentController(CommentDomainService commentService, IBaseRepository<Comment> commentRepository, IRequestClient<UserIdResponse> requestClient)
        {
            this.commentService = commentService;
            this.commentRepository = commentRepository;
            this.requestClient = requestClient;
        }
        private async Task<List<CommentResponse>> ConvertRespositoryComment(List<Comment> comments)
        {
            var result = comments.Select(o => new CommentResponse(o.OwnerPostId.ToString(), o.OwnerUserId.ToString(), o.Content, null, null, o.CreationTime)).ToList();
            return await Task.FromResult(result);
        }
        private async Task<CommentResponse> ConvertRespositoryComment(Comment comment)
        {
            var result = new CommentResponse(comment.OwnerPostId.ToString(), comment.OwnerUserId.ToString(), comment.Content, null, null, comment.CreationTime);
            return await Task.FromResult(result);
        }
        [HttpPost]
        public async Task<JsonResponseL> GetCommentListByPost(PostRequest postRequest)
        {
            var res = new JsonResponseL();
            if (Guid.TryParse(postRequest.PostId, out Guid postId))
            {
                var comments = await commentService.QueryCommentListByPostAsync(postId);
                return res.Succeed(await Task.FromResult(this.ConvertRespositoryComment(comments)));

            }
            return res.Fail("帖子不存在");
        }
        [HttpPost]
        public async Task<JsonResponseL> CreatCommentByPost(CommentResponse commentResponse)
        {
            var res = new JsonResponseL();
            // 通过MassTransit 获取用户实体
            //var response = await requestClient.GetResponse<User>(new UserIdResponse(Guid.Parse(commentResponse.UserId)));
            //var user = response.Message;

            Guid.TryParse(commentResponse.UserId, out Guid userId);
            Guid.TryParse(commentResponse.ReplyUserId, out Guid replyUserId);
            Guid.TryParse(commentResponse.ReplyCommentId, out Guid replyCommentId);
            Guid.TryParse(commentResponse.PostId, out Guid postId);
            if (userId != Guid.Empty && postId != Guid.Empty)
            {
                var comment = Comment.Create(commentResponse.Content, userId, postId, replyUserId, replyCommentId);
                await commentService.CreateCommentAsync(comment);
            }
            return res.Fail("创建失败");
        }


    }
}
