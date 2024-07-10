using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class OptionsExtensions
    {
        public static IApplicationBuilder AddOptions(this IApplicationBuilder app)
        {
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            return app;
        }
    }
}
