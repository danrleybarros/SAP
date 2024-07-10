using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IMakeTextFile
    {
        StringBuilder ProcessRequestWithSpace<T>(T model);
        StringBuilder ProcessRequestWithComma<T>(T model);
        void Execute(string str, string strPath);
        StringBuilder ProcessRequestWithoutSpace<T>(T model);
    }
}
