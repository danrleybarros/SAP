using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class LogExtensions
    {
        public static void UseMiddleware(this IApplicationBuilder app)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseMiddleware<Pipeline.LogRequestMiddleware>();

        }
    }
}
