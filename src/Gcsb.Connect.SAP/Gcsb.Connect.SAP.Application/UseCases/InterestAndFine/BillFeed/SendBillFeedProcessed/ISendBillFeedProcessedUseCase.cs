using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.InterestAndFine.BillFeed.SendBillFeedProcessed
{
    public interface ISendBillFeedProcessedUseCase
    {
        void Execute(SendBillFeedProcessedUcRequest request);
    }
}
