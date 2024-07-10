using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddBillFeedDocAndIdParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_File_FileId1",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_FileId1",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "FileId1",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Test",
                schema: "JsdnBill",
                table: "File");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalRetailPriceDiscountAmount",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                type: "numeric",
                oldType: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossRetailPrice",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true,
                type: "numeric",
                oldType: "double precision",
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test",
                schema: "JsdnBill",
                table: "LogDetail",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                schema: "JsdnBill",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "JsdnBill",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdParent",
                schema: "JsdnBill",
                table: "File",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BillFeed",
                schema: "JsdnBill",
                columns: table => new
                {
                    IdFile = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<Guid>(nullable: false),
                    Marketplace = table.Column<string>(nullable: true),
                    ResellerName = table.Column<string>(nullable: true),
                    ResellerContactName = table.Column<string>(nullable: true),
                    ResellerEmailAddress = table.Column<string>(nullable: true),
                    ResellerPhoneNumber = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
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
                    BillFrom = table.Column<DateTime>(nullable: true),
                    BillTo = table.Column<DateTime>(nullable: true),
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
                    InvoiceCreationDate = table.Column<DateTime>(nullable: true),
                    ServiceCode = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    StoreCode = table.Column<string>(nullable: true),
                    MarketplaceCity = table.Column<string>(nullable: true),
                    MarketplaceState = table.Column<string>(nullable: true),
                    UserAccountStatus = table.Column<string>(nullable: true),
                    Premeditateddefaulter = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    OfferName = table.Column<string>(nullable: true),
                    OfferCode = table.Column<string>(nullable: true),
                    SalesReferenceCode = table.Column<string>(nullable: true),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    Qty = table.Column<double>(nullable: true),
                    ProRateScale = table.Column<double>(nullable: true),
                    RetailUnitPrice = table.Column<double>(nullable: true),
                    ProRatedRetailPriceUnitPrice = table.Column<double>(nullable: true),
                    GrossRetailPrice = table.Column<decimal>(nullable: true),
                    RetailPriceDiscount = table.Column<double>(nullable: true),
                    ProRatedRetailUnitDiscountedPriceAmount = table.Column<double>(nullable: true),
                    TotalRetailPriceDiscountAmount = table.Column<decimal>(nullable: true),
                    TotalRetailPrice = table.Column<double>(nullable: true),
                    TaxOnTotalRetailPrice = table.Column<double>(nullable: true),
                    GrandTotalRetailPrice = table.Column<double>(nullable: true),
                    PromotionCode = table.Column<string>(nullable: true),
                    PromotionDuration = table.Column<string>(nullable: true),
                    WholesaleUnitPrice = table.Column<double>(nullable: true),
                    ProRatedWholesaleUnitPrice = table.Column<double>(nullable: true),
                    CustomerTransactionCurrency = table.Column<string>(nullable: true),
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
                    PaymentMethod = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    RefundType = table.Column<string>(nullable: true),
                    RefundAmount = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    ResourceId = table.Column<string>(nullable: true),
                    ChargeType = table.Column<string>(nullable: true),
                    InvoiceStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillFeed", x => x.Sequence);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_FileId",
                schema: "JsdnBill",
                table: "Log",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_File_FileId",
                schema: "JsdnBill",
                table: "Log",
                column: "FileId",
                principalSchema: "JsdnBill",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_File_FileId",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropTable(
                name: "BillFeed",
                schema: "JsdnBill");

            migrationBuilder.DropIndex(
                name: "IX_Log_FileId",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Test",
                schema: "JsdnBill",
                table: "LogDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "JsdnBill",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "IdParent",
                schema: "JsdnBill",
                table: "File");

            migrationBuilder.AlterColumn<double>(
                name: "TotalRetailPriceDiscountAmount",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                type: "double precision",
                oldType: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GrossRetailPrice",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                type: "double precision",
                oldType: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                schema: "JsdnBill",
                table: "Log",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FileId1",
                schema: "JsdnBill",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test",
                schema: "JsdnBill",
                table: "File",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Log_FileId1",
                schema: "JsdnBill",
                table: "Log",
                column: "FileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_File_FileId1",
                schema: "JsdnBill",
                table: "Log",
                column: "FileId1",
                principalSchema: "JsdnBill",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
