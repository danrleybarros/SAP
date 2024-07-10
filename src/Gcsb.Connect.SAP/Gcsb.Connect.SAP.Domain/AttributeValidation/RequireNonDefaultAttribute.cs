using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.AttributeValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequireNonDefaultAttribute : ValidationAttribute
    {
        public RequireNonDefaultAttribute()
            : base("The {0} field requires a non-default value.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            if (value is null)
                return ValidationResult.Success; //You can flip this if you want. I wanted leave the responsability of null to RequiredAttribute
            var type = value.GetType();

            if(Equals(value, Activator.CreateInstance(Nullable.GetUnderlyingType(type) ?? type)))
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
}
