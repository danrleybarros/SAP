using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client
{
    public interface IClientUseCase
    {
        int Execute(ClientRequest clientRequest);
    }
}
