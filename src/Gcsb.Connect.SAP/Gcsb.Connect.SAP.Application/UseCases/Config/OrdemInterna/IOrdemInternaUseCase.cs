using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.OrdemInterna
{
    public interface IOrdemInternaUseCase
    {
        void Execute(OrdemInternaRequest request);
    }
}
