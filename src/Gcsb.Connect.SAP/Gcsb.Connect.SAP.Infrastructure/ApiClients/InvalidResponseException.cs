using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients
{
    public class InvalidResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public InvalidResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
