using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class CorsExtensions
    {
        public static void Cors(this IServiceCollection services)
        {
            if (Environment.GetEnvironmentVariable("ALLOWED_HOSTS") != null)
            {
                var allowedHosts = Environment.GetEnvironmentVariable("ALLOWED_HOSTS").Split("|");

                services.AddCors(options => options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedHosts);
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                    policy.AllowCredentials();
                }));
            }
        }
    }
}
