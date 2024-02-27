using Data;
using Identity.Services;
using IdentityModels;
using Interfaces;
using Logger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Polly;
using Repositories;
using Rms.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration: builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();
builder.Host.UseSerilog(Log.Logger);

// Add services to the container.
builder.Services.AddSingleton<ICustomLogger, CustomLogger>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddAuthServices(builder.Configuration);

builder.Services.AddScoped<IApplicantInfo,ApplicantInfoReposit>();
builder.Services.AddScoped<IApplicantValidPhotoInfo,ApplicantValidPhotoInfoReposit>();
builder.Services.AddScoped<IApplicationRegistry, ApplicationRegistryReposit>();

builder.Services.AddScoped<IBeneficiary, BeneficiaryReposit>();
builder.Services.AddScoped<IBranchInfo, BranchInfoReposit>();
builder.Services.AddScoped<IBranchRegistry, BranchRegistryReposit>();
builder.Services.AddScoped<ICommonCode, CommonCodeReposit>();
builder.Services.AddScoped<IComputers, ComputersReposit>();

builder.Services.AddScoped<IExchangeRateInfo, ExchangeRateInfoReposit>();
builder.Services.AddScoped<IFeesInfo, FeesInfoReposit>();
builder.Services.AddScoped<IRemittance, RemittanceReposit>();

builder.Services.AddHealthChecks().AddDbContextCheck<Entity>();
builder.Services.AddHostedService<Rms.Worker>();
builder.Services.AddControllers();


var coreModuleTypes = new List<Type>
                {
                    typeof(Rms.CommonHandler),
                    typeof(Rms.CommonInterface),
                    typeof(Rms.CommonQuery),
                    typeof(Rms.CommonRepository),
                    typeof(Rms.CommonCommand),
                    typeof(Rms.CommonModel)
                };
var assem = coreModuleTypes.Select(x => x.Assembly).ToArray();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assem));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {

        builder.WithOrigins("https://localhost:7166")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ }
app.UseSwagger();
app.UseSwaggerUI();


var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
db.Database.Migrate();

var serviceProvider = app.Services.CreateScope().ServiceProvider;
DataSeed.Initialize(serviceProvider).Wait();


//app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/HealthCheck");

app.Run();
