using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.Util
{
    class JsdnToken
    {
        [JsonProperty("access")]
        public Access Access { get; set; }
    }
}
