using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice
{
    public interface IGetDetailServiceByInvoiceUseCase
    {
        void Execute(GetDetailServiceByInvoiceRequest request);
    }
}
