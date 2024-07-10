//using Gcsb.Connect.SAP.Application.UseCases.Register.RequestHandlers;
using Gcsb.Connect.SAP.WebApi.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Pipeline
{
    public class ErrorHandlerMiddleware
    {
        private readonly IWebHostEnvironment env;
        private readonly IStringLocalizer<ReturnMessages> localization;

        public ErrorHandlerMiddleware(IWebHostEnvironment env, IStringLocalizer<Resources.ReturnMessages> localization)
        {
            this.env = env;
            this.localization = localization;
        }

        public async Task Invoke(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
            {
                return;
            }
            var model = new ProblemDetails
            {
                Detail = ex.Message
            };
            if (ex is ApiException apiException )
            {
                context.Response.StatusCode = apiException.HttpStatusCode;
                model.Title = apiException.Title;
            }
            //else if (ex is DocAggregateException)
            //{
            //    context.Response.StatusCode = 400;
            //    model.Title = $"{localization["MsgBlkLst002"]}: {ex.Message}";                                
            //    var listExCustom = new List<DocValidationException>();
            //    ((AggregateException)ex).InnerExceptions.ToList().ForEach(s => listExCustom.Add((DocValidationException)s));
            //    StringBuilder detail = new StringBuilder();               
            //    listExCustom.ForEach(s => detail.AppendLine(string.Format(localization["MsgBlkLst003"], s.ErrorLine.Item1, localization[s.ErrorLine.Item2])));
            //    model.Detail = detail.ToString();
            //}

            else if (ex is ArgumentOutOfRangeException)
            {
                context.Response.StatusCode = 404;
                model.Title = $"{localization[ex.GetType().Name]}: {ex.Message}";
            }
            else if (ex is NullReferenceException || ex is ArgumentException)
            {
                context.Response.StatusCode = 400;
                model.Title = $"{localization[ex.GetType().Name]}: {ex.Message}";
            }                     
            else if (ex is ApplicationException || ex is Domain.DomainException || ex is Infrastructure.InfrastructureException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = $"{localization["ServerError"]}: {ex.Message}";                
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = localization["ServerError"];               
            }
            
            if (env.IsDevelopment())
            {                
                model.Detail += $"{ex.GetType().ToString()}: {ex.Message}: {ex.StackTrace}";
            }

            context.Response.ContentType = "application/json";
            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, model);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
