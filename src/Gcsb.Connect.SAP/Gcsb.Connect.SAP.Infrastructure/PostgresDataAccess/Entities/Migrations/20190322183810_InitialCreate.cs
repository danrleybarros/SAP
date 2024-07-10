using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "JsdnBill");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyAcronym = table.Column<string>(nullable: true),
                    AccountCreationDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CustomerEmailAddress = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<string>(nullable: true),
                    BillingStreet = table.Column<string>(nullable: true),
                    BillingNumber = table.Column<string>(nullable: true),
                    BillingComplement = table.Column<string>(nullable: true),
                    BillingNeighbourhood = table.Column<string>(nullable: true),
                    BillingCity = table.Column<string>(nullable: true),
                    BillingStateOrProvince = table.Column<string>(nullable: true),
                    BillingZIPcode = table.Column<string>(nullable: true),
                    BillingCountry = table.Column<string>(nullable: true),
                    BillingCountryCode = table.Column<string>(nullable: true),
                    BillingPhoneNumber = table.Column<string>(nullable: true),
                    MailingStreet = table.Column<string>(nullable: true),
                    MailingNumber = table.Column<string>(nullable: true),
                    MailingComplement = table.Column<string>(nullable: true),
                    MailingNeighbourhood = table.Column<string>(nullable: true),
                    MailingCity = table.Column<string>(nullable: true),
                    MailingStateOrProvince = table.Column<string>(nullable: true),
                    MailingZIPcode = table.Column<string>(nullable: true),
                    MailingCountry = table.Column<string>(nullable: true),
                    MailingCountryCode = table.Column<string>(nullable: true),
                    MailingPhoneNumber = table.Column<string>(nullable: true),
                    CustomerCPF = table.Column<string>(nullable: true),
                    CustomerCNPJ = table.Column<string>(nullable: true),
                    CustomerStateRegistration = table.Column<string>(nullable: true),
                    UserAccountStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(maxLength: 50, nullable: false),
                    InclusionDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Integrated = table.Column<bool>(nullable: false),
                    IntegrationDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Test = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAccount",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceCode = table.Column<string>(maxLength: 15, nullable: false),
                    ServiceCodeName = table.Column<string>(maxLength: 50, nullable: false),
                    FaturamentoFAT = table.Column<string>(maxLength: 15, nullable: false),
                    FaturamentoAJU = table.Column<string>(maxLength: 15, nullable: false),
                    DescontoFAT = table.Column<string>(maxLength: 15, nullable: false),
                    ArrecadacaoARR = table.Column<string>(maxLength: 15, nullable: false),
                    ArrecadacaoAJU = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentFeed",
                schema: "JsdnBill",
                columns: table => new
                {
                    IdFile = table.Column<Guid>(nullable: false),
                    ResultCode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    VersionId = table.Column<string>(maxLength: 4, nullable: false),
                    TerminalId = table.Column<string>(maxLength: 11, nullable: false),
                    EntityId = table.Column<string>(maxLength: 11, nullable: false),
                    MerchantId = table.Column<string>(maxLength: 15, nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    TypeOperation = table.Column<string>(maxLength: 4, nullable: false),
                    ProcessCode = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(maxLength: 20, nullable: true),
                    CardPan = table.Column<string>(maxLength: 19, nullable: true),
                    CardExpirationDate = table.Column<string>(maxLength: 4, nullable: true),
                    TransactionAmount = table.Column<decimal>(nullable: true),
                    MerchantCurrency = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    OriginIPAddress = table.Column<string>(maxLength: 40, nullable: true),
                    DateTimeSIA = table.Column<string>(nullable: true),
                    DateTimePayment = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<string>(nullable: true),
                    SIAOperationNumber = table.Column<int>(nullable: true),
                    AuthorizationID = table.Column<string>(maxLength: 6, nullable: true),
                    AlternativeAmount = table.Column<decimal>(nullable: true),
                    AlternativeCurrency = table.Column<int>(nullable: true),
                    CustomerEmail = table.Column<string>(maxLength: 60, nullable: true),
                    MerchantSession = table.Column<string>(maxLength: 10, nullable: true),
                    BatchID = table.Column<int>(nullable: true),
                    DataPrint = table.Column<string>(maxLength: 999, nullable: true),
                    UrlPuce = table.Column<string>(nullable: true),
                    UrlAuthPath = table.Column<string>(nullable: true),
                    AcquirerEntity = table.Column<string>(maxLength: 4, nullable: true),
                    PlanType = table.Column<string>(maxLength: 2, nullable: true),
                    InstallmentsNumber = table.Column<int>(nullable: true),
                    GracePeriod = table.Column<int>(nullable: true),
                    InterestAmount = table.Column<decimal>(nullable: true),
                    ExtendedSIAOperationNumber = table.Column<long>(nullable: true),
                    AcquirerTransactionID = table.Column<string>(maxLength: 40, nullable: true),
                    BankIdentificationNumber = table.Column<int>(nullable: true),
                    CardIssuer = table.Column<string>(maxLength: 4, nullable: true),
                    CardIssuerCountry = table.Column<int>(nullable: true),
                    CardBrand = table.Column<int>(nullable: true),
                    CardCategory = table.Column<int>(nullable: true),
                    CardType = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFeed", x => x.IdFile);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Service = table.Column<string>(maxLength: 50, nullable: false),
                    FileId = table.Column<int>(nullable: true),
                    Message = table.Column<string>(maxLength: 200, nullable: false),
                    DateLog = table.Column<DateTime>(nullable: false),
                    TypeLog = table.Column<int>(nullable: false),
                    StackTrace = table.Column<string>(maxLength: 2000, nullable: true),
                    FileId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_File_FileId1",
                        column: x => x.FileId1,
                        principalSchema: "JsdnBill",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Marketplace = table.Column<string>(nullable: true),
                    ResellerName = table.Column<string>(nullable: true),
                    ResellerContactName = table.Column<string>(nullable: true),
                    ResellerEmailAddress = table.Column<string>(nullable: true),
                    ResellerPhoneNumber = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    BillFrom = table.Column<DateTime>(nullable: true),
                    BillTo = table.Column<DateTime>(nullable: true),
                    InvoiceCreationDate = table.Column<DateTime>(nullable: true),
                    StoreCode = table.Column<string>(nullable: true),
                    MarketplaceCity = table.Column<string>(nullable: true),
                    MarketplaceState = table.Column<string>(nullable: true),
                    Premeditateddefaulter = table.Column<string>(nullable: true),
                    CustomerTransactionCurrency = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    RefundType = table.Column<string>(nullable: true),
                    RefundAmount = table.Column<string>(nullable: true),
                    InvoiceStatus = table.Column<string>(nullable: true),
                    FileId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    PaymentFeedIdFile = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "JsdnBill",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "JsdnBill",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_PaymentFeed_PaymentFeedIdFile",
                        column: x => x.PaymentFeedIdFile,
                        principalSchema: "JsdnBill",
                        principalTable: "PaymentFeed",
                        principalColumn: "IdFile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogDetail",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(maxLength: 2000, nullable: false),
                    LogId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogDetail_Log_LogId",
                        column: x => x.LogId,
                        principalSchema: "JsdnBill",
                        principalTable: "Log",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInvoice",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Sequence = table.Column<Guid>(nullable: false),
                    SubscriptionId = table.Column<Guid>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    ServiceType = table.Column<string>(nullable: true),
                    OrderCreationDate = table.Column<DateTime>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    ActivationDate = table.Column<DateTime>(nullable: true),
                    SubscriptionType = table.Column<string>(nullable: true),
                    TermStartDate = table.Column<DateTime>(nullable: true),
                    TermEndDate = table.Column<DateTime>(nullable: true),
                    TermDuration = table.Column<int>(nullable: true),
                    NextRenewalDate = table.Column<DateTime>(nullable: true),
                    ServiceCancellationDate = table.Column<string>(nullable: true),
                    ServiceCode = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    OfferName = table.Column<string>(nullable: true),
                    OfferCode = table.Column<string>(nullable: true),
                    SalesReferenceCode = table.Column<string>(nullable: true),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    Qty = table.Column<double>(nullable: true),
                    ProRateScale = table.Column<double>(nullable: true),
                    RetailUnitPrice = table.Column<double>(nullable: true),
                    ProRatedRetailPriceUnitPrice = table.Column<double>(nullable: true),
                    GrossRetailPrice = table.Column<double>(nullable: true),
                    RetailPriceDiscount = table.Column<double>(nullable: true),
                    ProRatedRetailUnitDiscountedPriceAmount = table.Column<double>(nullable: true),
                    TotalRetailPriceDiscountAmount = table.Column<double>(nullable: true),
                    TotalRetailPrice = table.Column<double>(nullable: true),
                    TaxOnTotalRetailPrice = table.Column<double>(nullable: true),
                    GrandTotalRetailPrice = table.Column<double>(nullable: true),
                    PromotionCode = table.Column<string>(nullable: true),
                    PromotionDuration = table.Column<string>(nullable: true),
                    WholesaleUnitPrice = table.Column<double>(nullable: true),
                    ProRatedWholesaleUnitPrice = table.Column<double>(nullable: true),
                    VendorCurrency = table.Column<string>(nullable: true),
                    GrossWholesalePrice = table.Column<double>(nullable: true),
                    WholesalePriceDiscount = table.Column<double>(nullable: true),
                    ProRatedWholesaleUnitDiscountedPriceAmount = table.Column<double>(nullable: true),
                    TotalWholesalePriceDiscountAmount = table.Column<double>(nullable: true),
                    TotalWholesalePrice = table.Column<double>(nullable: true),
                    TaxOnTotalWholesalePrice = table.Column<double>(nullable: true),
                    GrandTotalWholesalePrice = table.Column<double>(nullable: true),
                    VendorName = table.Column<string>(nullable: true),
                    VendorUnitPrice = table.Column<double>(nullable: true),
                    ProRatedVendorUnitPrice = table.Column<double>(nullable: true),
                    TotalVendorPrice = table.Column<double>(nullable: true),
                    TaxOnTotalVendorPrice = table.Column<double>(nullable: true),
                    GrandTotalVendorPrice = table.Column<double>(nullable: true),
                    BillingCycle = table.Column<string>(nullable: true),
                    ProrateType = table.Column<string>(nullable: true),
                    ProrateOnCancellation = table.Column<string>(nullable: true),
                    UsageAttributes = table.Column<string>(nullable: true),
                    ResourceId = table.Column<string>(nullable: true),
                    ChargeType = table.Column<string>(nullable: true),
                    InvoiceId = table.Column<Guid>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: true),
                    AcquirerEntity = table.Column<string>(maxLength: 4, nullable: true),
                    TransactionDate = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInvoice_FinancialAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "JsdnBill",
                        principalTable: "FinancialAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceInvoice_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "JsdnBill",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAccount_ServiceCode",
                schema: "JsdnBill",
                table: "FinancialAccount",
                column: "ServiceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_FileId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PaymentFeedIdFile",
                schema: "JsdnBill",
                table: "Invoice",
                column: "PaymentFeedIdFile");

            migrationBuilder.CreateIndex(
                name: "IX_Log_FileId1",
                schema: "JsdnBill",
                table: "Log",
                column: "FileId1");

            migrationBuilder.CreateIndex(
                name: "IX_LogDetail_LogId",
                schema: "JsdnBill",
                table: "LogDetail",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoice_AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoice_InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogDetail",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "ServiceInvoice",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "FinancialAccount",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "File",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "PaymentFeed",
                schema: "JsdnBill");
        }
    }
}
