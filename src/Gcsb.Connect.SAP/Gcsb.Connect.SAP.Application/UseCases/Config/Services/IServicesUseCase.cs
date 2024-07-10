using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.Services
{
    public interface IServicesUseCase
    {
        void Execute(List<string> invoices);
    }
}
