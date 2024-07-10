using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class FileBuilder
    {
        public Guid Id;
        public string FileName;
        public DateTime InclusionDate;
        public Status Status;        
        public List<IDoc> Docs;
        public TypeRegister Type;
        public List<Log> Logs;
        public Guid IdParent;

        public static FileBuilder New()
        {
            return new FileBuilder
            {
                Id = Guid.NewGuid(),
                IdParent = Guid.NewGuid(),
                FileName = "ARR20190101.csv",
                InclusionDate = DateTime.UtcNow,
                Status = Status.Error,                
                Docs = new List<IDoc>(),
                Type = TypeRegister.ARR,
                Logs = new List<Log>()
            };
        }

        public FileBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public FileBuilder WithFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public FileBuilder WithIncluisonDate(DateTime date)
        {
            InclusionDate = date;
            return this;
        }

        public FileBuilder WithStatus(Status status)
        {
            Status = status;
            return this;
        }

        public FileBuilder WithType(TypeRegister type)
        {
            Type = type;
            return this;
        }

        public FileBuilder WithLogs(List<Log> logs)
        {
            Logs = logs;
            return this;
        }
        public FileBuilder WithIdParent(Guid idParent)
        {
            IdParent = idParent;
            return this;
        }

        public File Build()
        {
            return new File(Id,
                            IdParent,
                            FileName, 
                            Type, 
                            InclusionDate,
                            Status,                            
                            //Docs,
                            Logs
            );
        }
    }
}
