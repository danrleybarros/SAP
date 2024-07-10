﻿using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers
{
    public class SequenceHandler : Handler<ARRCreditCard>, ISequenceHandler<ARRCreditCard>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            request.AddProcessingLog("Consulting sequencial file - ARR");

            var stores = request.Services.Select(s => s.Invoice.StoreAcronym).Distinct().ToList();
            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);
                var typeRegister = storeType switch
                {
                    StoreType.TLF2 => TypeRegister.ARRCLOUDCO,
                    _ => TypeRegister.ARR
                };

                var sequenceFile = fileReadOnlyRepository.GetSequentialFileByType(typeRegister);
                request.SequenceFileStore.Add(storeType, (typeRegister, sequenceFile));
            }

            sucessor?.ProcessRequest(request);
        }
    }
}