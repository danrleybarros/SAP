using System;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Application.UseCases.Deferral
{
    public class DeferralRequest
    {
        public Guid IdBillfeed { get; set; }      
        public List<DeferralOffer> DeferralOffers { get; set; }
        public List<Log> Logs { get; set; }

        public DeferralRequest(Guid IdBillfeed)
        {
            this.IdBillfeed = IdBillfeed;                  
            this.DeferralOffers = new List<DeferralOffer>();
            this.Logs = new List<Log>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Deferral", message, TypeLog.Processing));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Deferral", message, TypeLog.Error, stackTrace));
        }
    }
}
