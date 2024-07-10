using System;

using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class FileResult
    {

        public Guid Id { get; private set; }
        public DateTime CycleStartDate { get; private set; }
        public DateTime CycleEndDate { get; private set; }
        public string FileName { get; private set; }
        public DateTime FileCreatedDate { get; private set; }
        public Connect.Messaging.Messages.File.Enum.Status Status { get; private set; }
        public Connect.Messaging.Messages.File.Enum.TypeRegister InterfaceType { get; private set; }
        public string UrlLog { get; private set; }
        public string UrlReprocess { get; set; }
        public bool EnableReprocessing { get; set; }

        public FileResult(Connect.Messaging.Messages.File.File file, string linkLog, string linkReprocess)
        {

            this.Id = file.Id;
            this.CycleStartDate = new DateTime(file.InclusionDate.AddMonths(-1).Year, file.InclusionDate.AddMonths(-1).Month, 1);
            this.CycleEndDate = new DateTime(file.InclusionDate.AddMonths(-1).Year, file.InclusionDate.AddMonths(-1).Month, DateTime.DaysInMonth(file.InclusionDate.AddMonths(-1).Year, file.InclusionDate.AddMonths(-1).Month));
            this.FileName = file.FileName;
            this.FileCreatedDate = file.InclusionDate;
            this.Status = file.Status;
            this.InterfaceType = file.Type;
            this.UrlLog = linkLog.Replace("0", file.Id.ToString());
            this.UrlReprocess = linkReprocess.Replace("0", file.Id.ToString());

        }

   
    }
}
