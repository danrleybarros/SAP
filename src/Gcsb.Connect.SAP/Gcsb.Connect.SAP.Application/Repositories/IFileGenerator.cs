using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IFileGenerator<T>
    {
        bool ValidateModel(T model);

        string Generate(T model);

        void SaveFile(string str, string path, string fileName);
    }
}
