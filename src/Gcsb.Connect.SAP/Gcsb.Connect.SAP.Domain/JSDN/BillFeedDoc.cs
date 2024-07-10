using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class BillFeedDoc : IDoc
    {
        //TODO: As propriedades cnpjmarketplace e companynamemarketplace estão temporariamente como constante por ainda não vir pelo arquivo.
        public const string cnpjmarketplace = "36.282.030/5764-86";
        public const string companynamemarketplace = "Cloud Marketlace";
        private string individualInvoice;
        private const string municipalTaxpayerRegistration = "77434";
        private const string cityServiceCode = "1.03";
        private const string specialprocedurenumber = "002/2018";
        private const string cityhallservicedescription = "Descrição acima: Processamento, armazenamento ou hospedagem de dados";

        public Guid Id { get; private set; }

        public Guid IdFile { get; private set; }

        public Guid Sequence { get; private set; }

        [Required]
        public string Marketplace { get; private set; }

        public string ResellerName { get; private set; }

        public string ResellerContactName { get; private set; }

        public string ResellerEmailAddress { get; private set; }

        public string ResellerPhoneNumber { get; private set; }

        public string OrderId { get; private set; }

        public Guid? SubscriptionId { get; private set; }

        public string Activity { get; private set; }

        public string ServiceType { get; private set; }

        public DateTime? OrderCreationDate { get; private set; }

        public DateTime? PurchaseDate { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public string SubscriptionType { get; private set; }

        public DateTime? TermStartDate { get; private set; }

        public DateTime? TermEndDate { get; private set; }

        public string TermDuration { get; private set; }

        public DateTime? NextRenewalDate { get; private set; }

        public string ServiceCancellationDate { get; private set; }

        public DateTime? BillFrom { get; private set; }

        public DateTime? BillTo { get; private set; }

        [Required]
        public string CompanyName { get; private set; }

        public string CustomerCode { get; private set; }

        public DateTime? AccountCreationDate { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string CustomerEmailAddress { get; private set; }

        public string CustomerPhoneNumber { get; private set; }

        public string BillingStreet { get; private set; }

        public string BillingNumber { get; private set; }

        public string BillingComplement { get; private set; }

        public string BillingNeighbourhood { get; private set; }

        public string BillingCity { get; private set; }

        public string BillingStateOrProvince { get; private set; }

        public string BillingZIPcode { get; private set; }

        public string BillingCountry { get; private set; }

        public string BillingCountryCode { get; private set; }

        public string BillingPhoneNumber { get; private set; }

        public string MailingStreet { get; private set; }

        public string MailingNumber { get; private set; }

        public string MailingComplement { get; private set; }

        public string MailingNeighbourhood { get; private set; }

        public string MailingCity { get; private set; }

        public string MailingStateOrProvince { get; private set; }

        public string MailingZIPcode { get; private set; }

        public string MailingCountry { get; private set; }

        public string MailingCountryCode { get; private set; }

        public string MailingPhoneNumber { get; private set; }

        [Required]
        public string CustomerCPF { get; private set; }

        public string CustomerCNPJ { get; private set; }

        public string CustomerStateRegistration { get; private set; }

        public DateTime? InvoiceCreationDate { get; private set; }

        public string ServiceCode { get; private set; }

        public DateTime? DueDate { get; private set; }

        public string StoreCode { get; private set; }

        public string MarketplaceCity { get; private set; }

        public string MarketplaceState { get; private set; }

        public string UserAccountStatus { get; private set; }

        public string Premeditateddefaulter { get; private set; }

        public string ServiceName { get; private set; }

        public string OfferName { get; private set; }

        public string OfferCode { get; private set; }

        public string SalesReferenceCode { get; private set; }

        public string UnitOfMeasure { get; private set; }

        public double? Qty { get; private set; }

        public double? ProRateScale { get; private set; }

        public double? RetailUnitPrice { get; private set; }

        public double? ProRatedRetailPriceUnitPrice { get; private set; }

        public decimal? GrossRetailPrice { get; private set; }

        public double? RetailPriceDiscount { get; private set; }

        public double? ProRatedRetailUnitDiscountedPriceAmount { get; private set; }

        public decimal? TotalRetailPriceDiscountAmount { get; private set; }

        public double? TotalRetailPrice { get; private set; }

        public double? TaxOnTotalRetailPrice { get; private set; }

        public double? GrandTotalRetailPrice { get; private set; }

        public string PromotionCode { get; private set; }

        public string PromotionDuration { get; private set; }

        public double? WholesaleUnitPrice { get; private set; }

        public double? ProRatedWholesaleUnitPrice { get; private set; }

        public string CustomerTransactionCurrency { get; private set; }

        public string VendorCurrency { get; private set; }

        public double? GrossWholesalePrice { get; private set; }

        public double? WholesalePriceDiscount { get; private set; }

        public double? ProRatedWholesaleUnitDiscountedPriceAmount { get; private set; }

        public double? TotalWholesalePriceDiscountAmount { get; private set; }

        public double? TotalWholesalePrice { get; private set; }

        public double? TaxOnTotalWholesalePrice { get; private set; }

        public double? GrandTotalWholesalePrice { get; private set; }

        public string VendorName { get; private set; }

        public double? VendorUnitPrice { get; private set; }

        public double? ProRatedVendorUnitPrice { get; private set; }

        public double? TotalVendorPrice { get; private set; }

        public double? TaxOnTotalVendorPrice { get; private set; }

        public double? GrandTotalVendorPrice { get; private set; }

        public string BillingCycle { get; private set; }

        public string ProrateType { get; private set; }

        public string ProrateOnCancellation { get; private set; }

        public string UsageAttributes { get; private set; }

        public string PaymentMethod { get; private set; }

        public string PaymentStatus { get; private set; }

        public string RefundType { get; private set; }

        public string RefundAmount { get; private set; }

        public string InvoiceNumber { get; private set; }

        public string ResourceId { get; private set; }

        public string ChargeType { get; private set; }

        public string InvoiceStatus { get; private set; }

        [MaxLength(1)]
        public string IndividualInvoice
        {
            get { return individualInvoice; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    individualInvoice = "N";
                else
                    individualInvoice = value.ToLower().Replace("yes", "S").Replace("no", "N");
            }
        }

        [MaxLength(20)]
        public string MunicipalTaxpayerRegistration { get => municipalTaxpayerRegistration; }

        [MaxLength(10)]
        public string CompanyCode { get => GetCompanyCode(); }

        [MaxLength(10)]
        public string AffiliateCode { get; private set; }

        [MaxLength(10)]
        public string CityServiceCode { get => cityServiceCode; }

        [MaxLength(150)]
        public string CityHallServiceDescription { get => cityhallservicedescription; }

        [MaxLength(150)]
        public string SpecialProcedureNumber { get => specialprocedurenumber; }

        public decimal? TaxRateISS { get; private set; }

        public decimal? TotalTaxISS { get; private set; }

        public decimal? TaxRateCOFINS { get; private set; }

        public decimal? TotalTaxCOFINS { get; private set; }

        public decimal? TaxRatePIS { get; private set; }

        public decimal? TotalTaxPIS { get; private set; }

        public decimal? TotalInvoicePrice { get; private set; }

        public string CnpjMarketPlace { get => cnpjmarketplace; }

        public string CompanyNameMarketPlace { get => companynamemarketplace; }

        public string CustomerAcronym { get; private set; }

        public string Segment { get; private set; }

        public DateTime? CycleCode { get; private set; }

        public DateTime? CycleReference { get; private set; }

        public string FinancialStatus { get; private set; }

        public string CommentsCredited { get; private set; }

        public string Receivable { get; private set; }

        public string CpfUserHasMadeCredit { get; private set; }

        public string ProposalNumber { get; private set; }

        public string AdabasCode { get; private set; }

        public string OpportunityId { get; private set; }

        public string QuoteId { get; private set; }

        public string StoreAcronym { get; private set; }

        public double? TotalRetailPriceWithTaxesWithoutDiscount { get; private set; }

        public string ServiceProviderCompanyName { get; private set; }

        public string CNPJServiceProviderCompany { get; private set; }

        public string StoreAcronymServiceProvider { get; private set; }

        public BillFeedDoc(Guid IdFile, Guid sequence, string marketplace, string resellername, string resellercontactname, string reselleremailaddress, string resellerphonenumber, string orderid, Guid? subscriptionid,
            string activity, string servicetype, DateTime? ordercreationdate, DateTime? purchasedate, DateTime? activationdate, string subscriptiontype, DateTime? termstartdate, DateTime? termenddate,
            string termduration, DateTime? nextrenewaldate, string servicecancellationdate, DateTime? billfrom, DateTime? billto, string companyname, string CustomerCode, DateTime? accountcreationdate,
            string firstname, string lastname, string customeremailaddress, string customerphonenumber, string billingstreet, string billingnumber, string billingcomplement, string billingneighbourhood,
            string billingcity, string billingstateorprovince, string billingzipcode, string billingcountry, string billingcountrycode, string billingphonenumber, string mailingstreet, string mailingnumber,
            string mailingcomplement, string mailingneighbourhood, string mailingcity, string mailingstateorprovince, string mailingzipcode, string mailingcountry, string mailingcountrycode, string mailingphonenumber,
            string customercpf, string customercnpj, string customerstateregistration, DateTime? invoicecreationdate, string servicecode, DateTime? duedate, string storecode, string marketplacecity,
            string marketplacestate, string useraccountstatus, string premeditateddefaulter, string servicename, string offername, string offercode, string salesreferencecode, string unitofmeasure, double? qty,
            double? proratescale, double? retailunitprice, double? proratedretailpriceunitprice, decimal? grossretailprice, double? retailpricediscount, double? proratedretailunitdiscountedpriceamount,
            decimal? totalretailpricediscountamount, double? totalretailprice, double? taxontotalretailprice, double? grandtotalretailprice, string promotioncode, string promotionduration, double? wholesaleunitprice,
            double? proratedwholesaleunitprice, string customertransactioncurrency, string vendorcurrency, double? grosswholesaleprice, double? wholesalepricediscount, double? proratedwholesaleunitdiscountedpriceamount,
            double? totalwholesalepricediscountamount, double? totalwholesaleprice, double? taxontotalwholesaleprice, double? grandtotalwholesaleprice, string vendorname, double? vendorunitprice,
            double? proratedvendorunitprice, double? totalvendorprice, double? taxontotalvendorprice, double? grandtotalvendorprice, string billingcycle, string proratetype, string prorateoncancellation,
            string usageattributes, string paymentmethod, string paymentstatus, string refundtype, string refundamount, string invoicenumber, string resourceid, string chargetype, string invoiceStatus, string individualinvoice,
            decimal? taxrateiss, decimal? totaltaxiss, decimal? taxratecofins, decimal? totaltaxcofins, decimal? taxratepis, decimal? totaltaxpis, decimal? totalinvoiceprice, string customeracronym, string segment,
            DateTime? cyclecode, DateTime? cyclereference, string financialstatus, string commentscredited, string receivable, string cpfUserHasMadeCredit, string proposalNumber, string adabasCode, string opportunityId,
            string quoteId, string storeAcronym, double? totalRetailPriceWithTaxesWithoutDiscount, string affiliateCode, string serviceprovidercompanyname, string cnpjserviceprovidercompany, string storeacronymserviceprovider)
        {
            this.Id = Guid.NewGuid();
            this.IdFile = IdFile;
            this.Sequence = sequence;
            this.Marketplace = marketplace;
            this.ResellerName = resellername;
            this.ResellerContactName = resellercontactname;
            this.ResellerEmailAddress = reselleremailaddress;
            this.ResellerPhoneNumber = resellerphonenumber;
            this.OrderId = orderid;
            this.SubscriptionId = subscriptionid;
            this.Activity = activity;
            this.ServiceType = servicetype;
            this.OrderCreationDate = ordercreationdate;
            this.PurchaseDate = purchasedate;
            this.ActivationDate = activationdate;
            this.SubscriptionType = subscriptiontype;
            this.TermStartDate = termstartdate;
            this.TermEndDate = termenddate;
            this.TermDuration = termduration;
            this.NextRenewalDate = nextrenewaldate;
            this.ServiceCancellationDate = servicecancellationdate;
            this.BillFrom = billfrom;
            this.BillTo = billto;
            this.CompanyName = companyname;
            this.CustomerCode = CustomerCode;
            this.AccountCreationDate = accountcreationdate;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.CustomerEmailAddress = customeremailaddress;
            this.CustomerPhoneNumber = customerphonenumber;
            this.BillingStreet = billingstreet;
            this.BillingNumber = billingnumber;
            this.BillingComplement = billingcomplement;
            this.BillingNeighbourhood = billingneighbourhood;
            this.BillingCity = billingcity;
            this.BillingStateOrProvince = billingstateorprovince;
            this.BillingZIPcode = billingzipcode;
            this.BillingCountry = billingcountry;
            this.BillingCountryCode = billingcountrycode;
            this.BillingPhoneNumber = billingphonenumber;
            this.MailingStreet = mailingstreet;
            this.MailingNumber = mailingnumber;
            this.MailingComplement = mailingcomplement;
            this.MailingNeighbourhood = mailingneighbourhood;
            this.MailingCity = mailingcity;
            this.MailingStateOrProvince = mailingstateorprovince;
            this.MailingZIPcode = mailingzipcode;
            this.MailingCountry = mailingcountry;
            this.MailingCountryCode = mailingcountrycode;
            this.MailingPhoneNumber = mailingphonenumber;
            this.CustomerCPF = customercpf;
            this.CustomerCNPJ = customercnpj;
            this.CustomerStateRegistration = customerstateregistration;
            this.InvoiceCreationDate = invoicecreationdate;
            this.ServiceCode = servicecode;
            this.DueDate = duedate;
            this.StoreCode = storecode;
            this.MarketplaceCity = marketplacecity;
            this.MarketplaceState = marketplacestate;
            this.UserAccountStatus = useraccountstatus;
            this.Premeditateddefaulter = premeditateddefaulter;
            this.ServiceName = servicename;
            this.OfferName = offername;
            this.OfferCode = offercode;
            this.SalesReferenceCode = salesreferencecode;
            this.UnitOfMeasure = unitofmeasure;
            this.Qty = qty;
            this.ProRateScale = proratescale;
            this.RetailUnitPrice = retailunitprice;
            this.ProRatedRetailPriceUnitPrice = proratedretailpriceunitprice;
            this.GrossRetailPrice = grossretailprice;
            this.RetailPriceDiscount = retailpricediscount;
            this.ProRatedRetailUnitDiscountedPriceAmount = proratedretailunitdiscountedpriceamount;
            this.TotalRetailPriceDiscountAmount = totalretailpricediscountamount;
            this.TotalRetailPrice = totalretailprice;
            this.TaxOnTotalRetailPrice = taxontotalretailprice;
            this.GrandTotalRetailPrice = grandtotalretailprice;
            this.PromotionCode = promotioncode;
            this.PromotionDuration = promotionduration;
            this.WholesaleUnitPrice = wholesaleunitprice;
            this.ProRatedWholesaleUnitPrice = proratedwholesaleunitprice;
            this.CustomerTransactionCurrency = customertransactioncurrency;
            this.VendorCurrency = vendorcurrency;
            this.GrossWholesalePrice = grosswholesaleprice;
            this.WholesalePriceDiscount = wholesalepricediscount;
            this.ProRatedWholesaleUnitDiscountedPriceAmount = proratedwholesaleunitdiscountedpriceamount;
            this.TotalWholesalePriceDiscountAmount = totalwholesalepricediscountamount;
            this.TotalWholesalePrice = totalwholesaleprice;
            this.TaxOnTotalWholesalePrice = taxontotalwholesaleprice;
            this.GrandTotalWholesalePrice = grandtotalwholesaleprice;
            this.VendorName = vendorname;
            this.VendorUnitPrice = vendorunitprice;
            this.ProRatedVendorUnitPrice = proratedvendorunitprice;
            this.TotalVendorPrice = totalvendorprice;
            this.TaxOnTotalVendorPrice = taxontotalvendorprice;
            this.GrandTotalVendorPrice = grandtotalvendorprice;
            this.BillingCycle = billingcycle;
            this.ProrateType = proratetype;
            this.ProrateOnCancellation = prorateoncancellation;
            this.UsageAttributes = usageattributes;
            this.PaymentMethod = paymentmethod;
            this.PaymentStatus = paymentstatus;
            this.RefundType = refundtype;
            this.RefundAmount = refundamount;
            this.InvoiceNumber = invoicenumber;
            this.ResourceId = resourceid;
            this.ChargeType = chargetype;
            this.InvoiceStatus = invoiceStatus;
            this.IndividualInvoice = individualinvoice;
            this.TaxRateISS = taxrateiss;
            this.TotalTaxISS = totaltaxiss;
            this.TaxRateCOFINS = taxratecofins;
            this.TotalTaxCOFINS = totaltaxcofins;
            this.TaxRatePIS = taxratepis;
            this.TotalTaxPIS = totaltaxpis;
            this.TotalInvoicePrice = totalinvoiceprice;
            this.CustomerAcronym = customeracronym;
            this.Segment = segment;
            this.CycleCode = cyclecode;
            this.CycleReference = cyclereference;
            this.FinancialStatus = financialstatus;
            this.CommentsCredited = commentscredited;
            this.Receivable = receivable;
            this.CpfUserHasMadeCredit = cpfUserHasMadeCredit;
            this.ProposalNumber = proposalNumber;
            this.AdabasCode = adabasCode;
            this.OpportunityId = opportunityId;
            this.QuoteId = quoteId;
            this.StoreAcronym = storeAcronym;
            this.TotalRetailPriceWithTaxesWithoutDiscount = totalRetailPriceWithTaxesWithoutDiscount;
            this.AffiliateCode = affiliateCode;
            this.ServiceProviderCompanyName = serviceprovidercompanyname;
            this.CNPJServiceProviderCompany = cnpjserviceprovidercompany;
            this.StoreAcronymServiceProvider = storeacronymserviceprovider;
        }

        public long MountCustomerCode()
            => long.Parse($"7{this.CustomerCode.ToString().PadLeft(9, '0')}");

        public void SetGrandTotalRetailPrice(double? value)
            => GrandTotalRetailPrice = value;

        public DateTime? SetBillTo(DateTime? value)
            => BillTo = value;

        public DateTime? SetBillFrom(DateTime? value)
            => BillFrom = value;

        private string GetCompanyCode()
        {
            if (StoreAcronym.ToLower() == "telerese")
                return "TBRA";
            if (StoreAcronym.ToLower() == "cloudco")
                return "TLF2";
            if (StoreAcronym.ToLower() == "iotco")
                return "IOT0";
            else 
                return "";
        }
    }
} 

