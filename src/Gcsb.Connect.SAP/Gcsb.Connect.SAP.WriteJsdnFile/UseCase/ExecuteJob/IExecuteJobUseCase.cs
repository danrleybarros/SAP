namespace Gcsb.Connect.SAP.WriteJsdnFile.UseCase.ExecuteJob
{
    public interface IExecuteJobUseCase
    {
        bool IsJob { get; }
        void Execute();       
        void SetIsJob(bool isJob);
    }
}
