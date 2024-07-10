﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class AuthorizationExtensions
    {
        public static void AddJwtToken(this IServiceCollection services)
        {
            var jwtToken = Environment.GetEnvironmentVariable("JWT_KEY");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
#if DEBUG
                    options.RequireHttpsMetadata = false;
#endif
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken))
                    };
                });
        }
    }
}
