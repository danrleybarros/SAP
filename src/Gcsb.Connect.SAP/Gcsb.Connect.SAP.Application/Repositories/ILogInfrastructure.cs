using System;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface ILogInfrastructure
    {
        public void LogException(Exception exception, string message); 
        void LogInformation(string title, string message);
    }
}
