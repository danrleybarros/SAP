using Gcsb.Connect.SAP.WebApi.Config.Model;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Gcsb.Connect.SAP.WebApi.Infraestructure.Services
{
    public class IdentityParser : IIdentityParser<UserInfo>
    {
        public UserInfo Parse(IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claims)
            {
                return new UserInfo()
                {
                    CompanyName = claims.Claims.FirstOrDefault(x => x.Type == "CompanyName")?.Value ?? "",
                    IsImported = bool.Parse((claims.Claims.FirstOrDefault(x => x.Type == "IsImported")?.Value ?? "false").ToLower()),
                    Empty = bool.Parse((claims.Claims.FirstOrDefault(x => x.Type == "Empty")?.Value ?? "false").ToLower()),
                    Name = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "",
                    FirstName = claims.Claims.FirstOrDefault(x => x.Type == "FirstName")?.Value ?? "",
                    LastName = claims.Claims.FirstOrDefault(x => x.Type == "LastName")?.Value ?? "",
                    Email = "",
                    LoginName  = claims.Claims.FirstOrDefault(x => x.Type == "LoginName")?.Value ?? "",
                    RoleName = claims.Claims.FirstOrDefault(x => x.Type == "RoleName")?.Value ?? "",
                    RoleId = long.Parse(claims.Claims.FirstOrDefault(x => x.Type == "RoleId")?.Value ?? "0"),
                    CompanyId = long.Parse(claims.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value ?? "0"),
                    TenantID = claims.Claims.FirstOrDefault(x => x.Type == "TenantID")?.Value ?? "0",
                    Imported = bool.Parse((claims.Claims.FirstOrDefault(x => x.Type == "Imported")?.Value ?? "false").ToLower()),
                    CustomerCode = long.Parse(claims.Claims.FirstOrDefault(x => x.Type == "CustomerCode")?.Value ?? "0"),
                };
            }
            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}
