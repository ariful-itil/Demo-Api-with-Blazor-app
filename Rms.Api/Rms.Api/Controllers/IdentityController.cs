using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityModels;
using Interfaces;
using ViewModels;


namespace Sms.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("erp/api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        IIdentityService Srv;
        public IdentityController(IIdentityService _svr)
        {
            Srv = _svr;
        }
        [HttpGet]
        public async Task<IQueryable<ApplicationUser>> GetAllUsers()
        {
            try
            {
                var data = await Srv.GetAllUsers();
                return data.AsQueryable();

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }
        [HttpGet("{UserName}")]
        public async Task<ApplicationUser> GetUserByName(string UserName)
        {
            try
            {
                var data = await Srv.GetUserByName(UserName);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpGet("{Email}")]
        public async Task<ApplicationUser> GetUserByEmail(string Email)
        {
            try
            {
                var data = await Srv.GetUserByEmail(Email);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //[AllowAnonymous]
        [HttpPost]
        public async Task<Responses> CreateRole([FromBody] ApplicationRole userrole)
        {
            Responses result = await Srv.CreateRole(userrole);
            Response.StatusCode = Convert.ToInt32(result.ReturnCode);
            return result;
        }
        [HttpGet]
        public async Task<IQueryable<ApplicationRole>> GetRoles()
        {
            return await Srv.GetRoles();
        }
        [HttpPost]
        public async Task<Responses> UpdateRole(UpdateRoleModel userrole)
        {
            Responses result = await Srv.UpdateRole(userrole);
            Response.StatusCode = Convert.ToInt32(result.ReturnCode);
            return result;
        }
 
        [HttpPost]
        public async Task<Responses> CreateUser(UserModel user)
        {
            try
            {
                Responses result = await Srv.CreateUser(user);
                HttpContext.Response.StatusCode = Convert.ToInt32(result.ReturnCode);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        [HttpPost]
        public async Task<Responses> UpdateUser(UserModel user)
        {
            try
            {
                Responses result = await Srv.UpdateUser(user);
                HttpContext.Response.StatusCode = Convert.ToInt32(result.ReturnCode);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        [HttpPost]
        public async Task<string> GetResetPasswordToken(ResetPasswordTokenReuestModel model)
        {
            var token = await Srv.ResetPasswordToken(model.UserName);
            return token;
        }
        [HttpPost]
        public async Task<Responses> ResetPassword(ResetPasswordModel model)
        {
            try
            {
                var data = await Srv.ResetPassword(model);
                HttpContext.Response.StatusCode = Convert.ToInt32(data.ReturnCode);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<Responses> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                Responses result = await Srv.ChangePassword(model);
                HttpContext.Response.StatusCode = Convert.ToInt32(result.ReturnCode);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
 
        [AllowAnonymous]
        [HttpPost]
        public async Task<UserTokens> GetToken(LoginModel model)
        {
            var info = await Srv.GetToken(model);
            return info;
        }
        [HttpPost]
        public async Task<RefreshTokenModel> GetRefreshToken(RefreshTokenRequestModel model)
        {
            var info = await Srv.GetRefreshToken(model);
            return info;
        }
    }
}
