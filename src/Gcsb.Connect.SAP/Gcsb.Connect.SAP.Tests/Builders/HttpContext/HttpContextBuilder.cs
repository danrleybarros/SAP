using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.HttpContext
{
    public class HttpContextBuilder
    {
        public DefaultHttpContext HttpContext { get; set; }

        public static HttpContextBuilder New()
        {
            return new HttpContextBuilder
            {
                HttpContext = new DefaultHttpContext
                {
                    User = ClaimBuilder.New().Build()
                }
            };
        }

        public DefaultHttpContext Build()
        {
            return HttpContext;
        }
    }
}
