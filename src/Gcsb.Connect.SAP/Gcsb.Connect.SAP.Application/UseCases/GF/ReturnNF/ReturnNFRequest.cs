using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Deferral;
using System;
using System.Collections.Generic;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF
{
    public class ReturnNFRequest
    {
        private const string service = "ReturnNF";
        private const string NfeFileName = "RETORNO-NF-IND";
        public string Service { get => service; }
        public Dictionary<string, string> NfeFiles { get; private set; }
        public File::File File { get; set; }
        public List<Domain.GF.Nfe.ReturnNF> NFs { get; private set; }
        public int TotalNFs { get; set; }
        public List<Log> Logs { get; set; }
        public Guid BillfeedId { get; set; }
        public DateTime? BillfeedCycleDate { get; set; }
        public List<DeferralOffer> DeferralOffers { get; set; }
        public Guid? BillFeedFileId { get; set; }

        public ReturnNFRequest(TypeRegister typeRegister, string fileDate, Dictionary<string, string> nfeFiles)
        {
            NfeFiles = nfeFiles;
            File = new File::File($"{NfeFileName}-{fileDate}.csv", typeRegister);
            NFs = new List<Domain.GF.Nfe.ReturnNF>();
            Logs = new List<Log>();
        }

        public void AddErrorValidationLog(string service, Guid fileId, string message, List<LogDetail> logDetails, TypeLog typeLog)
            => Logs.Add(new Log(service, fileId, message, logDetails, typeLog));
    }
}
