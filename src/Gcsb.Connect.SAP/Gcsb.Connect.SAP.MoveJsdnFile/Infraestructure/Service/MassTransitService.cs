using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service
{
    public class MassTransitService : IMassTransitService
    {
        private readonly IPublisher<PaymentFeedTsv> publisherPayment;
        private readonly IPublisher<PaymentFeedBoletoTsv> publisherPaymentBoleto;
        private readonly IPublisher<BillFeedCsv> publisherBill;
        private readonly IPublisher<ReturnNFCsv> publisherReturnNF;

        public MassTransitService(IPublisher<PaymentFeedTsv> publisherPayment, IPublisher<PaymentFeedBoletoTsv> publisherPaymentBoleto, 
            IPublisher<BillFeedCsv> publisherBill, IPublisher<ReturnNFCsv> PublisherReturnNF)
        {
            this.publisherPayment = publisherPayment;
            this.publisherPaymentBoleto = publisherPaymentBoleto;
            this.publisherBill = publisherBill;
            this.publisherReturnNF = PublisherReturnNF;
        }

        public async Task SendPaymentToProcess(PaymentFeedTsv paymentFeedTsv)
        {
            await publisherPayment.PublishAsync(paymentFeedTsv);
        }

        public async Task SendPaymentBoletoToProcess(PaymentFeedBoletoTsv paymentFeedBoletoTsv)
        {
            await publisherPaymentBoleto.PublishAsync(paymentFeedBoletoTsv);
        }

        public async Task SendBillToProcess(BillFeedCsv billFeedTsv)
        {
            await publisherBill.PublishAsync(billFeedTsv);
        }

        public async Task SendReturnNFToProcess(ReturnNFCsv returnNF)
        {
            await publisherReturnNF.PublishAsync(returnNF);
        }

    }
}
