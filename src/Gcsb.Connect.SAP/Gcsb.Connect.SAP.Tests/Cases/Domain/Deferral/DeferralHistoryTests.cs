using System;
using FluentAssertions;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.Lei1601;
using Gcsb.Connect.SAP.Tests.Builders.Deferral;
using Renci.SshNet.Messages;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Deferral
{
    public class DeferralHistoryTests
    {
        #region Should create domain valid

        [Fact]
        public void ShouldCreateDomainValidWithSucess()
        {
            var domain = DeferralHistoryBuilder.New().Build();

            domain.Valid.Should().BeTrue();


        }
        #endregion

        #region Should be required 

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredOrderId(string orderId)
        {
            var domain = DeferralHistoryBuilder.New().WithOrderId(orderId).Build();

            domain.Valid.Should().BeFalse();

        }

        [Fact]
        public void ShouldBeRequiredOrderCreationDate()
        {
            var domain = DeferralHistoryBuilder.New().WithOrderCreationDate(default(DateTime)).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredCompanyName(string companyName)
        {
            var domain = DeferralHistoryBuilder.New().WithCompanyName(companyName).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredServiceName(string serviceName)
        {
            var domain = DeferralHistoryBuilder.New().WithServiceName(serviceName).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredServiceCode(string serviceCode)
        {
            var domain = DeferralHistoryBuilder.New().WithServiceCode(serviceCode).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(default(double))]
        public void ShouldBeRequiredGrandTotalRetailPrice(double grandTotalRetailPrice)
        {
            var domain = DeferralHistoryBuilder.New().WithGrandTotalRetailPrice(grandTotalRetailPrice).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(default(double))]
        public void ShouldBeRequiredTotalRetailPrice(double totalRetailPrice)
        {
            var domain = DeferralHistoryBuilder.New().WithTotalRetailPrice(totalRetailPrice).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredReceivable(string receivable)
        {
            var domain = DeferralHistoryBuilder.New().WithReceivable(receivable).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredPaymentMethod(string paymentMethod)
        {
            var domain = DeferralHistoryBuilder.New().WithPaymentMethod(paymentMethod).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredInternalOrder(string internalOrder)
        {
            var domain = DeferralHistoryBuilder.New().WithInternalOrder(internalOrder).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredUF(string uf)
        {
            var domain = DeferralHistoryBuilder.New().WithUf(uf).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredServiceType(string serviceType)
        {
            var domain = DeferralHistoryBuilder.New().WithServiceType(serviceType).Build();

            domain.Valid.Should().BeFalse();
        }      

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredFinancialAccount(string financialAccount)
        {
            var domain = DeferralHistoryBuilder.New().WithFinancialAccount(financialAccount).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(default(int))]
        public void ShouldBeRequiredNumberOfInstallments(int numberOfInstallments)
        {
            var domain = DeferralHistoryBuilder.New().WithNumberOfInstallments(numberOfInstallments).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredDeferralDescriptionInstallment(string deferralDescriptionInstallment)
        {
            var domain = DeferralHistoryBuilder.New().WithDeferralDescriptionInstallment(deferralDescriptionInstallment).Build();

            domain.Valid.Should().BeFalse();
        }

        [Fact]       
        public void ShouldBeRequiredDateStartedContract()
        {
            var domain = DeferralHistoryBuilder.New().WithDateStartedContract(default(DateTime)).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredStoreAcronymServiceProvider(string storeAcronymServiceProvider)
        {
            var domain = DeferralHistoryBuilder.New().WithStoreAcronymServiceProvider(storeAcronymServiceProvider).Build();

            domain.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ShouldBeRequiredCnpjServiceProviderCompany(string cnpjServiceProviderCompany)
        {
            var domain = DeferralHistoryBuilder.New().WithCnpjServiceProviderCompany(cnpjServiceProviderCompany).Build();

            domain.Valid.Should().BeFalse();
        }   

        #endregion

        #region Should validate constants

        [Theory]
        [InlineData("pós-pago")]
        public void ShouldValidatePaymentOptionWithSucess(string paymentOption)
        {
            var domain = DeferralHistoryBuilder.New().Build();

            domain.Valid.Should().BeTrue();
            domain.PaymentOption.Should().Be(paymentOption);
        }

        [Theory]
        [InlineData("GW29TR018233", "telerese")]
        [InlineData("GW29CR018200", "cloudco")]
        public void ShouldValidateCostCenterWithSucess(string costCenter, string store)
        {
            var domain = DeferralHistoryBuilder.New().WithStoreAcronymServiceProvider(store).Build();

            domain.Valid.Should().BeTrue();
            domain.CostCenter.Should().Be(costCenter);
        }

        [Theory]
        [InlineData("3574", "telerese")]
        [InlineData("0107", "cloudco")]
        public void ShouldValidateBusinessLocationWithSucess(string businessLocation, string store)
        {
            var domain = DeferralHistoryBuilder.New().WithStoreAcronymServiceProvider(store).Build();

            domain.Valid.Should().BeTrue();
            domain.BusinessLocation.Should().Be(businessLocation);
        }

        [Theory]
        [InlineData("29SP")]
        public void ShouldValidateFilialCodeWithSucess(string filialCode)
        {
            var domain = DeferralHistoryBuilder.New().Build();

            domain.Valid.Should().BeTrue();
            domain.FilialCode.Should().Be(filialCode);
        }

        #endregion
    }
}
