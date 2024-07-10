using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.Utils
{
    class LogInfrastructure : ILogInfrastructure
    {
        public void LogException(Exception exception, string message)
        {
            Serilog.Log.Error(exception, message);
        }

        public void LogInformation(string title, string message)
        {
            Serilog.Log.Information(title, message);
        }
    }
}
