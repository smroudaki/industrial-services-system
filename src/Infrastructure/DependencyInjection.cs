using IndustrialServicesSystem.Application;
using IndustrialServicesSystem.Application.Common.Interfaces;
//using IndustrialServicesSystem.Infrastructure.Files;
using IndustrialServicesSystem.Infrastructure.Identity;
using IndustrialServicesSystem.Infrastructure.Persistence;
using IndustrialServicesSystem.Infrastructure.Services;
//using IdentityModel;
//using IdentityServer4.Models;
//using IdentityServer4.Test;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace IndustrialServicesSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<IndustrialServicesSystemContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Local"),
                    b => b.MigrationsAssembly(typeof(IndustrialServicesSystemContext).Assembly.FullName)));

            services.AddScoped<IIndustrialServicesSystemContext>(provider => provider.GetService<IndustrialServicesSystemContext>());

            // configure strongly typed settings objects
            var jwtSection = configuration.GetSection("Jwt");
            services.Configure<JwtSettings>(jwtSection);

            // configure jwt authentication
            var jwtSettings = jwtSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var issuer = jwtSettings.Issuer;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.FromSeconds(0)
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/ChatHub"))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };
                });

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IChatRoomService, ChatRoomService>();
            services.AddTransient<IZarinPalService, ZarinPalService>();

            return services;
        }
    }
}
