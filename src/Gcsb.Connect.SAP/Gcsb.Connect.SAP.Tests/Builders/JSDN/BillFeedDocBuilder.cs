using Gcsb.Connect.SAP.Domain.JSDN;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class BillFeedDocBuilder
    {
        public Guid IdFile;
        public Guid Sequence;
        public string Marketplace;
        public string ResellerName;
        public string ResellerContactName;
        public string ResellerEmailAddress;
        public string ResellerPhoneNumber;
        public string OrderId;
        public Guid SubscriptionId;
        public string Activity;
        public string ServiceType;
        public DateTime? OrderCreationDate;
        public DateTime? PurchaseDate;
        public DateTime? ActivationDate;
        public string SubscriptionType;
        public DateTime? TermStartDate;
        public DateTime? TermEndDate;
        public string TermDuration;
        public DateTime? NextRenewalDate;
        public string ServiceCancellationDate;
        public DateTime? BillFrom;
        public DateTime? BillTo;
        public string CompanyName;
        public string CompanyAcronym;
        public DateTime? AccountCreationDate;
        public string FirstName;
        public string LastName;
        public string CustomerEmailAddress;
        public string CustomerPhoneNumber;
        public string BillingStreet;
        public string BillingNumber;
        public string BillingComplement;
        public string BillingNeighbourhood;
        public string BillingCity;
        public string BillingStateOrProvince;
        public string BillingZIPcode;
        public string BillingCountry;
        public string BillingCountryCode;
        public string BillingPhoneNumber;
        public string MailingStreet;
        public string MailingNumber;
        public string MailingComplement;
        public string MailingNeighbourhood;
        public string MailingCity;
        public string MailingStateOrProvince;
        public string MailingZIPcode;
        public string MailingCountry;
        public string MailingCountryCode;
        public string MailingPhoneNumber;
        public string CustomerCPF;
        public string CustomerCNPJ;
        public string CustomerStateRegistration;
        public DateTime InvoiceCreationDate;
        public string ServiceCode;
        public DateTime? DueDate;
        public string StoreCode;
        public string MarketplaceCity;
        public string MarketplaceState;
        public string UserAccountStatus;
        public string Premeditateddefaulter;
        public string ServiceName;
        public string OfferName;
        public string OfferCode;
        public string SalesReferenceCode;
        public string UnitOfMeasure;
        public double? Qty;
        public double? ProRateScale;
        public double? RetailUnitPrice;
        public double? ProRatedRetailPriceUnitPrice;
        public decimal? GrossRetailPrice;
        public double? RetailPriceDiscount;
        public double? ProRatedRetailUnitDiscountedPriceAmount;
        public decimal? TotalRetailPriceDiscountAmount;
        public double? TotalRetailPrice;
        public double? TaxOnTotalRetailPrice;
        public double? GrandTotalRetailPrice;
        public string PromotionCode;
        public string PromotionDuration;
        public double? WholesaleUnitPrice;
        public double? ProRatedWholesaleUnitPrice;
        public string CustomerTransactionCurrency;
        public string VendorCurrency;
        public double? GrossWholesalePrice;
        public double? WholesalePriceDiscount;
        public double? ProRatedWholesaleUnitDiscountedPriceAmount;
        public double? TotalWholesalePriceDiscountAmount;
        public double? TotalWholesalePrice;
        public double? TaxOnTotalWholesalePrice;
        public double? GrandTotalWholesalePrice;
        public string VendorName;
        public double? VendorUnitPrice;
        public double? ProRatedVendorUnitPrice;
        public double? TotalVendorPrice;
        public double? TaxOnTotalVendorPrice;
        public double? GrandTotalVendorPrice;
        public string BillingCycle;
        public string ProrateType;
        public string ProrateOnCancellation;
        public string UsageAttributes;
        public string PaymentMethod;
        public string PaymentStatus;
        public string RefundType;
        public string RefundAmount;
        public string InvoiceNumber;
        public string ResourceId;
        public string ChargeType;
        public string InvoiceStatus;
        public string IndividualInvoice;
        public decimal? TaxRateISS;
        public decimal? TotalTaxISS;
        public decimal? TaxRateCOFINS;
        public decimal? TotalTaxCOFINS;
        public decimal? TaxRatePIS;
        public decimal? TotalTaxPIS;
        public decimal? TotalInvoicePrice;
        public string CustomerAcronym;
        public string Segment;
        public DateTime? CycleCode;
        public DateTime? CycleReference;
        public string FinancialStatus;
        public string CommentsCredited;
        public string Receivable;
        public string CpfUserHasMadeCredit;
        public string ProposalNumber;
        public string AdabasCode;
        public string OpportunityId;
        public string QuoteId;
        public string StoreAcronym;
        public double? TotalRetailPriceWithTaxesWithoutDiscount;
        public string AffiliateCode;
        public string ServiceProviderCompanyName;
        public string CNPJServiceProviderCompany;
        public string StoreAcronymServiceProvider;

        public static BillFeedDocBuilder New()
        {
            return new BillFeedDocBuilder
            {
                Sequence = new Guid("c263349a-5bd9-11e8-b927-005056a70009"),
                Marketplace = "clrmp",
                ResellerName = "clrstore",
                ResellerContactName = "clrstore admin",
                ResellerEmailAddress = "clrstore@gmail.com",
                ResellerPhoneNumber = "3435436547",
                OrderId = "4010507",
                SubscriptionId = new Guid("89ea161f-9867-427e-a28c-3b77246a39f0"),
                Activity = "Usage",
                ServiceType = "IAAS",
                OrderCreationDate = new DateTime(15 / 05 / 2018),
                PurchaseDate = new DateTime(15 / 05 / 2018),
                ActivationDate = new DateTime(15 / 05 / 2018),
                SubscriptionType = "USAGE",
                TermStartDate = DateTime.UtcNow,
                TermEndDate = DateTime.UtcNow,
                TermDuration = "1 Year",
                NextRenewalDate = DateTime.UtcNow,
                ServiceCancellationDate = "",
                BillFrom = new DateTime(15 / 05 / 2018),
                BillTo = new DateTime(17 / 05 / 2018),
                CompanyName = "customer FN",
                CompanyAcronym = "customerFN",
                AccountCreationDate = new DateTime(14 / 05 / 2018),
                FirstName = "customer FN",
                LastName = "admin LN",
                CustomerEmailAddress = "cust2432@gmail.com",
                CustomerPhoneNumber = "342543",
                BillingStreet = "R. Arduino teste",
                BillingNumber = "23A",
                BillingComplement = "Casa 4",
                BillingNeighbourhood = "Jd. Imperio",
                BillingCity = "São Paulo",
                BillingStateOrProvince = "São Paulo",
                BillingZIPcode = "05797-200",
                BillingCountry = "Brazil",
                BillingCountryCode = "+55",
                BillingPhoneNumber = "(011) 99999-0000",
                MailingStreet = "Rua do Sul",
                MailingNumber = "78B",
                MailingComplement = "Apt. 88",
                MailingNeighbourhood = "Jd. dos testes",
                MailingCity = "São Paulo",
                MailingStateOrProvince = "São Paulo",
                MailingZIPcode = "0666-666",
                MailingCountry = "Brazil",
                MailingCountryCode = "+55",
                MailingPhoneNumber = "(12) 98765-4321",
                CustomerCPF = "444.444.444-44",
                CustomerCNPJ = "49.911.798/0001-12",
                CustomerStateRegistration = "São paulo",
                InvoiceCreationDate = new DateTime(14 / 05 / 2018),
                ServiceCode = "JAM01",
                DueDate = new DateTime(14 / 05 / 2018),
                StoreCode = "Store",
                MarketplaceCity = "Belo Horinzote",
                MarketplaceState = "Minas Gerais",
                UserAccountStatus = "Active",
                Premeditateddefaulter = "No",
                ServiceName = "Amazon Subscription Service_1",
                OfferName = "AWS Subscription Offer",
                OfferCode = "awssubscriptionoffer",
                SalesReferenceCode = "",
                UnitOfMeasure = "",
                Qty = 73,
                ProRateScale = 0,
                RetailUnitPrice = 0,
                ProRatedRetailPriceUnitPrice = 0,
                GrossRetailPrice = 0,
                RetailPriceDiscount = 0,
                ProRatedRetailUnitDiscountedPriceAmount = 0,
                TotalRetailPriceDiscountAmount = 0,
                TotalRetailPrice = 0,
                TaxOnTotalRetailPrice = 0,
                GrandTotalRetailPrice = 0,
                PromotionCode = "",
                PromotionDuration = "0",
                WholesaleUnitPrice = 0,
                ProRatedWholesaleUnitPrice = 0,
                CustomerTransactionCurrency = "USD",
                VendorCurrency = "USD",
                GrossWholesalePrice = 0,
                WholesalePriceDiscount = 0,
                ProRatedWholesaleUnitDiscountedPriceAmount = 0,
                TotalWholesalePriceDiscountAmount = 0,
                TotalWholesalePrice = 0,
                TaxOnTotalWholesalePrice = 0,
                GrandTotalWholesalePrice = 0,
                VendorName = "Amazon Web Services",
                VendorUnitPrice = 0,
                ProRatedVendorUnitPrice = 0,
                TotalVendorPrice = 0,
                TaxOnTotalVendorPrice = 0,
                GrandTotalVendorPrice = 0,
                BillingCycle = "Month",
                ProrateType = "",
                ProrateOnCancellation = "",
                UsageAttributes = "awskms",
                PaymentMethod = "us-east-1-KMS-Requests",
                PaymentStatus = "Pre-Approved Credit",
                RefundType = "Paid",
                RefundAmount = "",
                InvoiceNumber = "cre-1-00000028",
                ResourceId = "NA",
                ChargeType = "Usage",
                InvoiceStatus = "InvoiceStatusTest",
                IndividualInvoice = "S",
                TaxRateISS = 2.00m,
                TotalTaxISS = 0.20m,
                TaxRateCOFINS = 2.00m,
                TotalTaxCOFINS = 0.20m,
                TaxRatePIS = 2.00m,
                TotalTaxPIS = 0.20m,
                TotalInvoicePrice = 1.35m,
                CustomerAcronym = "vishalqajc",
                Segment = "Massive",
                CycleCode = DateTime.UtcNow,
                CycleReference = DateTime.UtcNow,
                FinancialStatus = "Defaulter",
                CommentsCredited = "",
                Receivable = "SPnewazurecspsubscriptionservice",
                CpfUserHasMadeCredit = "989.661.310-93",
                ProposalNumber = "123456",
                AdabasCode = "8045965",
                OpportunityId = "00656000008T0ORAA0",
                QuoteId = "0Q063000000CvT8CAK",
                StoreAcronym = "telerese",
                TotalRetailPriceWithTaxesWithoutDiscount = 10,
                AffiliateCode = "9141",
                ServiceProviderCompanyName = "Telefônica Brasil S.A",
                CNPJServiceProviderCompany = "02.558.157/0001-62",
                StoreAcronymServiceProvider = "telerese",
            };
        }

        public BillFeedDocBuilder WithSequence(Guid sequence)
        {
            Sequence = sequence;
            return this;
        }

        public BillFeedDocBuilder WithMarketplace(string marketplace)
        {
            Marketplace = marketplace;
            return this;
        }

        public BillFeedDocBuilder WithResellerName(string resellername)
        {
            ResellerName = resellername;
            return this;
        }

        public BillFeedDocBuilder WithResellerContactName(string resellercontactname)
        {
            ResellerContactName = resellercontactname;
            return this;
        }

        public BillFeedDocBuilder WithResellerEmailAddress(string reselleremailaddress)
        {
            ResellerEmailAddress = reselleremailaddress;
            return this;
        }

        public BillFeedDocBuilder WithResellerPhoneNumber(string resellerphonenumber)
        {
            ResellerPhoneNumber = resellerphonenumber;
            return this;
        }

        public BillFeedDocBuilder WithOrderId(string orderid)
        {
            OrderId = orderid;
            return this;
        }

        public BillFeedDocBuilder WithSubscriptionId(Guid subscriptionid)
        {
            SubscriptionId = subscriptionid;
            return this;
        }

        public BillFeedDocBuilder WithActivity(string activity)
        {
            Activity = activity;
            return this;
        }

        public BillFeedDocBuilder WithServiceType(string servicetype)
        {
            ServiceType = servicetype;
            return this;
        }

        public BillFeedDocBuilder WithOrderCreationDate(DateTime? ordercreationdate)
        {
            OrderCreationDate = ordercreationdate;
            return this;
        }

        public BillFeedDocBuilder WithPurchaseDate(DateTime? purchasedate)
        {
            PurchaseDate = purchasedate;
            return this;
        }

        public BillFeedDocBuilder WithActivationDate(DateTime? activationdate)
        {
            ActivationDate = activationdate;
            return this;
        }

        public BillFeedDocBuilder WithSubscriptionType(string subscriptiontype)
        {
            SubscriptionType = subscriptiontype;
            return this;
        }

        public BillFeedDocBuilder WithTermStartDate(DateTime? termstartdate)
        {
            TermStartDate = termstartdate;
            return this;
        }

        public BillFeedDocBuilder WithTermEndDate(DateTime? termenddate)
        {
            TermEndDate = termenddate;
            return this;
        }

        public BillFeedDocBuilder WithTermDuration(string termduration)
        {
            TermDuration = termduration;
            return this;
        }

        public BillFeedDocBuilder WithNextRenewalDate(DateTime? nextrenewaldate)
        {
            NextRenewalDate = nextrenewaldate;
            return this;
        }

        public BillFeedDocBuilder WithServiceCancellationDate(string servicecancellationdate)
        {
            ServiceCancellationDate = servicecancellationdate;
            return this;
        }

        public BillFeedDocBuilder WithBillFrom(DateTime? billfrom)
        {
            BillFrom = billfrom;
            return this;
        }

        public BillFeedDocBuilder WithBillTo(DateTime? billto)
        {
            BillTo = billto;
            return this;
        }

        public BillFeedDocBuilder WithCompanyName(string companyname)
        {
            CompanyName = companyname;
            return this;
        }

        public BillFeedDocBuilder WithCompanyAcronym(string companyacronym)
        {
            CompanyAcronym = companyacronym;
            return this;
        }

        public BillFeedDocBuilder WithAccountCreationDate(DateTime? accountcreationdate)
        {
            AccountCreationDate = accountcreationdate;
            return this;
        }

        public BillFeedDocBuilder WithFirstName(string firstname)
        {
            FirstName = firstname;
            return this;
        }

        public BillFeedDocBuilder WithLastName(string lastname)
        {
            LastName = lastname;
            return this;
        }

        public BillFeedDocBuilder WithCustomerEmailAddress(string customeremailaddress)
        {
            CustomerEmailAddress = customeremailaddress;
            return this;
        }

        public BillFeedDocBuilder WithCustomerPhoneNumber(string customerphonenumber)
        {
            CustomerPhoneNumber = customerphonenumber;
            return this;
        }

        public BillFeedDocBuilder WithBillingStreet(string billingstreet)
        {
            BillingStreet = billingstreet;
            return this;
        }

        public BillFeedDocBuilder WithBillingNumber(string billingnumber)
        {
            BillingNumber = billingnumber;
            return this;
        }

        public BillFeedDocBuilder WithBillingComplement(string billingcomplement)
        {
            BillingComplement = billingcomplement;
            return this;
        }

        public BillFeedDocBuilder WithBillingNeighbourhood(string billingneighbourhood)
        {
            BillingNeighbourhood = billingneighbourhood;
            return this;
        }

        public BillFeedDocBuilder WithBillingCity(string billingcity)
        {
            BillingCity = billingcity;
            return this;
        }

        public BillFeedDocBuilder WithBillingStateOrProvince(string billingstateorprovince)
        {
            BillingStateOrProvince = billingstateorprovince;
            return this;
        }

        public BillFeedDocBuilder WithBillingZIPcode(string billingzipcode)
        {
            BillingZIPcode = billingzipcode;
            return this;
        }

        public BillFeedDocBuilder WithBillingCountry(string billingcountry)
        {
            BillingCountry = billingcountry;
            return this;
        }

        public BillFeedDocBuilder WithBillingCountryCode(string billingcountrycode)
        {
            BillingCountryCode = billingcountrycode;
            return this;
        }

        public BillFeedDocBuilder WithBillingPhoneNumber(string billingphonenumber)
        {
            BillingPhoneNumber = billingphonenumber;
            return this;
        }

        public BillFeedDocBuilder WithMailingStreet(string mailingstreet)
        {
            MailingStreet = mailingstreet;
            return this;
        }

        public BillFeedDocBuilder WithMailingNumber(string mailingnumber)
        {
            MailingNumber = mailingnumber;
            return this;
        }

        public BillFeedDocBuilder WithMailingComplement(string mailingcomplement)
        {
            MailingComplement = mailingcomplement;
            return this;
        }

        public BillFeedDocBuilder WithMailingNeighbourhood(string mailingneighbourhood)
        {
            MailingNeighbourhood = mailingneighbourhood;
            return this;
        }

        public BillFeedDocBuilder WithMailingCity(string mailingcity)
        {
            MailingCity = mailingcity;
            return this;
        }

        public BillFeedDocBuilder WithMailingStateOrProvince(string mailingstateorprovince)
        {
            MailingStateOrProvince = mailingstateorprovince;
            return this;
        }

        public BillFeedDocBuilder WithMailingZIPcode(string mailingzipcode)
        {
            MailingZIPcode = mailingzipcode;
            return this;
        }

        public BillFeedDocBuilder WithMailingCountry(string mailingcountry)
        {
            MailingCountry = mailingcountry;
            return this;
        }

        public BillFeedDocBuilder WithMailingCountryCode(string mailingcountrycode)
        {
            MailingCountryCode = mailingcountrycode;
            return this;
        }

        public BillFeedDocBuilder WithMailingPhoneNumber(string mailingphonenumber)
        {
            MailingPhoneNumber = mailingphonenumber;
            return this;
        }

        public BillFeedDocBuilder WithCustomerCPF(string customercpf)
        {
            CustomerCPF = customercpf;
            return this;
        }

        public BillFeedDocBuilder WithCustomerCNPJ(string customercnpj)
        {
            CustomerCNPJ = customercnpj;
            return this;
        }

        public BillFeedDocBuilder WithCustomerStateRegistration(string customerstateregistration)
        {
            CustomerStateRegistration = customerstateregistration;
            return this;
        }

        public BillFeedDocBuilder WithInvoiceCreationDate(DateTime invoicecreationdate)
        {
            InvoiceCreationDate = invoicecreationdate;
            return this;
        }

        public BillFeedDocBuilder WithServiceCode(string servicecode)
        {
            ServiceCode = servicecode;
            return this;
        }

        public BillFeedDocBuilder WithDueDate(DateTime? duedate)
        {
            DueDate = duedate;
            return this;
        }

        public BillFeedDocBuilder WithStoreCode(string storecode)
        {
            StoreCode = storecode;
            return this;
        }

        public BillFeedDocBuilder WithMarketplaceCity(string marketplacecity)
        {
            MarketplaceCity = marketplacecity;
            return this;
        }

        public BillFeedDocBuilder WithMarketplaceState(string marketplacestate)
        {
            MarketplaceState = marketplacestate;
            return this;
        }

        public BillFeedDocBuilder WithUserAccountStatus(string useraccountstatus)
        {
            UserAccountStatus = useraccountstatus;
            return this;
        }

        public BillFeedDocBuilder WithPremeditateddefaulter(string premeditateddefaulter)
        {
            Premeditateddefaulter = premeditateddefaulter;
            return this;
        }

        public BillFeedDocBuilder WithServiceName(string servicename)
        {
            ServiceName = servicename;
            return this;
        }

        public BillFeedDocBuilder WithOfferName(string offername)
        {
            OfferName = offername;
            return this;
        }

        public BillFeedDocBuilder WithOfferCode(string offercode)
        {
            OfferCode = offercode;
            return this;
        }

        public BillFeedDocBuilder WithSalesReferenceCode(string salesreferencecode)
        {
            SalesReferenceCode = salesreferencecode;
            return this;
        }

        public BillFeedDocBuilder WithUnitOfMeasure(string unitofmeasure)
        {
            UnitOfMeasure = unitofmeasure;
            return this;
        }

        public BillFeedDocBuilder WithQty(double? qty)
        {
            Qty = qty;
            return this;
        }

        public BillFeedDocBuilder WithProRateScale(double? proratescale)
        {
            ProRateScale = proratescale;
            return this;
        }

        public BillFeedDocBuilder WithRetailUnitPrice(double? retailunitprice)
        {
            RetailUnitPrice = retailunitprice;
            return this;
        }

        public BillFeedDocBuilder WithProRatedRetailPriceUnitPrice(double? proratedretailpriceunitprice)
        {
            ProRatedRetailPriceUnitPrice = proratedretailpriceunitprice;
            return this;
        }

        public BillFeedDocBuilder WithGrossRetailPrice(decimal? grossretailprice)
        {
            GrossRetailPrice = grossretailprice;
            return this;
        }

        public BillFeedDocBuilder WithRetailPriceDiscount(double? retailpricediscount)
        {
            RetailPriceDiscount = retailpricediscount;
            return this;
        }

        public BillFeedDocBuilder WithProRatedRetailUnitDiscountedPriceAmount(double? proratedretailunitdiscountedpriceamount)
        {
            ProRatedRetailUnitDiscountedPriceAmount = proratedretailunitdiscountedpriceamount;
            return this;
        }

        public BillFeedDocBuilder WithTotalRetailPriceDiscountAmount(decimal? totalretailpricediscountamount)
        {
            TotalRetailPriceDiscountAmount = totalretailpricediscountamount;
            return this;
        }

        public BillFeedDocBuilder WithTotalRetailPrice(double? totalretailprice)
        {
            TotalRetailPrice = totalretailprice;
            return this;
        }

        public BillFeedDocBuilder WithTaxOnTotalRetailPrice(double? taxontotalretailprice)
        {
            TaxOnTotalRetailPrice = taxontotalretailprice;
            return this;
        }

        public BillFeedDocBuilder WithGrandTotalRetailPrice(double? grandtotalretailprice)
        {
            GrandTotalRetailPrice = grandtotalretailprice;
            return this;
        }

        public BillFeedDocBuilder WithPromotionCode(string promotioncode)
        {
            PromotionCode = promotioncode;
            return this;
        }

        public BillFeedDocBuilder WithPromotionDuration(string promotionduration)
        {
            PromotionDuration = promotionduration;
            return this;
        }

        public BillFeedDocBuilder WithWholesaleUnitPrice(double? wholesaleunitprice)
        {
            WholesaleUnitPrice = wholesaleunitprice;
            return this;
        }

        public BillFeedDocBuilder WithProRatedWholesaleUnitPrice(double? proratedwholesaleunitprice)
        {
            ProRatedWholesaleUnitPrice = proratedwholesaleunitprice;
            return this;
        }

        public BillFeedDocBuilder WithCustomerTransactionCurrency(string customertransactioncurrency)
        {
            CustomerTransactionCurrency = customertransactioncurrency;
            return this;
        }

        public BillFeedDocBuilder WithVendorCurrency(string vendorcurrency)
        {
            VendorCurrency = vendorcurrency;
            return this;
        }

        public BillFeedDocBuilder WithGrossWholesalePrice(double? grosswholesaleprice)
        {
            GrossWholesalePrice = grosswholesaleprice;
            return this;
        }

        public BillFeedDocBuilder WithWholesalePriceDiscount(double? wholesalepricediscount)
        {
            WholesalePriceDiscount = wholesalepricediscount;
            return this;
        }

        public BillFeedDocBuilder WithProRatedWholesaleUnitDiscountedPriceAmount(double? proratedwholesaleunitdiscountedpriceamount)
        {
            ProRatedWholesaleUnitDiscountedPriceAmount = proratedwholesaleunitdiscountedpriceamount;
            return this;
        }

        public BillFeedDocBuilder WithTotalWholesalePriceDiscountAmount(double? totalwholesalepricediscountamount)
        {
            TotalWholesalePriceDiscountAmount = totalwholesalepricediscountamount;
            return this;
        }

        public BillFeedDocBuilder WithTotalWholesalePrice(double? totalwholesaleprice)
        {
            TotalWholesalePrice = totalwholesaleprice;
            return this;
        }

        public BillFeedDocBuilder WithTaxOnTotalWholesalePrice(double? taxontotalwholesaleprice)
        {
            TaxOnTotalWholesalePrice = taxontotalwholesaleprice;
            return this;
        }

        public BillFeedDocBuilder WithGrandTotalWholesalePrice(double? grandtotalwholesaleprice)
        {
            GrandTotalWholesalePrice = grandtotalwholesaleprice;
            return this;
        }

        public BillFeedDocBuilder WithVendorName(string vendorname)
        {
            VendorName = vendorname;
            return this;
        }

        public BillFeedDocBuilder WithVendorUnitPrice(double? vendorunitprice)
        {
            VendorUnitPrice = vendorunitprice;
            return this;
        }

        public BillFeedDocBuilder WithProRatedVendorUnitPrice(double? proratedvendorunitprice)
        {
            ProRatedVendorUnitPrice = proratedvendorunitprice;
            return this;
        }

        public BillFeedDocBuilder WithTotalVendorPrice(double? totalvendorprice)
        {
            TotalVendorPrice = totalvendorprice;
            return this;
        }

        public BillFeedDocBuilder WithTaxOnTotalVendorPrice(double? taxontotalvendorprice)
        {
            TaxOnTotalVendorPrice = taxontotalvendorprice;
            return this;
        }

        public BillFeedDocBuilder WithGrandTotalVendorPrice(double? grandtotalvendorprice)
        {
            GrandTotalVendorPrice = grandtotalvendorprice;
            return this;
        }

        public BillFeedDocBuilder WithBillingCycle(string billingcycle)
        {
            BillingCycle = billingcycle;
            return this;
        }

        public BillFeedDocBuilder WithProrateType(string proratetype)
        {
            ProrateType = proratetype;
            return this;
        }

        public BillFeedDocBuilder WithProrateOnCancellation(string prorateoncancellation)
        {
            ProrateOnCancellation = prorateoncancellation;
            return this;
        }

        public BillFeedDocBuilder WithUsageAttributes(string usageattributes)
        {
            UsageAttributes = usageattributes;
            return this;
        }

        public BillFeedDocBuilder WithPaymentMethod(string paymentmethod)
        {
            PaymentMethod = paymentmethod;
            return this;
        }

        public BillFeedDocBuilder WithPaymentStatus(string paymentstatus)
        {
            PaymentStatus = paymentstatus;
            return this;
        }

        public BillFeedDocBuilder WithRefundType(string refundtype)
        {
            RefundType = refundtype;
            return this;
        }

        public BillFeedDocBuilder WithRefundAmount(string refundamount)
        {
            RefundAmount = refundamount;
            return this;
        }

        public BillFeedDocBuilder WithInvoiceNumber(string invoicenumber)
        {
            InvoiceNumber = invoicenumber;
            return this;
        }

        public BillFeedDocBuilder WithResourceId(string resourceid)
        {
            ResourceId = resourceid;
            return this;
        }

        public BillFeedDocBuilder WithChargeType(string chargetype)
        {
            ChargeType = chargetype;
            return this;
        }

        public BillFeedDocBuilder WithIndividualInvoice(string individualinvoice)
        {
            IndividualInvoice = individualinvoice;
            return this;
        }

        public BillFeedDocBuilder WithTaxRateISS(decimal? taxrateiss)
        {
            TaxRateISS = taxrateiss;
            return this;
        }

        public BillFeedDocBuilder WithTotalTaxISS(decimal? totaltaxiss)
        {
            TotalTaxISS = totaltaxiss;
            return this;
        }

        public BillFeedDocBuilder WithTaxRateCOFINS(decimal? taxratecofins)
        {
            TaxRateCOFINS = taxratecofins;
            return this;
        }

        public BillFeedDocBuilder WithTotalTaxCOFINS(decimal? totaltaxcofins)
        {
            TotalTaxCOFINS = totaltaxcofins;
            return this;
        }

        public BillFeedDocBuilder WithTaxRatePIS(decimal? taxratepis)
        {
            TaxRatePIS = taxratepis;
            return this;
        }

        public BillFeedDocBuilder WithTotalTaxPIS(decimal? totaltaxpis)
        {
            TotalTaxPIS = totaltaxpis;
            return this;
        }

        public BillFeedDocBuilder WithTotalInvoicePrice(decimal? totalinvoiceprice)
        {
            TotalInvoicePrice = totalinvoiceprice;
            return this;
        }

        public BillFeedDocBuilder WithCustomerAcronym(string customeracronym)
        {
            CustomerAcronym = customeracronym;
            return this;
        }

        public BillFeedDocBuilder WithSegment(string segment)
        {
            Segment = segment;
            return this;
        }

        public BillFeedDocBuilder WithCycleCode(DateTime? cyclecode)
        {
            CycleCode = cyclecode;
            return this;
        }

        public BillFeedDocBuilder WithCycleReference(DateTime? cyclereference)
        {
            CycleReference = cyclereference;
            return this;
        }

        public BillFeedDocBuilder WithFinancialStatus(string financialstatus)
        {
            FinancialStatus = financialstatus;
            return this;
        }

        public BillFeedDocBuilder WithCommentsCredited(string commentscredited)
        {
            CommentsCredited = commentscredited;
            return this;
        }

        public BillFeedDocBuilder WithReceivable(string receivable)
        {
            Receivable = receivable;
            return this;
        }

        public BillFeedDocBuilder WithCpfUserHasMadeCredit(string cpfUserHasMadeCredit)
        {
            CpfUserHasMadeCredit = cpfUserHasMadeCredit;
            return this;
        }

        public BillFeedDocBuilder WithProposalNumber(string proposalNumber)
        {
            ProposalNumber = proposalNumber;
            return this;
        }

        public BillFeedDocBuilder WithAdabasCode(string adabasCode)
        {
            AdabasCode = adabasCode;
            return this;
        }

        public BillFeedDocBuilder WithOpportunityId(string opportunityId)
        {
            OpportunityId = opportunityId;
            return this;
        }

        public BillFeedDocBuilder WithQuoteId(string quoteId)
        {
            QuoteId = quoteId;
            return this;
        }

        public BillFeedDocBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public BillFeedDocBuilder WithTotalRetailPriceWithTaxesWithoutDiscount(double totalRetailPriceWithTaxesWithoutDiscount)
        {
            TotalRetailPriceWithTaxesWithoutDiscount = totalRetailPriceWithTaxesWithoutDiscount;
            return this;
        }

        public BillFeedDocBuilder WithAffiliateCode(string affiliateCode)
        {
            AffiliateCode = affiliateCode;
            return this;
        }

        public BillFeedDocBuilder WithServiceProviderCompanyName(string serviceprovidercompanyname)
        {
            ServiceProviderCompanyName = serviceprovidercompanyname;
            return this;
        }

        public BillFeedDocBuilder WithCNPJServiceProviderCompany(string cnpjserviceprovidercompany)
        {
            CNPJServiceProviderCompany = cnpjserviceprovidercompany;
            return this;
        }

        public BillFeedDocBuilder WithStoreAcronymServiceProvider(string storeacronymserviceprovider)
        {
            StoreAcronymServiceProvider = storeacronymserviceprovider;
            return this;
        }

        public BillFeedDoc Build()
        {
            return new BillFeedDoc(IdFile, Sequence, Marketplace, ResellerName, ResellerContactName, ResellerEmailAddress, ResellerPhoneNumber, OrderId, SubscriptionId, Activity, ServiceType, OrderCreationDate,
                PurchaseDate, ActivationDate, SubscriptionType, TermStartDate, TermEndDate, TermDuration, NextRenewalDate, ServiceCancellationDate, BillFrom, BillTo, CompanyName, CompanyAcronym, AccountCreationDate,
                FirstName, LastName, CustomerEmailAddress, CustomerPhoneNumber, BillingStreet, BillingNumber, BillingComplement, BillingNeighbourhood, BillingCity, BillingStateOrProvince, BillingZIPcode, BillingCountry,
                BillingCountryCode, BillingPhoneNumber, MailingStreet, MailingNumber, MailingComplement, MailingNeighbourhood, MailingCity, MailingStateOrProvince, MailingZIPcode, MailingCountry, MailingCountryCode,
                MailingPhoneNumber, CustomerCPF, CustomerCNPJ, CustomerStateRegistration, InvoiceCreationDate, ServiceCode, DueDate, StoreCode, MarketplaceCity, MarketplaceState, UserAccountStatus, Premeditateddefaulter,
                ServiceName, OfferName, OfferCode, SalesReferenceCode, UnitOfMeasure, Qty, ProRateScale, RetailUnitPrice, ProRatedRetailPriceUnitPrice, GrossRetailPrice, RetailPriceDiscount, ProRatedRetailUnitDiscountedPriceAmount,
                TotalRetailPriceDiscountAmount, TotalRetailPrice, TaxOnTotalRetailPrice, GrandTotalRetailPrice, PromotionCode, PromotionDuration, WholesaleUnitPrice, ProRatedWholesaleUnitPrice, CustomerTransactionCurrency,
                VendorCurrency, GrossWholesalePrice, WholesalePriceDiscount, ProRatedWholesaleUnitDiscountedPriceAmount, TotalWholesalePriceDiscountAmount, TotalWholesalePrice, TaxOnTotalWholesalePrice, GrandTotalWholesalePrice,
                VendorName, VendorUnitPrice, ProRatedVendorUnitPrice, TotalVendorPrice, TaxOnTotalVendorPrice, GrandTotalVendorPrice, BillingCycle, ProrateType, ProrateOnCancellation, UsageAttributes, PaymentMethod,
                PaymentStatus, RefundType, RefundAmount, InvoiceNumber, ResourceId, ChargeType, InvoiceStatus, IndividualInvoice, TaxRateISS, TotalTaxISS, TaxRateCOFINS, TotalTaxCOFINS, TaxRatePIS, TotalTaxPIS, TotalInvoicePrice,
                CustomerAcronym, Segment, CycleCode, CycleReference, FinancialStatus, CommentsCredited, Receivable, CpfUserHasMadeCredit, ProposalNumber, AdabasCode, OpportunityId, QuoteId, StoreAcronym, TotalRetailPriceWithTaxesWithoutDiscount,
                AffiliateCode, ServiceProviderCompanyName, CNPJServiceProviderCompany, StoreAcronymServiceProvider);
        }
    }
}
