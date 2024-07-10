using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook
{
    public class AxiliaryBookRequest
    {
        public Guid IdFileReturnNF { get; private set; }
        public List<Domain.GF.AxiliaryBook> LaunchItems { get; private set; }
        public Connect.Messaging.Messages.File.File File { get; set; }
        public List<Domain.GF.Nfe.ReturnNF> ReturnNFs { get; set; }
        public List<Log> Logs { get; set; }
        public string FileName { get; internal set; }
        public List<FinancialAccount> FinancialAccounts { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<ServiceInvoice> Services { get; set; }


        public AxiliaryBookRequest(Guid idFileReturnNF)
        {
            IdFileReturnNF = idFileReturnNF;
            LaunchItems = new List<Domain.GF.AxiliaryBook>();
            File = new Connect.Messaging.Messages.File.File();
            ReturnNFs = new List<Domain.GF.Nfe.ReturnNF>();
            Logs = new List<Log>();
            FinancialAccounts = new List<FinancialAccount>();
            Invoices = new List<Invoice>();
            Services = new List<ServiceInvoice>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface AxiliaryBook", message, TypeLog.Processing));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {
            Logs.Add(new Log("Generate Interface AxiliaryBook", fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(string message, List<LogDetail> logDetails)
        {
            Logs.Add(new Log("Generate Interface AxiliaryBook", message, logDetails, TypeLog.Error));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface AxiliaryBook", message, TypeLog.Error, stackTrace));
        }
    }
}
