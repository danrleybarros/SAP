using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain
{
    public class FormatAttribute : Attribute
    {
        public string Format { get; set; }

        public FormatAttribute(string format)
        {
            this.Format = format;
        }
    }
}
