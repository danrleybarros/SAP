using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.AttributeValidation
{
    public class ValidIE : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string ie = value as string;
            var property = validationContext.ObjectType.GetProperty("UnformattedCPForCNPJ");
            if (property == null)
                throw new ArgumentException("Property with this name not found.");

            string cpfCnpj = property.GetValue(validationContext.ObjectInstance) as string ?? "";

            // Se for cnpj e não houver IE, deve vir ISENTO
            if (cpfCnpj.Length > 11 && string.IsNullOrEmpty(ie))
                return new ValidationResult(ErrorMessageString);

            // Se for cpf não deve haver IE
            if (cpfCnpj.Length <= 11 && !string.IsNullOrEmpty(ie))
                return new ValidationResult(ErrorMessageString);

            return ValidationResult.Success;
        }
    }
}
