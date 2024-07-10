using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY
{
    public class CriticalRequest
    {
        public Guid IDPaymentFeed { get; private set; }
        public Messaging.Messages.File.File File { get; set; }
        public List<Log> Logs { get; set; }
        public List<Domain.PAY.Critical> Criticals { get; set; }
        public DateTime InclusionDate { get; private set; }

        public CriticalRequest(Guid iDPaymentFeed)
        {
            IDPaymentFeed = iDPaymentFeed;
            File = new Messaging.Messages.File.File();
            Logs = new List<Log>();
            Criticals = new List<Domain.PAY.Critical>();
        }

        public void AddLog(string message)
            => Logs.Add(new Log("CriticalFile Ingest", message, TypeLog.Processing));

        public void AddLogError(string message, string stackTrace = "")        
         =>  Logs.Add(new Log("CriticalFile Ingest", message, TypeLog.Error, stackTrace));
        

        public void SetDate(DateTime inclusionDate)
            => InclusionDate = inclusionDate;

    }
}
