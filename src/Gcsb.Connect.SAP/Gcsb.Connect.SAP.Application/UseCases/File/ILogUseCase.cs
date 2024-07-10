using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public interface ILogUseCase
    {
         List<LogResult> Execute(LogRequest request);
    }
}
