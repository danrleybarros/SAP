using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public abstract class ARRDomain
    {
        public File File { get; set; }
        
    public ARRDomain(File file)
        {
            this.File = file;            
        }
    }
}
