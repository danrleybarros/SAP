﻿using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class GetPaymetFeedHandler : Handler<ARRCreditCardInter>, IGetPaymetFeedHandler<ARRCreditCardInter>
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;
        private readonly IJsdnRepository jsdnRepository;

        public GetPaymetFeedHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository, IJsdnRepository jsdnRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            var invoices = request.Services.Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();

            request.AddProcessingLog("Consulting PaymentFeed - ARR Intercompany Credit Card");
            request.paymentCreditCards = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(invoices);
            request.PaymentReports = jsdnRepository.GetPaymentReportsByInvoices(invoices);

            if (request.paymentCreditCards.Count == 0 || request.PaymentReports.Count == 0)
                throw new ArgumentNullException("List of Payment Feed - Credit Card is empty");

            sucessor?.ProcessRequest(request);
        }
    }
}
