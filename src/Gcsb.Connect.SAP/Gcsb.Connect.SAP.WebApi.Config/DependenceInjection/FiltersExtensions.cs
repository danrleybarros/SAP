using Gcsb.Connect.SAP.WebApi.Filters;
using Gcsb.Connect.SAP.WebApi.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class FiltersExtensions
    {
        public static void AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(ApplicationExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Conventions.Add(new NotFoundResultApiConvention());
                options.Conventions.Add(new ProblemDetailsResultApiConvention());
            })
           .AddDataAnnotationsLocalization(options =>
           {
               options.DataAnnotationLocalizerProvider = (type, factory) =>
               {
                   return factory.Create(typeof(Resources.SharedResources));
               };
           })
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.IgnoreNullValues = true;

           })
           .AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
           });

        }
    }
}
