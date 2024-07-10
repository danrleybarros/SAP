using System;
using FluentValidation;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.Validator.Extension.Deferral;

namespace Gcsb.Connect.SAP.Domain.Validator.Deferral
{
    public class DeferralHistoryValidator : AbstractValidator<DeferralHistory>
    {
        public DeferralHistoryValidator()
        {
            RuleFor(d => d.Id).NotEqual(default(Guid));
            RuleFor(d => d.OrderId).NotEmpty().NotNull();
            RuleFor(d => d.OrderCreationDate).NotEqual(default(DateTime));
            RuleFor(d => d.CompanyName).NotEmpty().NotNull();
            RuleFor(d => d.ServiceName).NotEmpty().NotNull();
            RuleFor(d => d.ServiceCode).NotEmpty().NotNull();
            RuleFor(d => d.GrandTotalRetailPrice).GreaterThan(0);
            RuleFor(d => d.TotalRetailPrice).GreaterThan(0);
            RuleFor(d => d.Receivable).NotEmpty().NotNull();
            RuleFor(d => d.PaymentMethod).NotEmpty().NotNull();
            RuleFor(d => d.PaymentOption).NotEmpty().NotNull().ValidatePaymentOption();
            RuleFor(d => d.CostCenter).NotEmpty().NotNull().ValidateCostCenter();
            RuleFor(d => d.InternalOrder).NotEmpty().NotNull();
            RuleFor(d => d.BusinessLocation).ValidateBusinesslocation();
            RuleFor(d => d.FilialCode).ValidateFilialCode();
            RuleFor(d => d.UF).NotEmpty().NotNull();
            RuleFor(d => d.ServiceType).NotEmpty().NotNull();
            RuleFor(d => d.ProductStatus).NotEmpty().NotNull();
            RuleFor(d => d.FinancialAccount).NotEmpty().NotNull();
            RuleFor(d => d.NumberOfInstallments).NotEmpty().NotNull();
            RuleFor(d => d.DeferralDescriptionInstallment).NotEmpty().NotNull();
            RuleFor(d => d.ContractDeadline).NotEmpty().NotNull(); ;
            RuleFor(d => d.DateStartedContract).NotEqual(default(DateTime));
            RuleFor(d => d.StoreAcronymServiceProvider).NotEmpty().NotNull();
            RuleFor(d => d.CnpjServiceProviderCompany).NotEmpty().NotNull();
            RuleFor(d => d.NumberOfInstallments).NotEqual(default(int));
            RuleFor(d => d.DeferralType).IsInEnum();
           
        }
    }
}
