using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityModels
{
    public class ApplicationUser: IdentityUser<string>
    {
        [Required]
        [StringLength(10)]
        public string BranchInfo { get; set; }
        [StringLength(50)]
        public string WinPassword { get; set; }        
        [StringLength(150)]
        public string UserFullName { get; set; } = "";
        [Column(TypeName = "decimal(12,2)")]
        public decimal TransLimit { get; set; } = 0;
        [StringLength(256)]
        public string CreatedBy { get; set; }
        public bool ApprovedUser { get; set; } = false;
        [Column(TypeName = "decimal(12,2)")]
        public decimal VerifiedLimit { get; set; } = 0; 
        [StringLength(256)]
        public string RoleName { get; set; }
    }

    public class ApplicationRole: IdentityRole<string>
    {
 
    }

    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string BranchInfo { get; set; }
        [StringLength(50)]
        public string WinPassword { get; set; }
        [StringLength(150)]
        public string UserFullName { get; set; } = "";
        [Column(TypeName = "decimal(12,2)")]

        public decimal TransLimit { get; set; } = 0;
        [StringLength(256)]
        public string CreatedBy { get; set; }
        public bool ApprovedUser { get; set; } = false;
        [Column(TypeName = "decimal(12,2)")]

        public decimal VerifiedLimit { get; set; } = 0;
        [StringLength(256)]
        public string RoleName { get; set; }

    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class ResetPasswordModel
    {
        public string ResetPasswordToken { get; set; }
        public string UserName { get; set; }
        public string NewPassword { get; set; }
    }
   
    public class UpdateRoleModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    public class TokenModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime? Expired { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public int? BranchId { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenRequestModel
    {
        public string OldToken { get; set; }
        public string RefreshToken { get; set; }

    }
    public class ResetPasswordTokenReuestModel
    {
        public string UserName { get; set; }

    }

    public class RefreshTokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
