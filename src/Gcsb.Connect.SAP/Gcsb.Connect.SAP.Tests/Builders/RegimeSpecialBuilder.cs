using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class RegimeEspecialBuilder
    {
        public Guid FileIdBillFeed;
        public List<ServiceInvoice> Services;
        public List<JsdnStore> Stores;
        public List<Domain.GF.SpecialRegime> SpecialRegimes;
        public List<Messaging.Messages.File.File> Files;
        public Dictionary<StoreType, Guid> RegimeFiles;
        public List<Log> Logs;
        public bool OutputSuccessfully;
        public string Service;

        public static RegimeEspecialBuilder New()
        {
            return new RegimeEspecialBuilder()
            {
                FileIdBillFeed = new Guid("b7bdc23c-6a04-11e9-b4a6-fa168e5d6a87"),
                Services = new List<ServiceInvoice>(),
                Stores = new List<JsdnStore>(),
                Files = new List<Messaging.Messages.File.File>(),
                SpecialRegimes = new List<Domain.GF.SpecialRegime>(),
                RegimeFiles = new Dictionary<StoreType, Guid>(),
                Logs = new List<Log>(),
                OutputSuccessfully = true,
                Service = "Ofice365"
            };
        }

        public RegimeEspecialBuilder WithFileIdBillFeed(Guid fileIdBillFeed)
        {
            FileIdBillFeed = fileIdBillFeed;
            return this;
        }

        public RegimeEspecialBuilder WithServices(List<ServiceInvoice> services)
        {
            Services = services;
            return this;
        }

        public RegimeEspecialBuilder WithStore(List<JsdnStore> stores)
        {
            Stores = stores;
            return this;
        }
        public RegimeEspecialBuilder WithFiles(List<Messaging.Messages.File.File> files)
        {
            Files = files;
            return this;
        }

        public RegimeEspecialBuilder WithSpecialRegimes(List<Domain.GF.SpecialRegime> specialRegimes)
        {
            SpecialRegimes = specialRegimes;
            return this;
        }


        public RegimeEspecialBuilder WithRegimesFile(Dictionary<StoreType, Guid> regimeFiles)
        {
            RegimeFiles = regimeFiles;
            return this;
        }

        public RegimeEspecialBuilder WithLogs(List<Log> logs)
        {
            Logs = logs;
            return this;
        }

        public RegimeEspecialBuilder WithOutputSuccessfully(bool outputSuccessfully)
        {
            OutputSuccessfully =outputSuccessfully;
            return this;
        }

        public RegimeEspecialBuilder WithService(string service)
        {
            Service = service;
            return this;
        }

        public RegimeEspecialBuilder Build()
        {
            return new RegimeEspecialBuilder();
        }
    }
}
