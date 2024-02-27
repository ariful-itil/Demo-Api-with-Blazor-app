using System;

namespace IdentityModels
{
    public class UserTokens
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validaty { get; set; }
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
        public string EmailId { get; set; }
        public string RoleId { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string RoleName { get; set; }
        public Guid Id { get; set; }
    }
}
