using IdentityModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ViewModels;

namespace Identity.Services
{
    public static class JwtHelpers
    {

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            IEnumerable<Claim> claims = new Claim[]
                    {
                new Claim("Id",Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt") )
                    };
            return claims;
        }
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return userAccounts.GetClaims(Id);
        }
        public static UserTokens GenTokenkey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var UserToken = new UserTokens();
                if (model == null)
                    return UserToken;
                UserToken = model;

                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DateTime.Now.AddMinutes(720);   //(Convert.ToInt32(UserConstant.TokenLive)) ;
                UserToken.Validaty = model.Validaty;
                var JWToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: model.GetClaims(out Id),
                    notBefore: DateTime.Now,
                    expires: expireTime,
                    signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256) // SecurityAlgorithms.HmacSha512
                ) ;

                expireTime = DateTime.Now.AddMinutes(1440);  //(Convert.ToInt32(UserConstant.RefeshTokenLive));
                var JWTokenRefresh = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: model.GetClaims(out Id),
                    notBefore: DateTime.Now,
                    expires: expireTime,
                    signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256) // SecurityAlgorithms.HmacSha512
                );
                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                UserToken.RefreshToken = new JwtSecurityTokenHandler().WriteToken(JWTokenRefresh);
                return UserToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
