using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Domain.PAS
{
    public class PAS
    {
        public Header Header { get; private set; }
        public List<Body> Lines { get; private set; }
        public Footer Footer { get; set; }
        public PAS(DateTime generationDate, List<Body> lines, StoreType storeType)
        {
            Header = new Header(storeType);

            if (lines == null || !lines.Any())
            {
                throw new ArgumentNullException("Lines of PAS");
            }

            this.Lines = lines;
            this.Footer = new Footer(lines.Count);
            int i = 1;
            foreach (var item in Lines)
            {
                item.LineNumber = i;
                i++;
            }
        }
    }
}
