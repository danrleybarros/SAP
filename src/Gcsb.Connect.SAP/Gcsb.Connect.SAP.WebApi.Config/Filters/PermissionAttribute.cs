using Gcsb.Connect.SAP.WebApi.Infraestructure.Extensions;
using Gscb.Connect.Pkg.Authentication.Dto;
using Gscb.Connect.Pkg.Authentication.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class PermissionAttribute : ActionFilterAttribute
    {
        private int[] roles;
        public PermissionAttribute(params int[] roleIds)
        {
            roles = roleIds;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var bearerToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var jsdnToken = bearerToken.GetJwtToken().GetJsdnToken();
            var response = AuthenticationStaticService.Authicate(new AuthenticationRequest(jsdnToken, roles));

            if (!response.IsAuthenticated)
            {
                context.Result = new UnauthorizedObjectResult(response.Message);
            }
        }
    }
}
