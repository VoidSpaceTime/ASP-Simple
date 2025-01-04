using IdentityService.WebAPI.Controllers.Login;
using IdentityServiceDomain;
using IdentityServiceDomain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace WebApplication1.Controllers.Login
{
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;
        public LoginController(IdDomainService idService, IIdRepository repository)
        {
            this.idService = idService;
            this.repository = repository;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetUserInfo()
        {
            string? userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var user = await repository.FindByIdAsync(Guid.Parse(userId));
            if (user == null)//可能用户注销了
            {
                return NotFound();
            }
            //出于安全考虑，不要机密信息传递到客户端
            //除非确认没问题，否则尽量不要直接把实体类对象返回给前端
            return new UserResponse(user.Id, user.PhoneNumber ?? string.Empty, user.CreationTime);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string?>> LoginByPhoneAndPwd(LoginByPhoneAndPwdRequest req)
        {
            //todo：要通过行为验证码、图形验证码等形式来防止暴力破解
            (var checkResult, string? token) = await idService.LoginByPhoneAndPwdAsync(req.PhoneNum, req.Password);
            if (checkResult.Succeeded)
            {
                return token;
            }
            else if (checkResult.IsLockedOut)
            {
                //尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "此账号已经锁定");
            }
            else
            {
                string msg = "登录失败";
                return StatusCode((int)HttpStatusCode.BadRequest, msg);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> LoginByUserNameAndPwd(LoginByUserNameAndPwdRequest req)
        {
            (var checkResult, var token) = await idService.LoginByUserNameAndPwdAsync(req.UserName, req.Password);
            if (checkResult.Succeeded) return token!;
            else if (checkResult.IsLockedOut)//尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "用户已经被锁定");
            else
            {
                string msg = checkResult.ToString();
                return BadRequest("登录失败" + msg);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> ChangeMyPassword(ChangeMyPasswordRequest req)
        {
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var resetPwdResult = await repository.ChangePasswordAsync(userId, req.Password);
            if (resetPwdResult.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(resetPwdResult.Errors.SumErrors());
            }
        }
    }
}
