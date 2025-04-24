using ASPNETCore;
using CommonsDomain.DTO;
using CommonsDomain.DTO.Identity;
using CommonsDomain.Entities;
using CommonsDomain.Enum;
using CommonsDomain.ETO;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostServicInfrastructure;
using PostWebApi.DTO;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private readonly IBus pubushBus;
        private readonly PostDomainService postService;
        private readonly IPostRepository postRepository;
        private readonly IRequestClient<UserIdResponse> requestClient;

        public PostController(PostDomainService postService, IPostRepository postRepository, IRequestClient<UserIdResponse> requestClient, IBus pubushBus)
        {
            this.postService = postService;
            this.postRepository = postRepository;
            this.requestClient = requestClient;
            this.pubushBus = pubushBus;
        }
        private async Task<List<PostResponse>> ConvertRespositoryPost(List<Post> posts)
        {
            var result = posts.Select(o => new PostResponse(o.Id, o.Title, o.Content, o.UserId, o.Categories, o.Tags)).ToList();
            return await Task.FromResult(result);
        }
        private async Task<PostResponse> ConvertRespositoryPost(Post post)
        {
            var result = new PostResponse(post.Id, post.Title, post.Content, post.UserId, post.Categories, post.Tags);
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
        public async Task<JsonResponseL> GetPostAllList(List<PublicationStatusEnum> status)
        {
            var res = new JsonResponseL();
            var posts = new List<Post>();
            foreach (var item in status)
            {
                var post = await postRepository.QueryListAsync(o => o.IsDeleted != true && o.Status == item);
                posts.AddRange(post);
            }
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<JsonResponseL> QueryPostListByUser(PostQueryRequest postQueryRequest)
        {
            var res = new JsonResponseL();
            Guid.TryParse(postQueryRequest.UserId, out var userId);
            if (postQueryRequest == null || postQueryRequest.UserId == null)
            {
                return res.Fail("参数错误");
            }
            // 从当前用户的 Claims 中提取角色信息
            //var roles = this.User.FindAll(ClaimTypes.Role).Select(claim => claim.Value).ToList();
            string? queryUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var status = new List<PublicationStatusEnum>();
            if (queryUserId == postQueryRequest.UserId)
            {
                status.Add(PublicationStatusEnum.Wait);
                status.Add(PublicationStatusEnum.Fail);
            }
            status.Add(PublicationStatusEnum.Pass);


            var posts = await postService.QueryPostListByUserAsync(userId, status, false);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpGet]
        public async Task<JsonResponseL> GetPostListByUser()
        {
            var res = new JsonResponseL();
            var userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var status = new List<PublicationStatusEnum>() { PublicationStatusEnum.Pass, PublicationStatusEnum.Wait, PublicationStatusEnum.Fail };
            var posts = await postService.QueryPostListByUserAsync(userId, status, false);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }

        [HttpPost]
        public async Task<JsonResponseL> QueryPostListByCategory(PostQueryRequest postQueryRequest)
        {
            var res = new JsonResponseL();
            if (postQueryRequest.Category == null)
            {
                return res.Fail("Category is null");
            }
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true && o.Categories.Contains(postQueryRequest.Category) && o.Status == PublicationStatusEnum.Pass);
            return res.Succeed(this.ConvertRespositoryPost(posts));
        }
        [HttpPost]
        public async Task<JsonResponseL> QueryPostListByTag(PostQueryRequest postQueryRequest)
        {
            var res = new JsonResponseL();
            if (postQueryRequest.Tag == null)
            {
                return res.Fail("Tag is null");
            }
            var posts = await postRepository.QueryListAsync(o => o.IsDeleted != true && o.Categories.Contains(postQueryRequest.Tag) && o.Status == PublicationStatusEnum.Pass);
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

            await postService.CreatePostAsync(post);
            await pubushBus.Publish(new CreatePostEto(post.Id, post.Title, post.Tags, post.Categories));
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
        [HttpDelete]
        public async Task<JsonResponseL> DeletePost(string postId)
        {
            var res = new JsonResponseL();
            var post = await postRepository.FindAsync(Guid.Parse(postId));
            await postRepository.HardDeleteAsync(post);
            await pubushBus.Publish(new HardDeletePostEto(post.Id, post.Title, post.Categories));
            return res.Succeed();
        }
    }
}
