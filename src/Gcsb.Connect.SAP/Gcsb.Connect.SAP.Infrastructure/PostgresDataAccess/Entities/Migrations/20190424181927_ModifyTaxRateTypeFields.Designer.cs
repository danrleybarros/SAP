﻿// <auto-generated />
using System;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190424181927_ModifyTaxRateTypeFields")]
    partial class ModifyTaxRateTypeFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedDoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AccountCreationDate");

                    b.Property<DateTime?>("ActivationDate");

                    b.Property<string>("Activity");

                    b.Property<string>("AffiliateCode")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("BillFrom");

                    b.Property<DateTime?>("BillTo");

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingComplement");

                    b.Property<string>("BillingCountry");

                    b.Property<string>("BillingCountryCode");

                    b.Property<string>("BillingCycle");

                    b.Property<string>("BillingNeighbourhood");

                    b.Property<string>("BillingNumber");

                    b.Property<string>("BillingPhoneNumber");

                    b.Property<string>("BillingStateOrProvince");

                    b.Property<string>("BillingStreet");

                    b.Property<string>("BillingZIPcode");

                    b.Property<string>("ChargeType");

                    b.Property<string>("CityHallServiceDescription")
                        .HasMaxLength(150);

                    b.Property<string>("CityServiceCode")
                        .HasMaxLength(10);

                    b.Property<string>("CnpjMarketPlace");

                    b.Property<string>("CommentsCredited");

                    b.Property<string>("CompanyCode")
                        .HasMaxLength(10);

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyNameMarketPlace");

                    b.Property<string>("CustomerAcronym");

                    b.Property<string>("CustomerCNPJ");

                    b.Property<string>("CustomerCPF");

                    b.Property<string>("CustomerCode");

                    b.Property<string>("CustomerEmailAddress");

                    b.Property<string>("CustomerPhoneNumber");

                    b.Property<string>("CustomerStateRegistration");

                    b.Property<string>("CustomerTransactionCurrency");

                    b.Property<DateTime?>("CycleCode");

                    b.Property<DateTime?>("CycleReference");

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("FinancialStatus");

                    b.Property<string>("FirstName");

                    b.Property<double?>("GrandTotalRetailPrice");

                    b.Property<double?>("GrandTotalVendorPrice");

                    b.Property<double?>("GrandTotalWholesalePrice");

                    b.Property<decimal?>("GrossRetailPrice");

                    b.Property<double?>("GrossWholesalePrice");

                    b.Property<Guid>("IdFile");

                    b.Property<string>("IndividualInvoice")
                        .HasMaxLength(1);

                    b.Property<DateTime?>("InvoiceCreationDate");

                    b.Property<string>("InvoiceNumber");

                    b.Property<string>("InvoiceStatus");

                    b.Property<string>("LastName");

                    b.Property<string>("MailingCity");

                    b.Property<string>("MailingComplement");

                    b.Property<string>("MailingCountry");

                    b.Property<string>("MailingCountryCode");

                    b.Property<string>("MailingNeighbourhood");

                    b.Property<string>("MailingNumber");

                    b.Property<string>("MailingPhoneNumber");

                    b.Property<string>("MailingStateOrProvince");

                    b.Property<string>("MailingStreet");

                    b.Property<string>("MailingZIPcode");

                    b.Property<string>("Marketplace");

                    b.Property<string>("MarketplaceCity");

                    b.Property<string>("MarketplaceState");

                    b.Property<string>("MunicipalTaxpayerRegistration")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("NextRenewalDate");

                    b.Property<string>("OfferCode");

                    b.Property<string>("OfferName");

                    b.Property<DateTime?>("OrderCreationDate");

                    b.Property<string>("OrderId");

                    b.Property<string>("PaymentMethod");

                    b.Property<string>("PaymentStatus");

                    b.Property<string>("Premeditateddefaulter");

                    b.Property<double?>("ProRateScale");

                    b.Property<double?>("ProRatedRetailPriceUnitPrice");

                    b.Property<double?>("ProRatedRetailUnitDiscountedPriceAmount");

                    b.Property<double?>("ProRatedVendorUnitPrice");

                    b.Property<double?>("ProRatedWholesaleUnitDiscountedPriceAmount");

                    b.Property<double?>("ProRatedWholesaleUnitPrice");

                    b.Property<string>("PromotionCode");

                    b.Property<string>("PromotionDuration");

                    b.Property<string>("ProrateOnCancellation");

                    b.Property<string>("ProrateType");

                    b.Property<DateTime?>("PurchaseDate");

                    b.Property<double?>("Qty");

                    b.Property<string>("Receivable");

                    b.Property<string>("RefundAmount");

                    b.Property<string>("RefundType");

                    b.Property<string>("ResellerContactName");

                    b.Property<string>("ResellerEmailAddress");

                    b.Property<string>("ResellerName");

                    b.Property<string>("ResellerPhoneNumber");

                    b.Property<string>("ResourceId");

                    b.Property<double?>("RetailPriceDiscount");

                    b.Property<double?>("RetailUnitPrice");

                    b.Property<string>("SalesReferenceCode");

                    b.Property<string>("Segment");

                    b.Property<Guid>("Sequence");

                    b.Property<string>("ServiceCancellationDate");

                    b.Property<string>("ServiceCode");

                    b.Property<string>("ServiceName");

                    b.Property<string>("ServiceType");

                    b.Property<string>("SpecialProcedureNumber")
                        .HasMaxLength(150);

                    b.Property<string>("StoreCode");

                    b.Property<Guid>("SubscriptionId");

                    b.Property<string>("SubscriptionType");

                    b.Property<double?>("TaxOnTotalRetailPrice");

                    b.Property<double?>("TaxOnTotalVendorPrice");

                    b.Property<double?>("TaxOnTotalWholesalePrice");

                    b.Property<decimal?>("TaxRateCOFINS");

                    b.Property<decimal?>("TaxRateISS");

                    b.Property<decimal?>("TaxRatePIS");

                    b.Property<int?>("TermDuration");

                    b.Property<DateTime?>("TermEndDate");

                    b.Property<DateTime?>("TermStartDate");

                    b.Property<decimal?>("TotalInvoicePrice");

                    b.Property<double?>("TotalRetailPrice");

                    b.Property<decimal?>("TotalRetailPriceDiscountAmount");

                    b.Property<decimal?>("TotalTaxCOFINS");

                    b.Property<decimal?>("TotalTaxISS");

                    b.Property<decimal?>("TotalTaxPIS");

                    b.Property<double?>("TotalVendorPrice");

                    b.Property<double?>("TotalWholesalePrice");

                    b.Property<double?>("TotalWholesalePriceDiscountAmount");

                    b.Property<string>("UnitOfMeasure");

                    b.Property<string>("UsageAttributes");

                    b.Property<string>("UserAccountStatus");

                    b.Property<string>("VendorCurrency");

                    b.Property<string>("VendorName");

                    b.Property<double?>("VendorUnitPrice");

                    b.Property<double?>("WholesalePriceDiscount");

                    b.Property<double?>("WholesaleUnitPrice");

                    b.HasKey("Id");

                    b.ToTable("BillFeed","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AccountCreationDate");

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingComplement");

                    b.Property<string>("BillingCountry");

                    b.Property<string>("BillingCountryCode");

                    b.Property<string>("BillingNeighbourhood");

                    b.Property<string>("BillingNumber");

                    b.Property<string>("BillingPhoneNumber");

                    b.Property<string>("BillingStateOrProvince");

                    b.Property<string>("BillingStreet");

                    b.Property<string>("BillingZIPcode");

                    b.Property<string>("CnpjMarketPlace");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyNameMarketPlace");

                    b.Property<string>("CustomerAcronym");

                    b.Property<string>("CustomerCNPJ");

                    b.Property<string>("CustomerCPF");

                    b.Property<string>("CustomerCode");

                    b.Property<string>("CustomerEmailAddress");

                    b.Property<string>("CustomerPhoneNumber");

                    b.Property<string>("CustomerStateRegistration");

                    b.Property<string>("FirstName");

                    b.Property<string>("IndividualInvoice")
                        .HasMaxLength(1);

                    b.Property<string>("InvoiceNumber");

                    b.Property<string>("LastName");

                    b.Property<string>("MailingCity");

                    b.Property<string>("MailingComplement");

                    b.Property<string>("MailingCountry");

                    b.Property<string>("MailingCountryCode");

                    b.Property<string>("MailingNeighbourhood");

                    b.Property<string>("MailingNumber");

                    b.Property<string>("MailingPhoneNumber");

                    b.Property<string>("MailingStateOrProvince");

                    b.Property<string>("MailingStreet");

                    b.Property<string>("MailingZIPcode");

                    b.Property<string>("Segment");

                    b.Property<string>("UserAccountStatus");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceNumber")
                        .IsUnique();

                    b.ToTable("Customer","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Invoice", b =>
                {
                    b.Property<string>("InvoiceNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AffiliateCode")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("BillFrom");

                    b.Property<DateTime?>("BillTo");

                    b.Property<string>("CityHallServiceDescription")
                        .HasMaxLength(150);

                    b.Property<string>("CityServiceCode")
                        .HasMaxLength(10);

                    b.Property<string>("CompanyCode")
                        .HasMaxLength(10);

                    b.Property<string>("CustomerTransactionCurrency");

                    b.Property<Guid>("IdFile");

                    b.Property<DateTime?>("InvoiceCreationDate");

                    b.Property<string>("InvoiceStatus");

                    b.Property<string>("Marketplace");

                    b.Property<string>("MarketplaceCity");

                    b.Property<string>("MarketplaceState");

                    b.Property<string>("MunicipalTaxpayerRegistration");

                    b.Property<string>("OrderId");

                    b.Property<string>("PaymentMethod");

                    b.Property<string>("PaymentStatus");

                    b.Property<string>("Premeditateddefaulter");

                    b.Property<string>("RefundAmount");

                    b.Property<string>("RefundType");

                    b.Property<string>("ResellerContactName");

                    b.Property<string>("ResellerEmailAddress");

                    b.Property<string>("ResellerName");

                    b.Property<string>("ResellerPhoneNumber");

                    b.Property<string>("SpecialProcedureNumber")
                        .HasMaxLength(150);

                    b.Property<string>("StoreCode");

                    b.Property<decimal?>("TotalInvoicePrice");

                    b.HasKey("InvoiceNumber");

                    b.HasIndex("IdFile");

                    b.ToTable("Invoice","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.ServiceInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcquirerEntity")
                        .HasMaxLength(4);

                    b.Property<DateTime?>("ActivationDate");

                    b.Property<string>("Activity");

                    b.Property<string>("BillingCycle");

                    b.Property<string>("ChargeType");

                    b.Property<string>("CommentsCredited");

                    b.Property<DateTime?>("CycleCode");

                    b.Property<DateTime?>("CycleReference");

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("FinancialStatus");

                    b.Property<double?>("GrandTotalRetailPrice");

                    b.Property<double?>("GrandTotalVendorPrice");

                    b.Property<double?>("GrandTotalWholesalePrice");

                    b.Property<decimal?>("GrossRetailPrice");

                    b.Property<double?>("GrossWholesalePrice");

                    b.Property<string>("InvoiceNumber");

                    b.Property<DateTime?>("NextRenewalDate");

                    b.Property<string>("OfferCode");

                    b.Property<string>("OfferName");

                    b.Property<DateTime?>("OrderCreationDate");

                    b.Property<double?>("ProRateScale");

                    b.Property<double?>("ProRatedRetailPriceUnitPrice");

                    b.Property<double?>("ProRatedRetailUnitDiscountedPriceAmount");

                    b.Property<double?>("ProRatedVendorUnitPrice");

                    b.Property<double?>("ProRatedWholesaleUnitDiscountedPriceAmount");

                    b.Property<double?>("ProRatedWholesaleUnitPrice");

                    b.Property<string>("PromotionCode");

                    b.Property<string>("PromotionDuration");

                    b.Property<string>("ProrateOnCancellation");

                    b.Property<string>("ProrateType");

                    b.Property<DateTime?>("PurchaseDate");

                    b.Property<double?>("Qty");

                    b.Property<string>("Receivable");

                    b.Property<string>("ResourceId");

                    b.Property<double?>("RetailPriceDiscount");

                    b.Property<double?>("RetailUnitPrice");

                    b.Property<string>("SalesReferenceCode");

                    b.Property<Guid>("Sequence");

                    b.Property<string>("ServiceCancellationDate");

                    b.Property<string>("ServiceCode");

                    b.Property<string>("ServiceName");

                    b.Property<string>("ServiceType");

                    b.Property<Guid>("SubscriptionId");

                    b.Property<string>("SubscriptionType");

                    b.Property<double?>("TaxOnTotalRetailPrice");

                    b.Property<double?>("TaxOnTotalVendorPrice");

                    b.Property<double?>("TaxOnTotalWholesalePrice");

                    b.Property<decimal?>("TaxRateCOFINS");

                    b.Property<decimal?>("TaxRateISS");

                    b.Property<decimal?>("TaxRatePIS");

                    b.Property<int?>("TermDuration");

                    b.Property<DateTime?>("TermEndDate");

                    b.Property<DateTime?>("TermStartDate");

                    b.Property<double?>("TotalRetailPrice");

                    b.Property<decimal?>("TotalRetailPriceDiscountAmount");

                    b.Property<decimal?>("TotalTaxCOFINS");

                    b.Property<decimal?>("TotalTaxISS");

                    b.Property<decimal?>("TotalTaxPIS");

                    b.Property<double?>("TotalVendorPrice");

                    b.Property<double?>("TotalWholesalePrice");

                    b.Property<double?>("TotalWholesalePriceDiscountAmount");

                    b.Property<string>("TransactionDate")
                        .HasMaxLength(8);

                    b.Property<string>("UnitOfMeasure");

                    b.Property<string>("UsageAttributes");

                    b.Property<string>("VendorCurrency");

                    b.Property<string>("VendorName");

                    b.Property<double?>("VendorUnitPrice");

                    b.Property<double?>("WholesalePriceDiscount");

                    b.Property<double?>("WholesaleUnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceNumber");

                    b.ToTable("ServiceInvoice","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<Guid?>("IdParent");

                    b.Property<DateTime>("InclusionDate");

                    b.Property<DateTime>("IntegrationDate");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("File","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.FinancialAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArrecadacaoAJU")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("ArrecadacaoARR")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("DescontoFAT")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("FaturamentoAJU")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("FaturamentoFAT")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("ServiceCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ServiceCodeName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ServiceCode");

                    b.ToTable("FinancialAccount","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLog");

                    b.Property<Guid?>("FileId");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("StackTrace")
                        .HasMaxLength(2000);

                    b.Property<int>("TypeLog");

                    b.Property<string>("UserId")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Log","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.LogDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Line")
                        .HasMaxLength(20);

                    b.Property<Guid?>("LogId");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("LogId");

                    b.ToTable("LogDetail","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.PaymentFeedDoc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcquirerEntity")
                        .HasMaxLength(4);

                    b.Property<string>("AcquirerTransactionID")
                        .HasMaxLength(40);

                    b.Property<decimal?>("AlternativeAmount");

                    b.Property<int?>("AlternativeCurrency");

                    b.Property<string>("AuthorizationID")
                        .HasMaxLength(6);

                    b.Property<int?>("BankIdentificationNumber");

                    b.Property<int?>("BatchID");

                    b.Property<int?>("CardBrand");

                    b.Property<int?>("CardCategory");

                    b.Property<string>("CardExpirationDate")
                        .HasMaxLength(4);

                    b.Property<string>("CardIssuer")
                        .HasMaxLength(4);

                    b.Property<int?>("CardIssuerCountry");

                    b.Property<string>("CardPan")
                        .HasMaxLength(19);

                    b.Property<string>("CardType")
                        .HasMaxLength(1);

                    b.Property<string>("Currency");

                    b.Property<string>("CustomerEmail")
                        .HasMaxLength(60);

                    b.Property<string>("DataPrint")
                        .HasMaxLength(999);

                    b.Property<string>("DateTimePayment");

                    b.Property<string>("DateTimeSIA");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<long?>("ExtendedSIAOperationNumber");

                    b.Property<int?>("GracePeriod");

                    b.Property<Guid>("IdFile");

                    b.Property<int?>("InstallmentsNumber");

                    b.Property<decimal?>("InterestAmount");

                    b.Property<string>("InvoiceNumberJsdn");

                    b.Property<int?>("MerchantCurrency");

                    b.Property<string>("MerchantId")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("MerchantSession")
                        .HasMaxLength(10);

                    b.Property<string>("OrderId")
                        .HasMaxLength(20);

                    b.Property<string>("OriginIPAddress")
                        .HasMaxLength(40);

                    b.Property<string>("PlanType")
                        .HasMaxLength(2);

                    b.Property<string>("ProcessCode");

                    b.Property<int>("ResultCode");

                    b.Property<int?>("SIAOperationNumber");

                    b.Property<int?>("ServiceId");

                    b.Property<string>("TerminalId")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<decimal?>("TransactionAmount");

                    b.Property<DateTime?>("TransactionDate");

                    b.Property<string>("TypeOperation")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("UrlAuthPath");

                    b.Property<string>("UrlPuce");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VersionId")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("InvoiceNumberJsdn");

                    b.ToTable("PaymentFeed","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.ReturnNF", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChaveNF")
                        .IsRequired();

                    b.Property<DateTime>("DataEmissaoNF");

                    b.Property<Guid>("FileId");

                    b.Property<string>("InvoiceID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NFCancelada")
                        .IsRequired();

                    b.Property<string>("NumeroNF")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SerieNF")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("ValorTotalDescontoNF");

                    b.Property<decimal>("ValorTotalNF");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceID");

                    b.ToTable("ReturnNF","JsdnBill");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Customer", b =>
                {
                    b.HasOne("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Invoice", "Invoice")
                        .WithOne("Customer")
                        .HasForeignKey("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Customer", "InvoiceNumber");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Invoice", b =>
                {
                    b.HasOne("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.File", "File")
                        .WithMany()
                        .HasForeignKey("IdFile")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.ServiceInvoice", b =>
                {
                    b.HasOne("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Invoice", "Invoice")
                        .WithMany("Services")
                        .HasForeignKey("InvoiceNumber");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Log", b =>
                {
                    b.HasOne("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.File")
                        .WithMany("Logs")
                        .HasForeignKey("FileId");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.LogDetail", b =>
                {
                    b.HasOne("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Log")
                        .WithMany("LogDetails")
                        .HasForeignKey("LogId");
                });

            modelBuilder.Entity("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.PaymentFeedDoc", b =>
                {
                    b.HasOne("Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit.Invoice", "Invoice")
                        .WithMany("PaymentFeeds")
                        .HasForeignKey("InvoiceNumberJsdn");
                });
#pragma warning restore 612, 618
        }
    }
}
