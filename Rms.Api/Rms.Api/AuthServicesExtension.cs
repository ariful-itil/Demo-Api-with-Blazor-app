using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Data;
using IdentityModels;
using ViewModels;
using Rms.Models;


public static class AuthServicesExtension
{
    public static void AddAuthServices(this IServiceCollection Services, IConfiguration Configuration)
    {
        GlobalVar.ApplicationName = Configuration["ApplicationName"];
        GlobalVar.TokenLive = Configuration["Token:TokenLive"].ToString();
        GlobalVar.RefreshTokenLive = Configuration["Token:RefreshTokenLive"];
        GlobalVar.DbConnection = Configuration.GetConnectionString("SqlConn");
        GlobalVar.SecurityId = Configuration["SecurityId"];
        GlobalVar.SecurityValue = Configuration["SecurityValue"];

        //Services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlite(Configuration.GetConnectionString("SqlConn")));

        Services.AddDbContext<Entity>(options =>
           options.UseSqlServer(GlobalVar.DbConnection));
        Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(GlobalVar.DbConnection));

        Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@!#";
            options.User.RequireUniqueEmail = true;

        }
         ).AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();
        // User Contant //////////////////////////////
        // Add Jwt Setings
        var bindJwtSettings = new JwtSettings();
        Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
        Services.AddSingleton(bindJwtSettings);


        Services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.SaveToken = true;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                ValidateIssuer = bindJwtSettings.ValidateIssuer,
                ValidIssuer = bindJwtSettings.ValidIssuer,
                ValidateAudience = bindJwtSettings.ValidateAudience,
                ValidAudience = bindJwtSettings.ValidAudience,
                RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
                ValidateLifetime = bindJwtSettings.ValidateLifetime,
                ClockSkew = TimeSpan.FromDays(1),
            };
        });
    }
}


