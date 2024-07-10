using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class ISIChainRequest
    {
        private const string service = "IndividualReportService";
        public Guid IdFile { get; set; }
        public List<Domain.GF.IndividualReportService> Lines { get; set; }
        public List<Log> Logs { get; private set; }
        public string ISIDoc { get; set; }
        public Domain.GF.IndividualReportService ISI { get; set; }
        public string ISIFileName { get; set; }
        public bool OutputSuccessfully { get; set; }
        public Connect.Messaging.Messages.File.File ISIFile { get; set; }
        public string Service { get => service; }
        public List<Invoice> Invoices { get; set; }

        public ISIChainRequest(Guid id)
        {
            IdFile = id;
            Lines = new List<Domain.GF.IndividualReportService>();
            Logs = new List<Log>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generation of Individual Report Service Interface", message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface Individual Report Service", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface Individual Report Service", message, TypeLog.Error, stackTrace));
        }
    }
}
