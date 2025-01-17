﻿using CommonsDomain.DTO.Identity;
using CommonsDomain.Enum;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostWebApi.DTO;

namespace PostWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = $"{nameof(RolesEnum.User)},{nameof(RolesEnum.Admin)}")]
    public class PostController : ControllerBase
    {
        private readonly PostDomainService postService;
        private readonly IPostRepository postRepository;
        private readonly IRequestClient<User> requestClient;

        public PostController(PostDomainService postService, IPostRepository postRepository, IRequestClient<User> requestClient)
        {
            this.postService = postService;
            this.postRepository = postRepository;
            this.requestClient = requestClient;
        }

        [HttpPost]
        public async Task<ActionResult<List<PostResponse>>> GetPostListByUser(UserResponse userResponse)
        {
            var user = requestClient.GetResponse<User>(userResponse);
            if (user == null)
            {
                return BadRequest("空");
            }
            var posts = await postService.GetPostListByUserAsync(userResponse.Id);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<List<PostResponse>>> GetPostListByTitle(string title)
        {
            var posts = await postService.GetPostListByNameAsync(title);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostByUser(PostResponse postResponse)
        {
            var response = await requestClient.GetResponse<User>(postResponse.UeserId);
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
