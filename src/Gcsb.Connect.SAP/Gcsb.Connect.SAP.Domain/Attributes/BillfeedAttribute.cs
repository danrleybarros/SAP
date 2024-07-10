using System;

namespace Gcsb.Connect.SAP.Domain.Attributes
{
    public class BillfeedAttribute: Attribute
    {
        public string NameColumn { get; private set; }

        public BillfeedAttribute(string namecolumn)
        {
            this.NameColumn = namecolumn;
        }
    }
}