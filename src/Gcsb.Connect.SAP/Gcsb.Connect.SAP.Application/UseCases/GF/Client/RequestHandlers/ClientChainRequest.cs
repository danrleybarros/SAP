using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class ClientChainRequest
    {
        private const string service = "ClientReport";
        public Guid IdFile { get; private set; }

        public List<Log> Logs { get; private set; }

        public List<Domain.GF.Client> Clients { get; set; }

        public string ClientText { get; set; }

        public Connect.Messaging.Messages.File.File ClientFile { get; set; }

        public string FileName { get; set; }

        public bool OutputFileSuccessfully { get; set; }

        public string Service { get => service; }

        public List<CepOutput> Address { get; set; }

        public List<Customer> Customers{ get; set; }

        public ClientChainRequest(Guid idfile)
        {
            this.IdFile = idfile;
            this.Logs = new List<Log>();
            this.Address = new List<CepOutput>();
            this.Customers = new List<Customer>();
        }
    }
}