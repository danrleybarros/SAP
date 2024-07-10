using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Infraestructure.Extensions
{
    public static class GetJwtTokenExtension
    {
        public static JwtSecurityToken GetJwtToken(this string token)
        {
            var jsonToken = new JwtSecurityToken();
            var handler = new JwtSecurityTokenHandler();
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Replace("bearer ", "").Replace("Bearer ", "");
                jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            }
            return jsonToken;
        }

        public static string GetJsdnToken(this JwtSecurityToken token)
        {
            var jsdnToken = string.Empty;
            var claim = token.Claims.FirstOrDefault(claim => claim.Type.Equals("JsdnToken"));

            if (claim != null)
                jsdnToken = claim.Value;

            return jsdnToken;
        }
    }
}
