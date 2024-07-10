using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Gcsb.Connect.SAP.Domain.Validator.Extension.Deferral
{
    public static class DeferralHistoryValidatorExtensions
    {
        readonly record struct BusinessLocation(string name);
        readonly record struct CostCenter(string name);

        private const string businesslocationTBRA = "3574";
        private const string businesslocationCloudCO = "0107";
        private const string costCenterTBRA = "GW29TR018233";
        private const string costCenterCloudCO = "GW29CR018200";
        private const string paymentOption = "pós-pago";
        private const string filialCode = "29SP";

        public static IRuleBuilderOptions<T, TProperty> ValidatePaymentOption<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder) 
            => ruleBuilder.Must(p => p.ToString().ToLower().Equals(paymentOption.ToLower())).WithMessage("'{PropertyName}' Inválido");

        public static IRuleBuilderOptions<T, TProperty> ValidateFilialCode<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
          => ruleBuilder.Must(p => p.ToString().ToLower().Equals(filialCode.ToLower())).WithMessage("'{PropertyName}' Inválido");

        public static IRuleBuilderOptions<T, TProperty> ValidateBusinesslocation<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
           => ruleBuilder.Must(p => IsValidBusinessLocation(p?.ToString())).WithMessage("'{PropertyName}' Inválido");

        public static IRuleBuilderOptions<T, TProperty> ValidateCostCenter<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
          => ruleBuilder.Must(p => IsValidCostCenter(p?.ToString())).WithMessage("'{PropertyName}' Inválido");

        private static bool IsValidBusinessLocation(string value)
            => new List<BusinessLocation> { new BusinessLocation(businesslocationTBRA), new BusinessLocation(businesslocationCloudCO) }.Any(a=> a.name == value);

        private static bool IsValidCostCenter(string value)
           => new List<CostCenter> { new CostCenter(costCenterTBRA), new CostCenter(costCenterCloudCO) }.Any(a => a.name == value);

    }
}
