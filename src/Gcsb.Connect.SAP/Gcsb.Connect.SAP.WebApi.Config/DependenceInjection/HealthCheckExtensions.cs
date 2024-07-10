using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class HealthCheckExtensions
    {
        private static string ConnString = Environment.GetEnvironmentVariable("DBCONN");
        /// <summary>
        /// Add Health Check
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks().AddNpgSql(ConnString, name: "db");
            return services;
        }
        /// <summary>
        /// Use Health Check
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthz", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            return app;
        }
    }
}
