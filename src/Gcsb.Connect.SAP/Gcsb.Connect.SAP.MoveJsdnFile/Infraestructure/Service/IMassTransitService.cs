using Gcsb.Connect.Messaging.Messages.File;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service
{
    public interface IMassTransitService
    {
        Task SendBillToProcess(BillFeedCsv billFeedTsv);
        Task SendPaymentToProcess(PaymentFeedTsv paymentFeedTsv);
        Task SendPaymentBoletoToProcess(PaymentFeedBoletoTsv paymentFeedBoletoTsv);
        Task SendReturnNFToProcess(ReturnNFCsv returnNF);
    }
}
