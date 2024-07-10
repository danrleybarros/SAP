using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFine;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.InterestAndFine.BillFeed.SendBillFeedProcessed
{
    public class SendBillFeedProcessedUseCase : ISendBillFeedProcessedUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IInterestAndFineRepository interestAndFineRepository;
        public SendBillFeedProcessedUseCase(ILogWriteOnlyRepository logWriteOnlyRepository,
                                            IInterestAndFineRepository interestAndFineRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.interestAndFineRepository = interestAndFineRepository;
        }
        public void Execute(SendBillFeedProcessedUcRequest request)
        {
            try
            {
                var sent = interestAndFineRepository.SendBillFeedProcessed(request.FileName, request.Cycle);

                if (sent)
                    request.AddProcessingLog("BillFeed Processed sent with success");
                else
                    request.AddExceptionLog("BillFeed Processed sent with error", "verify interestfines api: /fines/api/BillFeedProcessed/SendProcessedBillFeedFileName");
            }
            catch (Exception ex)
            {
                request.AddExceptionLog("BillFeed Processed sent with error (exception)", "verify interestfines api: /fines/api/BillFeedProcessed/SendProcessedBillFeedFileName");
                request.AddExceptionLog(ex.Message, ex.StackTrace);
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
