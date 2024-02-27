using Data;
using IdentityModels;
using Interfaces;
using Logger;
using ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Logging;
using System.Text;
using Rms.Models;


namespace Identity.Services
{

    public class IdentityService : IIdentityService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly JwtSettings jwtSettings;
        private readonly ICustomLogger Logger;
        // private readonly Entity db;
        private readonly CustomLog CustomLog= new();
        public IdentityService(IServiceProvider _serviceProvider, ICustomLogger _logger, JwtSettings _jwtSettings)
        {
            serviceProvider = _serviceProvider;   
            Logger = _logger;
            jwtSettings = _jwtSettings;
            //db = _entiry;
        }
        public async Task<Responses> CreateRole(ApplicationRole userrole)
        {
            Responses responses = new();
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            try
            {
                var RoleManager1 = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                var roleExist = await RoleManager1.RoleExistsAsync(userrole.Name);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    var AppRole = new ApplicationRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = userrole.Name,
   
                    };
                    IdentityResult roleResult = await RoleManager1.CreateAsync(AppRole);
                    if (roleResult.Succeeded)
                    {
                        responses.IsSuccess = true;
                        responses.ReturnCode = "200";
                        responses.Message = "Save Success";
                        responses.Success = "OK";
                        CustomLog.Message = "Role Created Successfully";
                        CustomLog.Properties = userrole;
                        Logger.Information(CustomLog);
                    }
                    else
                    {

                        responses.IsSuccess = false;
                        responses.ReturnCode = "500";
                        responses.Message = "Role Created Failed";
                        responses.Success = "Failed";
                        CustomLog.Message = "Role Created Failed";
                        CustomLog.Properties = userrole;
                        Logger.Warning(CustomLog);
                        throw new Exception(CustomLog.Message);
                    }
                }
                else
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "500";
                    responses.Message = "Role already exist. Role Create Failed";
                    responses.Success = "Failed";

                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = userrole;
                    Logger.Warning(CustomLog);
                    throw new Exception(CustomLog.Message);
                }
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";
                responses.Message = "Role create failed. " + ex.ToString();
                responses.Success = "Failed";

                CustomLog.Properties = userrole;
                CustomLog.Message = responses.Message;
                Logger.Error(CustomLog);
                throw;

            }
            return responses;
        }
        public async Task<Responses> UpdateRole(UpdateRoleModel userrole)
        {
            Responses responses = new();
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;

            try
            {
                var RoleManager1 = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var roleExist = await RoleManager1.FindByIdAsync(userrole.Id);
                
                //var roleExists = await db.AspNetRoles.Where(x => x.NormalizedName == userrole.ShortName.ToUpper()).ToListAsync();
                if (roleExist != null)
                {
                    //var roleExist = roleExists.First();

                    roleExist.Name = userrole.Name;
                    await RoleManager1.UpdateAsync(roleExist);

                    //db.AspNetRoles.Update(roleExist);
                    //await db.SaveChangesAsync();

                    responses.IsSuccess = true;
                    responses.ReturnCode = "200";
                    responses.Message = "Role updated successfully.";
                    responses.Success = "OK";

                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = userrole;
                    Logger.Information(CustomLog);

                }
                else
                {
                    responses.IsSuccess = true;
                    responses.ReturnCode = "500";
                    responses.Message = "Failed to updat role .";
                    responses.Success = "Failed";

                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = userrole;
                    Logger.Information(CustomLog);
                }
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";
                responses.Message = "Role updated failed. " + ex.Message;
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = userrole;
                Logger.Error(CustomLog);
                throw;
            }
            return responses;
        }

        public async Task<IQueryable<ApplicationRole>> GetRoles()
        {
            try
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var roles = RoleManager.Roles;
                await Task.Delay(0);
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// CreateUser Method create new user and assign this uer to particular Role, office and organization
        /// Initially it create admin@gmail.com user with p@ssw0rd password
        /// </summary>
        /// <param name="user">user paramter is UserModel at ApplicationUser file</param>
        /// <returns>string with successful or failed</returns>
        public async Task<ApplicationUser> GetUserByName(string UserName)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            Responses responses = new();
            ApplicationUser AppUser = new();
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var login = await userManager.FindByNameAsync(UserName);
                
                // if (login != null)
                //{
                //    AppUser = new ()
                //    {
                //        Id = login.Id,
                //        UserName = login.UserName,
                //        FullName = login.FullName,
                //        Email = login.Email,
                //        PhoneNumber = login.PhoneNumber,
                //        RoleName = login.RoleName

                //        //OfficeCode = login.OfficeCode,
                //        //Organization = login.Organization,
                //    };
                //}
                return login;
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";
           
                responses.Success = "Failed";

                responses.Message = ex.ToString();
                CustomLog.Message = responses.Message;
                CustomLog.Properties = AppUser;
                Logger.Error(CustomLog);
                throw;
            }
        }
        public async Task<ApplicationUser> GetUserByEmail(string Email)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            Responses responses = new();
            ApplicationUser AppUser = new();
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var login = await userManager.FindByEmailAsync(Email);
                if (login != null)
                {
                    AppUser = new ApplicationUser()
                    {
                        Id = login.Id,
                        UserName = login.UserName,
                        UserFullName = login.UserFullName,
 
                        Email = login.Email,
                        PhoneNumber = login.PhoneNumber,
                        RoleName = login.RoleName,
                        BranchInfo = login.BranchInfo,
                        TransLimit = login.TransLimit,
                        VerifiedLimit = login.VerifiedLimit,
                        ApprovedUser = login.ApprovedUser,
                        CreatedBy = login.CreatedBy
                       //OfficeCode = login.OfficeCode,
                       // Organization = login.Organization,
                    };
                }
                return login;
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";

                responses.Success = "Failed";

                responses.Message = ex.ToString();
                CustomLog.Message = responses.Message;
                CustomLog.Properties = AppUser;
                Logger.Error(CustomLog);
                throw;
            }
        }
        public async Task<IQueryable<ApplicationUser>> GetAllUsers()
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            Responses responses = new();
            ///ApplicationUser AppUser = new();
            try
            {
                await Task.Delay(100);
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var logins =  userManager.Users;               
                return logins.AsQueryable();                
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";

                responses.Success = "Failed";

                responses.Message = ex.ToString();
                CustomLog.Message = responses.Message;
                CustomLog.Properties = null;
                Logger.Error(CustomLog);
                throw;
            }
        }

        public async Task<Responses> CreateUser(UserModel user)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            Responses responses = new();

            if (string.IsNullOrEmpty(user.Email))
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5001";
                responses.Success = "Failed";

                responses.Message = "Invalid e-mail Address";
                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }

            string email = user.Email;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5002";
                //responses.ReturnId = 5002;
                responses.Message = "Invalid format e-mail address";
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }

            if (string.IsNullOrEmpty(user.UserFullName))
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5003";
                //responses.ReturnId = 5003;
                responses.Message = "Invalid Name";
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }

            regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,20}$");
            match = regex.Match(user.Password);
            if (!match.Success)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5005";
                responses.Message = "Complex password required with at least 6 characters, 1 upper, 1 lower, 1 number and 1 symble";
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var login = await userManager.FindByNameAsync(user.UserName);
                if (login == null)
                {
                    ApplicationUser AppUser = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = user.UserName,
                        UserFullName = user.UserFullName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        RoleName=user.RoleName,
                        BranchInfo = login.BranchInfo,
                        TransLimit = login.TransLimit,
                        VerifiedLimit = login.VerifiedLimit,
                        ApprovedUser = login.ApprovedUser,
                        CreatedBy = login.CreatedBy

                        //OfficeCode = user.OfficeCode,
                        //OfficeId = user.OfficeId,
                        //Organization=user.Organization                        
                    };
                    IdentityResult res1 = await userManager.CreateAsync(AppUser, user.Password);

                    if (res1.Succeeded)
                    {                        
                        IdentityResult res2 = await userManager.AddToRoleAsync(AppUser, user.RoleName);
                        if (res2.Succeeded)
                        {
                            responses.IsSuccess = true;
                            responses.ReturnCode = "200";
                            responses.Message = "Save Success";
                            responses.Success = "OK";

                            CustomLog.Message = responses.Message;
                            CustomLog.Properties = user;
                            Logger.Information(CustomLog);
                        }
                        else
                        {
                            responses.IsSuccess = false;
                            responses.ReturnCode = "5006";
                            //responses.ReturnId = 5006;
                            responses.Message = "User not added to the Group. Group assign failed";

                            CustomLog.Message = responses.Message;
                            CustomLog.Properties = user;
                            Logger.Warning(CustomLog);
                            throw new Exception(CustomLog.Message);
                        }
                    }
                    else
                    {
                        responses.IsSuccess = false;
                        responses.ReturnCode = "5007";
                        //responses.ReturnId = 5007;
                        responses.Message = "User Creation Failed";

                        CustomLog.Message = responses.Message;
                        CustomLog.Properties = user;
                        Logger.Warning(CustomLog);
                        throw new Exception(CustomLog.Message);
                    }

                }
                else
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "5008";
                    //responses.ReturnId = 5008;
                    responses.Message = "User already Exists. Create failed";
                    responses.Success = "Failed";

                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = user;
                    Logger.Warning(CustomLog);
                    //throw (new Exception(CustomLog.Message));
                }

            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";
                //responses.ReturnId = 500;
                responses.Success = "Failed";

                responses.Message = ex.ToString();
                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Error(CustomLog);
                throw;
            }
            return responses;
        }
        public async Task<string> ResetPasswordToken(string username)
        {
            //var dbuser = serviceProvider.GetRequiredService<Entity>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            // ApplicationUser applicationUser = new();
            ApplicationUser AppUser = await userManager.FindByNameAsync(username);
            var token = await userManager.GeneratePasswordResetTokenAsync(AppUser);
            return token;
        }
        public async Task<Responses> ResetPassword(ResetPasswordModel model)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;

            Responses responses = new();
            try
            {
                var dbuser = serviceProvider.GetRequiredService<Entity>();
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                ApplicationUser AppUser = new();
                AppUser = await userManager.FindByNameAsync(model.UserName);
                //var AppUsers = dbuser.Users.Where(x => x.UserName == user.UserName).ToList();
                if (AppUser != null)
                {
                    IdentityResult res1 = await userManager.ResetPasswordAsync(AppUser, model.ResetPasswordToken, model.NewPassword);

                    if (res1.Succeeded)
                    {
                        responses.IsSuccess = true;
                        responses.ReturnCode = "200";
                        responses.Message = "Save Success";
                        responses.Success = "Successful";

                        CustomLog.Message = responses.Message;
                        CustomLog.Properties = null;
                        Logger.Information(CustomLog);
                    }
                    else
                    {
                        responses.IsSuccess = false;
                        responses.ReturnCode = "500";
                        responses.Message = "Reset Password Failed";

                        CustomLog.Message = responses.Message;
                        CustomLog.Properties = null;
                        Logger.Warning(CustomLog);
                        throw new Exception(CustomLog.Message);
                    }
                }
                else
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "500";
                    responses.Message = "User not Exists. Password changed failed";
                    responses.Success = "Failed";

                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = null;
                    Logger.Warning(CustomLog);
                    throw new Exception(CustomLog.Message);
                }
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";
                responses.Message = ex.ToString();
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = null;
                Logger.Error(CustomLog);
            }
            return responses;
        }
        public async Task<Responses> ChangePassword(ChangePasswordModel user)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            Responses responses = new();
            try
            {
                var dbuser = serviceProvider.GetRequiredService<Entity>();
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                //ApplicationUser AppUser = new ApplicationUser();
                ApplicationUser AppUser = await userManager.FindByNameAsync(user.UserName);
                if (AppUser != null)
                {
                    IdentityResult res1 = await userManager.ChangePasswordAsync(AppUser, user.OldPassword, user.NewPassword);

                    if (res1.Succeeded)
                    {
                        responses.IsSuccess = true;
                        responses.ReturnCode = "200";
                        responses.Message = "Save Success";
                        responses.Success = "Successful";

                        CustomLog.Message = responses.Message;
                        CustomLog.Properties = null;
                        Logger.Information(CustomLog);
                    }
                    else
                    {
                        responses.IsSuccess = false;
                        responses.ReturnCode = "500";
                        responses.Message = "Change Password Failed";
                        responses.Success = "Failed";

                        CustomLog.Message = responses.Message;
                        CustomLog.Properties = null;
                        Logger.Warning(CustomLog);
                        throw new Exception(CustomLog.Message);
                    }
                }
                else
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "500";
                    responses.Message = "User not Exists. Password changed failed";
                    responses.Success = "Failed";

                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = null;
                    Logger.Warning(CustomLog);
                    throw new Exception(CustomLog.Message);
                }
            }
            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "403";
                responses.Message = ex.ToString();
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = null;
                Logger.Error(CustomLog);
                throw;
            }
            return responses;
        }
        public async Task<Responses> UpdateUser(UserModel user)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;

            Responses responses = new Responses();

            if (string.IsNullOrEmpty(user.Email))
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5001";
                //responses.ReturnId = 5001;
                responses.Message = "Invalid e-mail Address";
                responses.Success = "Failed";

                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }

            string email = user.Email;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5002";
                responses.Success = "Failed";

                responses.Message = "Invalid format e-mail address";
                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }

            if (string.IsNullOrEmpty(user.UserFullName))
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "5003";
                responses.Success = "Failed";

                responses.Message = "Invalid Name";
                CustomLog.Message = responses.Message;
                CustomLog.Properties = user;
                Logger.Warning(CustomLog);
                throw new Exception(CustomLog.Message);
                //return responses;
            }
            try
            {

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();


                var AppUser = await userManager.FindByNameAsync(user.UserName);

                if (AppUser == null)
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "5000";
                    responses.Success = "Failed";

                    responses.Message = "User does not found to update";
                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = null;
                    Logger.Warning(CustomLog);
                    return responses;
                }
                var AppRole = await roleManager.FindByNameAsync(user.RoleName);
                if (AppRole == null)
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "5000";
                    responses.Success = "Failed";

                    responses.Message = "User Role does not found to update";
                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = null;
                    Logger.Warning(CustomLog);
                    return responses;
                }
                AppUser.Email = user.Email;
                AppUser.UserFullName = user.UserFullName;
                AppUser.PhoneNumber = user.PhoneNumber;
                AppUser.BranchInfo = user.BranchInfo;
                AppUser.TransLimit = user.TransLimit;
                AppUser.VerifiedLimit = user.VerifiedLimit;
                AppUser.ApprovedUser = user.ApprovedUser;
                AppUser.UserFullName = user.UserFullName;
                AppUser.RoleName = user.RoleName;

                IdentityResult res1 = await userManager.UpdateAsync(AppUser);
                if (res1.Succeeded)
                {
                    var isInRole = await userManager.IsInRoleAsync(AppUser, AppRole.Name);
                    if (isInRole && AppRole.Name.ToUpper() != user.RoleName.ToUpper())
                    {
                        IdentityResult res2 = await userManager.AddToRoleAsync(AppUser, user.RoleName);
                        if (res2.Succeeded)
                        {
                            responses.IsSuccess = true;
                            responses.ReturnCode = "200";
                            responses.Success = "OK";

                            responses.Message = "Update Ueser Successfully";
                            CustomLog.Message = responses.Message;
                            CustomLog.Properties = null;
                            Logger.Information(CustomLog);
                        }
                        else
                        {
                            responses.IsSuccess = false;
                            responses.ReturnCode = "5007";
                            responses.Success = "Failed";

                            responses.Message = "User not added to the Organization. Organization assign failed";
                            CustomLog.Message = responses.Message;
                            CustomLog.Properties = null;
                            Logger.Warning(CustomLog);
                            throw new Exception(CustomLog.Message);
                        }
                    }
                    else
                    {
                        responses.IsSuccess = true;
                        responses.ReturnCode = "200";
                        responses.Success = "OK";

                        responses.Message = "Update Ueser Successfully";
                        CustomLog.Message = responses.Message;
                        CustomLog.Properties = null;
                        Logger.Information(CustomLog);
                    }

                }
                else
                {
                    responses.IsSuccess = false;
                    responses.ReturnCode = "5008";
                    responses.Success = "Failed";

                    responses.Message = "update user failed";
                    CustomLog.Message = responses.Message;
                    CustomLog.Properties = null;
                    Logger.Warning(CustomLog);
                    throw new Exception(CustomLog.Message);
                }
            }

            catch (Exception ex)
            {
                responses.IsSuccess = false;
                responses.ReturnCode = "500";
                responses.Success = "Failed";

                responses.Message = ex.Message;
                CustomLog.Message = responses.Message;
                CustomLog.Properties = null;
                Logger.Error(CustomLog);
                throw;
            }
            return responses;
        }

        public async Task<UserTokens> GetToken(LoginModel model)
        {
            var tok = new UserTokens();
            var token = new UserTokens();
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var user = await userManager.FindByNameAsync(model.UserName);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var role = roleManager.FindByNameAsync(user.RoleName).Result;
                    if (role == null)
                        return token;
                    var guid = Guid.NewGuid();
                    tok.RoleId = role.Id;
                    tok.RoleName = role.Name;
                    tok.Id = guid;
                    tok.UserName = user.UserName;
                    tok.UserId = user.Id;
                    tok.EmailId = user.Email;
                    tok.ExpiredTime = DateTime.Now.AddDays(1);
                    token = JwtHelpers.GenTokenkey(tok, jwtSettings);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return token;
        }
        //public async Task<UserTokens> GetToken(LoginModel model)
        //{
        //    var tok = new UserTokens();
        //    var token = new UserTokens();

        //    try
        //    {
        //        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        //        var user = await userManager.FindByNameAsync(model.UserName);

        //        if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
        //        {
        //            var role = roleManager.FindByNameAsync(user.RoleName).Result;
        //            if (role == null)
        //                return null;


        //            var off = await (from o in db.OfficeInfo
        //                             join org in db.Organization on o.OrgId equals org.id
        //                             where o.OrgId == user.Organization && o.OfficeCode == user.OfficeCode
        //                             select new { officeName = o.OfficeName, OrgName = org.org_name }).ToListAsync();
        //            if (off.Any())
        //            {
        //                var office=off.FirstOrDefault();
        //                var guid = Guid.NewGuid();

        //                tok.RoleId = role.Id;
        //                tok.UserName = user.UserName;
        //                tok.RoleName = user.RoleName;                        
        //                tok.Expired = DateTime.Now.AddMinutes(Convert.ToInt32(UserConstant.TokenLive));
        //                tok.Organization=user.Organization;
        //                tok.OrganizationName=office.OrgName;
        //                tok.OfficeCode = user.OfficeCode;
        //                tok.OfficeName = office.officeName;
        //                tok.PhoneNumber=user.PhoneNumber;
        //                tok.Email=user.Email;
        //                tok.OfficeId=user.OfficeId;
        //                token = JwtHelpers.GenTokenkey(tok, jwtSettings);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //    return token;
        //}
        public async Task<RefreshTokenModel> GetRefreshToken(RefreshTokenRequestModel model)
        {
            try
            {
                await Task.Delay(100);
                if (TokenValidate(model.RefreshToken))
                {
                    var stream = model.RefreshToken;
                    var jwt = new JwtSecurityToken(jwtEncodedString: stream);
                    //string expiry = jwt.Claims.First(c => c.Type.Contains).Value;
                    var userName = jwt.Claims.First(claim => claim.Type.Contains("name")).Value;
                    var email = jwt.Claims.First(claim => claim.Type.Contains("email")).Value;

                    //var handler = new JwtSecurityTokenHandler();
                    //var jsonToken = handler.ReadToken(stream);
                    //var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                    //var userName = tokenS.Claims.First(claim => claim.Type == "name").Value;
                    //var email = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;
                    var Id = Guid.NewGuid();
                    var now = DateTime.Now;
                    var claims = new[] {
                    new Claim("Id",Id.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                    new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
                };

                    var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                    DateTime expireTime = DateTime.Now.AddMinutes(Convert.ToInt32(GlobalVar.TokenLive));

                    var token = new JwtSecurityToken(
                        issuer: jwtSettings.ValidIssuer,
                        audience: jwtSettings.ValidAudience,
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: expireTime,
                        signingCredentials: new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256) // SecurityAlgorithms.HmacSha512
                    );

                    expireTime = DateTime.Now.AddMinutes(Convert.ToInt32(GlobalVar.RefreshTokenLive));
                    var ref_token = new JwtSecurityToken(
                        issuer: jwtSettings.ValidIssuer,
                        audience: jwtSettings.ValidAudience,
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: expireTime,
                        signingCredentials: new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256) // SecurityAlgorithms.HmacSha512
                    );

                    return
                           new RefreshTokenModel()
                           {
                               Token = new JwtSecurityTokenHandler().WriteToken(token),
                               RefreshToken = new JwtSecurityTokenHandler().WriteToken(ref_token)

                           };
                }
                else
                {
                    return
                      new RefreshTokenModel();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserTokens> Authenticate(LoginModel model)
        {
            return await GetToken(model);
        }
        protected bool TokenValidate(string jwtToken)
        {
            bool isTokenValid = true;
            try
            {
                IdentityModelEventSource.ShowPII = true;
                SecurityToken validatedToken;
                TokenValidationParameters validationParameters = new TokenValidationParameters();
                validationParameters.ValidateLifetime = true;
                validationParameters.ValidAudience = jwtSettings.ValidAudience.ToLower();
                validationParameters.ValidIssuer = jwtSettings.ValidIssuer.ToLower();
                validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey));
                new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            }
            catch (Exception ex)
            {
                isTokenValid = false;
                Console.WriteLine(ex.ToString());
            }
            return isTokenValid;
        }
    }
}
