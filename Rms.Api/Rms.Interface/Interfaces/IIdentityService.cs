using IdentityModels;
using ViewModels;

namespace Interfaces
{
    public interface IIdentityService
    {
        Task<Responses> CreateRole(ApplicationRole userrole);
        Task<Responses> UpdateRole(UpdateRoleModel userrole);
        Task<IQueryable<ApplicationRole>> GetRoles();
        Task<IQueryable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserByName(string UserName);
        Task<ApplicationUser> GetUserByEmail(string Email);
        Task<Responses> CreateUser(UserModel user);
        Task<Responses> UpdateUser(UserModel user);

        Task<UserTokens> GetToken(LoginModel model);
        Task<RefreshTokenModel> GetRefreshToken(RefreshTokenRequestModel model);

        Task<Responses> ChangePassword(ChangePasswordModel user);
        Task<string> ResetPasswordToken(string username);
        Task<Responses> ResetPassword(ResetPasswordModel model);
    }
}
