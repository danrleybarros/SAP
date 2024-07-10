using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed
{
    public interface IServiceInvoiceReadOnlyRepository
    {
        List<ServiceInvoice> GetServices(string invoiceNumber);

        List<ServiceFilter> GetServices(List<string> invoiceNumber);

        List<ServiceInvoice> GetServices(Expression<Func<ServiceInvoice, bool>> func);

        List<ServiceFilter> GetServicesWithoutActivity(List<string> invoiceNumber, List<string> activities, string subscriptionType);

        List<ServiceFilter> GetServicesWithoutActivity(List<string> invoiceNumber, List<string> activities, List<string> usageAtrributes, string subscriptionType);

        List<ServiceFilter> GetServicesWithActivity(List<string> invoiceNumber, string activity);

        List<ServiceFilter> GetServices(Guid idFilePayment);

        List<ServiceInvoice> GetServices(Guid idFileBillFeed, string individualInvoice);

        List<ServiceFilter> GetServicesBillFeed(Guid idFileBillFeed, string activity);

        List<ServiceFilter> GetPaidServices(Guid idFilePayment);

        List<ServiceFilter> GetPaidServices(Guid idFilePayment, List<string> activities);

        List<ServiceFilter> GetPaidServicesBankSlip(Guid idFilePayment);

        List<ServiceFilter> GetServicesByActivityAndUsageAttributes(List<string> invoiceNumber, List<string> activities, List<string> usageAtrribute, string subscriptionType);
    }
}
