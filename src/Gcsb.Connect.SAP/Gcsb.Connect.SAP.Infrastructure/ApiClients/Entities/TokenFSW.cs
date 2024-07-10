using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities
{
    public class TokenFSW
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class User
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
