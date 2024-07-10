using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain
{
    public class GFAttribute: Attribute
    {
        public string Name { get; set; }

        public GFAttribute(string name)
        {
            this.Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MaxLengthTruncate : MaxLengthAttribute
    {
        public MaxLengthTruncate(int Length) : base(Length)
        {}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valuestr = value?.ToString().Substring(0, Math.Min(value.ToString().Length, Length));

            if (valuestr != value.ToString())
                validationContext
                    .ObjectType
                    .GetProperty(validationContext.MemberName)
                    .SetValue(validationContext.ObjectInstance, valuestr, null);

            return ValidationResult.Success;
        }
    }
}
