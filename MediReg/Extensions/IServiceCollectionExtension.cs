﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using API.Services;
using BLL.Services.Tables;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;

namespace API.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<CardService>();
            services.AddScoped<TopicService>();
        }

        public static void RegisterJwtAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = configuration.GetSection("JwtSettings").Get<AuthModel.JwtSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwt.Issuer,
                        ValidAudience = jwt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                        ClockSkew = TimeSpan.Zero,
                    };
                });
        }

        public static void RegisterSwagger(this IServiceCollection services)
        {
            var xmlFileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "MediReg Api" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme    
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                x.CustomSchemaIds(t => t.FullName);

                x.IncludeXmlComments(xmlFilePath, true);
            });
        }

        public static void RegisterConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connection));
        }

        public static void RegisterIOptions(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<AuthModel.JwtSettings>(x => configuration.GetSection("JwtSettings").Bind(x));
        }

        public static void RegisterAuth(this IServiceCollection services) 
        {
            services.AddIdentityCore<User>(x =>
                {
                    x.Password.RequireDigit = false;
                    x.Password.RequiredLength = 6;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireUppercase = false;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}