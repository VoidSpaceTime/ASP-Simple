using CommonsDomain.DTO.Identity;
using CommonsDomain.DTO;
using CommonsDomain.Entities;
using CommonsDomain.Enum;
using IdentityService.WebAPI.Controllers.Login;
using IdentityServiceDomain;
using IdentityServiceDomain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace WebApplication1.Controllers.Login
{
    [Route("[controller]/[action]")]
    [ApiController]
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
        [AllowAnonymous]
        public async Task<JsonResponseL> CreateWorld()
        {
            var res = new JsonResponseL();

            if (await repository.FindByNameAsync("admin") != null)
            {
                return res.Fail("已经初始化过了");
            }
            User user = new User("admin");
            var r = await repository.CreateAsync(user, "123456");
            Debug.Assert(r.Succeeded);
            var token = await repository.GenerateChangePhoneNumberTokenAsync(user, "18918999999");
            var cr = await repository.ChangePhoneNumAsync(user.Id, "18918999999", token);
            Debug.Assert(cr.Succeeded);
            r = await repository.AddToRoleAsync(user, "User");
            Debug.Assert(r.Succeeded);
            r = await repository.AddToRoleAsync(user, "Admin");
            Debug.Assert(r.Succeeded);
            return res.Succeed();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResponseL> RegisterUser(RegisterUserRequest registerUser)
        {
            var res = new JsonResponseL();
            if (await repository.FindByNameAsync(registerUser.Name) != null)
            {
                return res.Fail("用户名已注册");
                //return StatusCode((int)HttpStatusCode.Conflict, "用户名已注册");
            }
            User user = new User(registerUser.Name);
            var r = await repository.CreateAsync(user, registerUser.Password);
            Debug.Assert(r.Succeeded);
            // 直接拿到手机号Token 没弄注册服务
            var token = await repository.GenerateChangePhoneNumberTokenAsync(user, registerUser.PhoneNumber);
            var cr = await repository.ChangePhoneNumAsync(user.Id, registerUser.PhoneNumber, token);
            Debug.Assert(cr.Succeeded);
            r = await repository.AddToRoleAsync(user, RolesEnum.User.ToString());
            //Debug.Assert(r.Succeeded);
            //r = await repository.AddToRoleAsync(user, "Admin");
            Debug.Assert(r.Succeeded);
            return res.Succeed();
        }


        [HttpGet]
        [Authorize]
        public async Task<JsonResponseL> GetUserInfo()
        {
            var res = new JsonResponseL();
            string? userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return res.LoginFail();
            }
            var user = await repository.FindByIdAsync(Guid.Parse(userId));
            if (user == null)//可能用户注销了
            {
                return res.Fail("用户不存在");
            }
            //出于安全考虑，不要机密信息传递到客户端
            //除非确认没问题，否则尽量不要直接把实体类对象返回给前端
            return res.Succeed(new UserResponse(user.Id, user.PhoneNumber ?? string.Empty, user.CreationTime));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResponseL> LoginByPhoneAndPwd(LoginByPhoneAndPwdRequest req)
        {
            var res = new JsonResponseL();
            //todo：要通过行为验证码、图形验证码等形式来防止暴力破解
            (var checkResult, string? token) = await idService.LoginByPhoneAndPwdAsync(req.PhoneNum, req.Password);
            if (checkResult.Succeeded)
            {
                return res.Succeed(new { token });
            }
            else if (checkResult.IsLockedOut)
            {
                //尝试登录次数太多
                return res.Fail("此账号已经锁定");
            }
            else
            {
                return res.Fail("登录失败");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResponseL> LoginByUserNameAndPwd(LoginByUserNameAndPwdRequest req)
        {
            var res = new JsonResponseL();
            (var checkResult, var token) = await idService.LoginByUserNameAndPwdAsync(req.UserName, req.Password);
            if (checkResult.Succeeded)
                return res.Succeed(new { token });
            else if (checkResult.IsLockedOut)//尝试登录次数太多
                return res.Fail("用户已经被锁定");
            else
            {
                string msg = checkResult.ToString();
                return res.Fail("登录失败" + msg);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<JsonResponseL> ChangeMyPassword(ChangeMyPasswordRequest req)
        {
            var res = new JsonResponseL();
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var resetPwdResult = await repository.ChangePasswordAsync(userId, req.Password);
            if (resetPwdResult.Succeeded)
            {
                return res.Succeed();
            }
            else
            {
                return res.Fail(resetPwdResult.Errors.SumErrors());
            }
        }
    }
}
