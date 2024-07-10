using Gcsb.Connect.SAP.WebApi.Config.DependenceInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class ExceptionExtensions
    {
        public static void UseExceptionHandler(this IApplicationBuilder app,  IWebHostEnvironment env)
        {
            var serviceProvider = app.ApplicationServices;
            var resouces = serviceProvider.GetService<IStringLocalizer<Resources.ReturnMessages>>();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new Pipeline.ErrorHandlerMiddleware(env, resouces).Invoke
            });
        }
    }
}
