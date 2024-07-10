using System;

namespace Gcsb.Connect.SAP.Domain.Deferral
{
    public class DeferralOffer : IEntity , ICloneable
    {
        public Guid Id { get; private set; }
        public string CycleDate { get; private set; }
        public string ServiceCode { get; private set; }
        public string OfferCode { get; private set; }
        public string CustomerCode { get; private set; }
        public string OrderNumber { get; private set; }
        public string ProviderStoreAcronym { get; private set; }
        public string InvoiceNumber { get; private set; }
        public string StoreAcronym { get; private set; }
        public string BillingStateOrProvince { get; private set; }
        public string PaymentMethod { get; private set; }
        public string ServiceType { get; private set; }
        public double TotalShortBalance { get; private set; }
        public double TotalLongBalance { get; private set; }
        public double TotalBalance { get; private set; }
        public double InstallmentAmount { get; private set; }
        public int NumberOfInstallments { get; private set; }
        public int CurrentInstallment { get; private set; }
        public DateTime DeferralCreationDate { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public bool DeferralStarted { get; private set; }
        public bool IsIncomeRecognized { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsNFEmitted { get; private set; }
        public bool HasDiscount { get; private set; }
        public bool IsProvisioned { get; private set; }
        public bool AlreadyProcessed { get; private set; }
        public DeferralType DeferralType { get; private set; }
        public DeferralStatus DeferralStatus { get; private set; }
        public double PurchaseDays => DateTime.UtcNow.Subtract(PurchaseDate).TotalDays;
        public Guid? BillfeedFileId { get; set; }
        public double RoundedTotalBalance { get; set; }
        public int ContractPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }


        public DeferralOffer(Guid id, string cycleDate, string serviceCode, string offerCode, string customerCode, string orderNumber, string providerStoreAcronym, string invoiceNumber, string storeAcronym, string billingStateOrProvince, string paymentMethod, string serviceType, double totalBalance, int numberOfInstallments, DateTime deferralCreationDate, DateTime purchaseDate, DateTime lastUpdatedDate, bool hasDiscount, bool isProvisioned, DeferralStatus deferralStatus, int contractPeriod, Guid? billfeedFileId = null, DateTime? expirationDate = null)
        {
            Id = id;
            CycleDate = cycleDate;
            ServiceCode = serviceCode;
            OfferCode = offerCode;
            CustomerCode = customerCode;
            OrderNumber = orderNumber;
            ProviderStoreAcronym = providerStoreAcronym;
            InvoiceNumber = invoiceNumber;
            StoreAcronym = storeAcronym;
            BillingStateOrProvince = billingStateOrProvince;
            PaymentMethod = paymentMethod;
            ServiceType = serviceType;
            NumberOfInstallments = numberOfInstallments;
            TotalBalance = totalBalance;
            InstallmentAmount = CalculateInstallmentAmount();
            TotalShortBalance = GetTotalShortBalance();
            TotalLongBalance = GetTotalLongBalance();
            DeferralCreationDate = deferralCreationDate;
            PurchaseDate = purchaseDate;
            LastUpdatedDate = lastUpdatedDate;
            HasDiscount = hasDiscount;
            IsProvisioned = isProvisioned;
            DeferralStatus = deferralStatus;
            BillfeedFileId = billfeedFileId;
            RoundedTotalBalance = GetRoundedTotalBalance();
            ContractPeriod = contractPeriod;
            ExpirationDate = expirationDate;
        }

        public DeferralOffer(Guid id, string cycleDate, string serviceCode, string offerCode, string customerCode, string orderNumber, string providerStoreAcronym, string invoiceNumber, string storeAcronym, string billingStateOrProvince, string paymentMethod, string serviceType, double totalShortBalance, double totalLongBalance, double totalBalance, double installmentAmount, int numberOfInstallments, DateTime deferralCreationDate, DateTime purchaseDate, DateTime lastUpdatedDate, bool hasDiscount, bool isProvisioned, DeferralStatus deferralStatus, int contractPeriod, Guid? billfeedFileId = null, DateTime? expirationDate = null)
        {
            Id = id;
            CycleDate = cycleDate;
            ServiceCode = serviceCode;
            OfferCode = offerCode;
            CustomerCode = customerCode;
            OrderNumber = orderNumber;
            ProviderStoreAcronym = providerStoreAcronym;
            InvoiceNumber = invoiceNumber;
            StoreAcronym = storeAcronym;
            BillingStateOrProvince = billingStateOrProvince;
            PaymentMethod = paymentMethod;
            ServiceType = serviceType;
            InstallmentAmount = installmentAmount;
            TotalShortBalance = totalShortBalance;
            TotalLongBalance = totalLongBalance;
            TotalBalance = totalBalance;
            NumberOfInstallments = numberOfInstallments;
            DeferralCreationDate = deferralCreationDate;
            PurchaseDate = purchaseDate;
            LastUpdatedDate = lastUpdatedDate;
            HasDiscount = hasDiscount;
            IsProvisioned = isProvisioned;
            DeferralStatus = deferralStatus;
            BillfeedFileId = billfeedFileId;
            RoundedTotalBalance = GetRoundedTotalBalance();
            ContractPeriod = contractPeriod;
            ExpirationDate = expirationDate;
        }

        private double CalculateInstallmentAmount()
            => Math.Round(TotalBalance / NumberOfInstallments, 2);

        public double GetInstallmentAmount()
            => CurrentInstallment == NumberOfInstallments - 1 ? Math.Round(InstallmentAmount + GetRoundDifference(), 2) : InstallmentAmount;

        public double GetTotalShortBalance()
            => NumberOfInstallments <= 12 ? TotalBalance : (InstallmentAmount * 12);

        public double GetTotalLongBalance()
            => InstallmentAmount * (NumberOfInstallments - 12);

        private double GetRoundDifference()
            => Math.Round(TotalBalance - RoundedTotalBalance,2);
        
        private double GetRoundedTotalBalance()
            => Math.Round(NumberOfInstallments * InstallmentAmount, 2);

        public void SetIsActive(bool isActive)
            => IsActive = isActive;

        public void SetIsNFEmitted(bool isNFEmitted)
            => IsNFEmitted = isNFEmitted;

        public void SetDeferralType(DeferralType deferralType)
            => DeferralType = deferralType;

        public void SetDeferralStatus(DeferralStatus deferralStatus)
            => DeferralStatus = deferralStatus;

        public void SetInvoiceNumber(string invoiceNumber)
            => InvoiceNumber = invoiceNumber;

        public void StartDeferral()
            => DeferralStarted = true;

        public void IncomeRecognitionProvision(bool isIncomeRecognized = true)
            => IsIncomeRecognized = isIncomeRecognized;

        public void UpdateCurrentInstallment()
            => CurrentInstallment = ++CurrentInstallment;

        public void UpdateCurrentInstallment(int currentInstallment)
            => CurrentInstallment = currentInstallment;

        public void UpdateShortBalance()
            => TotalShortBalance = TotalShortBalance - InstallmentAmount;

        public void UpdateLongBalance()
            => TotalLongBalance = TotalLongBalance - InstallmentAmount;

        public void UpdateDeferralStatus()
        {
            switch (DeferralStatus)
            {
                case DeferralStatus.New:
                    DeferralStatus = DeferralStatus.InProgress;
                    break;
                case DeferralStatus.InProgress:
                    DeferralStatus = (CurrentInstallment == NumberOfInstallments) ? DeferralStatus.Completed : DeferralStatus.InProgress;
                    break;
            }
        }

        public void UpdateIsProvisioned(bool isProvisioned)
            => IsProvisioned = isProvisioned;

        public void SetAsProcessed()
            => AlreadyProcessed = true;

        public string GetDescriptionInstallment()
            => $"{CurrentInstallment}/{NumberOfInstallments}";

        public void SetExpirationDate(DateTime? expirationDate)
            => ExpirationDate = expirationDate;

        public object Clone()
            => MemberwiseClone();
       
    }
}
