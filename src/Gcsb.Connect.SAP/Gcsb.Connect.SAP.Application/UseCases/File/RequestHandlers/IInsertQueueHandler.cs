namespace Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers
{
    public interface IInsertQueueHandler
    {      
        void FileReprocess(Connect.Messaging.Messages.File.File file);
    }
}
