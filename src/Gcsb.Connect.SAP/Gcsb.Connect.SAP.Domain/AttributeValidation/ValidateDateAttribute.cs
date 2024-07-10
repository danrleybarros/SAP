using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gcsb.Connect.SAP.Domain.AttributeValidation
{
    public class ValidateDateAttribute : ValidationAttribute
    {
        object[] dates = { DateTime.MinValue.Date, DateTime.MaxValue.Date };

        public ValidateDateAttribute() {}

        public override bool IsValid(object value)
            => !dates.Contains(value);
          
    }
}
