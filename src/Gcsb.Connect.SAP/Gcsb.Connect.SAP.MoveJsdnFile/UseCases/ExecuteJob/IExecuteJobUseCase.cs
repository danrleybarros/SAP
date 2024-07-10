using Gcsb.Connect.SAP.MoveJsdnFile.Jobs;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob
{
    public interface IExecuteJobUseCase
    {
        bool IsJob { get; }
        void Execute();
        void DeleteFiles(string pathFiles);
        Configs ReadConfigs();
        void SetIsJob(bool isJob);
    }
}
