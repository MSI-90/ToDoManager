using Contracts;
using Domain.ConfigurationModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence;
using Persistence.Repositories;
using Service;
using Service.Contracts;
using ToDoManager.Presentation.ActionFilters;
using System.Text;

namespace ToDoManager.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurePostgresConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
    }
    public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITaskItemService, TaskItemService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
    public static void ConfigureActionFilters(this IServiceCollection services)
    {
        services.AddScoped<ValidationFilter>();
    }
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = true;
            o.Password.RequireUppercase = true;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();
    }
    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration["Secret:Key"]!;

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["ValidIssuer"],
                ValidAudience = configuration["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }
}
