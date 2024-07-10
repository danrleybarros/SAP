using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.AttributeValidation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DocLengthAttribute : ValidationAttribute
    {
        private readonly string docType;
        private readonly int cpfLenght;
        private readonly int cpnjLength;

        public DocLengthAttribute(string docType, int cpfLenght, int cnpjLenght)
        {
            this.docType = docType;
            this.cpfLenght = cpfLenght;
            this.cpnjLength = cnpjLenght;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (string)value;

            var property = validationContext.ObjectType.GetProperty(docType);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var docTypeValue = (string)property.GetValue(validationContext.ObjectInstance);

            switch (docTypeValue.ToUpper())
            {
                case "PJ":
                    if (currentValue.Length > this.cpnjLength)
                        return new ValidationResult(ErrorMessage);
                    else
                        break;
                case "PF":
                    if (currentValue.Length > this.cpfLenght)
                        return new ValidationResult(ErrorMessage);
                    else
                        break;
                default:
                    return new ValidationResult("Invalid Type");
            }

            return ValidationResult.Success;
        }
    }
}
