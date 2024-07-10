using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.GenerateInterfaceDtos
{
    public class NotificationError
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

        public NotificationError(string errorMessage, string stackTrace)
        {
            ErrorMessage = errorMessage;
            StackTrace = stackTrace;
        }
    }
}
