using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IPaymentFeedReadTsvRepository
    {
        string ReadTsvFile(string path);
    }
}
