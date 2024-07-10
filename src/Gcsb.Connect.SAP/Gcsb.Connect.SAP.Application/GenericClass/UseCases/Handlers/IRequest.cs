using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers
{
    public interface IRequest
    {
        TypeRegister TypeInterface { get; set; }
        string FileName { get; set; }
        string OutputFile { get; set; }
        Connect.Messaging.Messages.File.File File { get; set; }
        List<Log> Logs { get; set; }
        void AddLog(string messageLog, TypeLog typeLog);
        void AddLog(string messageLog, string stackTrace);
        string Service { get; }
        Guid IdNFFile { get; set; }
    }
}
