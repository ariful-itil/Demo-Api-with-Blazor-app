using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IdentityModels;

namespace Data
{
    public static class DataSeed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                string[] roleNames = { "Habro", "Admin", "Individual" };

                foreach (var roleName in roleNames)
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        //create the roles and seed them to the database: Question 1
                        ApplicationRole role = new ApplicationRole();
                        role.Id = Guid.NewGuid().ToString();
                        role.Name = roleName;

                        await RoleManager.CreateAsync(role);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string[] userNames = { "Habro", "Admin" };

                foreach (var userName in userNames)
                {
                    ApplicationUser user = new ApplicationUser();

                    var xuser = await userManager.FindByNameAsync(userName);
                    if (xuser == null)
                    {
                        user.Id = Guid.NewGuid().ToString();
                        user.UserName = userName;
                        user.Email = $"{userName}@habro.com";
                        user.UserFullName = userName;
                        user.PhoneNumber = "+880248810576";
                        user.BranchInfo = "11";
                        user.ApprovedUser = true;
                        user.RoleName = userName;
                        user.CreatedBy = "System";
                        user.TransLimit = 0;
                        user.VerifiedLimit = 0;
                        user.WinPassword = "######";

                        IdentityResult res1 = await userManager.CreateAsync(user, "P@ssw0rd");
                        if (res1.Succeeded)
                        {
                            // await userManager.AddToRoleAsync(user, userName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
