namespace Gcsb.Connect.SAP.Application.UseCases.PAS
{
    public class PASRequest 
    {
        public Connect.Messaging.Messages.File.File File { get; private set; }

        public PASRequest(Connect.Messaging.Messages.File.File file)
        {
            this.File = file;
        }
    }
}
