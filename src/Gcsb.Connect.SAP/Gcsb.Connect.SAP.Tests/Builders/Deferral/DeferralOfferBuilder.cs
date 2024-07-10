using System;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Tests.Builders.Deferral
{
    public class DeferralOfferBuilder
    {
        public Guid Id;
        public string CycleDate;
        public string ServiceCode;
        public string OfferCode;
        public string CustomerCode;
        public string OrderNumber;
        public string ProviderStoreAcronym;    
        public string InvoiceNumber;
        public string StoreAcronym;
        public string BillingStateOrProvince;
        public string PaymentMethod;
        public string ServiceType;
        public double TotalShortBalance;
        public double TotalLongBalance;
        public double TotalBalance;
        public double InstallmentAmount;
        public int NumberOfInstallments;
        public int DeferredParcels;
        public int CurrentInstallment;
        public bool DeferralStarted;
        public bool DeferralProvisionStarted;
        public bool IsActive;
        public bool IsNFEmitted;
        public bool HasDiscount;
        public bool IsProvisioned;
        public DateTime PurchaseDate;
        public DateTime LastUpdatedDate;
        public DateTime DeferralCreationDate;
        public DeferralStatus DeferralStatus;
        public Guid? BillfeedFileId;
        public int ContractPeriod;
        public DateTime? ExpirationDate;


        public static DeferralOfferBuilder New()
        {
            return new DeferralOfferBuilder
            {
                Id = Guid.NewGuid(),
                CycleDate = "22/02/2022",
                ServiceCode = "34354566",
                OfferCode = "OFFICE",
                CustomerCode = "400778900",
                OrderNumber = "112332442",
                ProviderStoreAcronym = "telerese",              
                NumberOfInstallments = 12,
                TotalShortBalance = 112.2,
                TotalLongBalance = 110.4,
                TotalBalance = 100.0,
                InstallmentAmount = 55.67,
                DeferralStarted = false,
                DeferralProvisionStarted = false,
                DeferredParcels = 0,
                IsActive = false,
                InvoiceNumber = "TLA-1-00000001",
                StoreAcronym = "cloudco",
                IsNFEmitted = false,
                BillingStateOrProvince = "SP",
                PaymentMethod = "Cloudco",
                ServiceType = "SAAS",
                HasDiscount = false,
                PurchaseDate = DateTime.UtcNow,
                IsProvisioned = false,
                CurrentInstallment = 1,
                LastUpdatedDate = DateTime.UtcNow,
                DeferralCreationDate = DateTime.UtcNow,
                DeferralStatus = DeferralStatus.New,
                BillfeedFileId = Guid.NewGuid(),
                ContractPeriod = 12,
                ExpirationDate = null,
            };
        }

        public DeferralOfferBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }

        public DeferralOfferBuilder WithNumberOfInstallments(int numberOfInstallments)
        {
            NumberOfInstallments = numberOfInstallments;
            return this;
        }

        public DeferralOfferBuilder WithIsActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public DeferralOfferBuilder WithIsNFEmitted(bool isNFEmitted)
        {
            IsNFEmitted = isNFEmitted;
            return this;
        }

        public DeferralOfferBuilder WithDeferralStarted(bool deferralStarted)
        {
            DeferralStarted = deferralStarted;
            return this;
        }

        public DeferralOfferBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public DeferralOfferBuilder WithOfferCode(string offerCode)
        {
            OfferCode = offerCode;
            return this;
        }

        public DeferralOfferBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public DeferralOfferBuilder WithTotalShortBalance(double totalShortBalance)
        {
            TotalShortBalance = totalShortBalance;
            return this;
        }

        public DeferralOfferBuilder WithTotalLongBalance(double totalLongBalance)
        {
            TotalLongBalance = totalLongBalance;
            return this;
        }

        public DeferralOfferBuilder WithInstallmentAmount(double installmentAmount)
        {
            InstallmentAmount = installmentAmount;
            return this;
        }

        public DeferralOfferBuilder WithTotalBalance(double totalBalance)
        {
            TotalBalance = totalBalance;
            return this;
        }

        public DeferralOfferBuilder WithHasDiscount(bool hasDiscount)
        {
            HasDiscount = hasDiscount;
            return this;
        }

        public DeferralOfferBuilder WithPurchaseDate(DateTime purchaseDate)
        {
            PurchaseDate = purchaseDate;
            return this;
        }

        public DeferralOfferBuilder WithDeferralProvisionStarted(bool deferralProvisionStarted)
        {
            DeferralProvisionStarted = deferralProvisionStarted;
            return this;
        }

        public DeferralOfferBuilder WithIsProvisioned(bool isProvisioned)
        {
            IsProvisioned = isProvisioned;
            return this;
        }

        public DeferralOfferBuilder WithCurrentInstallment(int currentInstallment)
        {
            CurrentInstallment = currentInstallment;
            return this;
        }

        public DeferralOfferBuilder WithDeferralStatus(DeferralStatus deferralStatus)
        {
            DeferralStatus = deferralStatus;
            return this;
        }
        public DeferralOfferBuilder WithBillfeedFileId(Guid? billfeedFileId)
        {
            BillfeedFileId = billfeedFileId;
            return this;
        }
        
        public DeferralOfferBuilder WithContractPeriod(int contractPeriod)
        {
            ContractPeriod = contractPeriod;
            return this;
        }

        public DeferralOfferBuilder WithExpirationDate(DateTime? expirationDate)
        {
            ExpirationDate = expirationDate;
            return this;
        }

        

        public Domain.Deferral.DeferralOffer Build()
        {
            var deferralOffer = new Domain.Deferral.DeferralOffer(Id,
                                                    CycleDate,
                                                    ServiceCode,
                                                    OfferCode,
                                                    CustomerCode,
                                                    OrderNumber,
                                                    ProviderStoreAcronym,                                                 
                                                    InvoiceNumber,
                                                    StoreAcronym,
                                                    BillingStateOrProvince,
                                                    PaymentMethod,
                                                    ServiceType,
                                                    TotalShortBalance,
                                                    TotalLongBalance,
                                                    TotalBalance,
                                                    InstallmentAmount,
                                                    NumberOfInstallments,                                                  
                                                    DeferralCreationDate,
                                                    PurchaseDate,
                                                    LastUpdatedDate,
                                                    HasDiscount,
                                                    IsProvisioned,
                                                    DeferralStatus,
                                                    ContractPeriod,
                                                    BillfeedFileId,
                                                    ExpirationDate);

            if (DeferralStarted) 
                deferralOffer.StartDeferral();
            deferralOffer.IncomeRecognitionProvision(DeferralProvisionStarted);
            deferralOffer.SetIsNFEmitted(IsNFEmitted);
            deferralOffer.SetIsActive(IsActive);
            deferralOffer.UpdateCurrentInstallment(CurrentInstallment);
            deferralOffer.UpdateIsProvisioned(IsProvisioned);         

            return deferralOffer;

        }
    }
}
