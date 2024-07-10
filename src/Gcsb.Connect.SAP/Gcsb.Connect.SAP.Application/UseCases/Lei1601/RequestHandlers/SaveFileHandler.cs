using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository, IFileReadOnlyRepository fileReadOnlyRepository, IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(Lei1601Request request)
        {
            request.AddProcessingLog("Saving File on Database Lei 1601");

            request.Files.ForEach(f => fileWriteOnlyRepository.Add(f));

            var paymentIds = request.Lines.GroupBy(g => g.FileId).Select(s => s.Key).ToList();
            var files = fileReadOnlyRepository.GetFiles(w => w.InclusionDate.Date == DateTime.UtcNow.AddDays(-1).Date &&
                                                             (w.Type == TypeRegister.PAYMENTTSV || w.Type == TypeRegister.PAYMENTBOLETOTSV) &&
                                                             !paymentIds.Contains(w.Id));
            files.ForEach(f =>
            {
                var isEmpty = false;
                if (f.Type == TypeRegister.PAYMENTBOLETOTSV)
                    isEmpty = !paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(w => w.Id == f.Id).Any();
                else
                    isEmpty = !paymentFeedReadOnlyRepository.GetPaymentFeedCredit(w => w.Id == f.Id).Any();

                if (isEmpty)
                    paymentIds.AddRange(files.Select(s => s.Id).ToList());
            });


            paymentIds.ForEach(id => fileWriteOnlyRepository.UpdateParentId(id, request.Lei.File.Id));

            sucessor?.ProcessRequest(request);
        }

    }
}
