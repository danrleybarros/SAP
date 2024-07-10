using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Tests.Builders.Util
{
    public class Token
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("expires")]
        public string Expires { get; set; }
    }
}