using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Tests.Builders.Util
{
    public class Access
    {
        [JsonProperty("token")]
        public Token Token { get; set; }
    }
}