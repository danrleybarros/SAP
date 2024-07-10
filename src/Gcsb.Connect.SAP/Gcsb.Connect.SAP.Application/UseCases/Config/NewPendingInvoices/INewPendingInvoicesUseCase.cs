using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices
{
    public interface INewPendingInvoicesUseCase
    {
        void Execute(NewPendingInvoicesRequest request);
    }
}
