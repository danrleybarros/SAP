using Gcsb.Connect.Messaging.Messages.File;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.Repositories.MassTransitServices
{
    public interface IMassTransitService
    {
        Task SendBillToProcess(BillFeedCsv billFeedTsv);
        Task SendPaymentToProcess(PaymentFeedTsv paymentFeedTsv);
        Task SendPaymentBoletoToProcess(PaymentFeedBoletoTsv paymentFeedBoletoTsv);
        Task SendReturnNFToProcess(ReturnNFCsv returnNF);
    }
}
