using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class Service
    {
        [Required]
        public string Code { get; private set; }
        [Required]
        public string Name { get; private set; }

        public Service(
            string code,
            string name)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
