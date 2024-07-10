using Gcsb.Connect.SAP.Domain;
using GW_FSW_SAP.Domain;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IIntegrationSAPReadOnlyRepository
    {
        List<Guid> ReadNewData();

        Client GetClient(Guid idRegister);

        PaymentInformation GetPayment(Guid idRegister);

        InvoiceDetail GetInvoice(Guid idRegister);
    }
}
