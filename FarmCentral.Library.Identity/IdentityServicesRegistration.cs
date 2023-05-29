using FarmCentral.Library.Identity.DbContext;
using FarmCentral.Library.Identity.Models;
using FarmCentral.Library.Identity.Services;
using FarmCentral.Library.Shared.Identity;
using FarmCentral.Library.Shared.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Identity;

public static class IdentityServicesRegistration
{
    //Registers services required for identity.
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Gets the strings from the application.json wherever this method is called.
        services
            .Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services
            .AddDbContext<FarmCentralIdentityDbContext>(options =>
                options
                .UseSqlServer(configuration.GetConnectionString("FarmCentralIdentityConnectionString")));

        services
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<FarmCentralIdentityDbContext>()
            .AddDefaultTokenProviders();

        //Injects AuthService
        services.AddTransient<IAuthService, AuthService>();
        //services.AddTransient<IFarmerService, FarmerService>();


        //Configures authentication to allow JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });

        return services;
    }
}
