using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical
{
    public interface ICriticaUseCase
    {
        int Execute(CriticaRequest request);
    }
}
