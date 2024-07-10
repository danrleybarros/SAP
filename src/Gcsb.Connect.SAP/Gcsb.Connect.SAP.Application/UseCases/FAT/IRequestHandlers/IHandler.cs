using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers
{
    public interface IHandler
    {
        void SetSucessor(IHandler sucessor);
        void ProcessRequest(FATRequest request);
    }
}
