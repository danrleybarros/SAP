using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Domain.FAT.FATBase
{
    public abstract class FAT : IFAT.IFAT
    {
        public List<ILaunch> Launchs { get; set; }
		public Messaging.Messages.File.File File { get; set; }
        public IIdentificationRecord IdentificationRecord { get; set; }
        public Header Header { get; set; }
        public Footer Footer { get; set; }

        public FAT(
                IIdentificationRecord identificationrecord,
                Header header,
                List<ILaunch> launchs,
                File file)
        {
            this.File = file;
            this.IdentificationRecord = identificationrecord;
            this.Header = header;

            if (launchs == null)
            {
                throw new ArgumentNullException("Launch object of FAT is null");
            }

            this.Launchs = launchs;

            var total = Launchs.Where(w => !w.IsDiscount).Sum(l => l.LaunchValue) - Launchs.Where(w => w.IsDiscount).Sum(l => l.LaunchValue);

            this.Footer = new Footer(launchs.Count, total);
            int i = 1;
            foreach (var item in Launchs)
            {
                item.NumberLine = i;
                i++;
            }
        }
    }
}
