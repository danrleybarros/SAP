namespace Gcsb.Connect.SAP.WebApi.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net;

    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptions = new Type[]{typeof(ApplicationException), typeof(ArgumentException)};
            var ex = context.Exception;
            if (exceptions.Contains(context.Exception.GetType()))
            {
                string json = JsonConvert.SerializeObject(context.Exception.Message);

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
