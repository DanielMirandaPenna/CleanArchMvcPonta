﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CleanArchMvcPonta.Infra.IoC;

public static class DependencyInjectionJWT
{
    public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services,
        IConfiguration configuration)

    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        });
        //informar o tipo de autenticacao JWT-Bearer
        //definir o modelo de desafio de autenticacao
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        //habilita a autenticacao JWT usando o esquema e desafio definidos
        //validar o token
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                //valores validos
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        })
        ;
        return services;
    }
}
