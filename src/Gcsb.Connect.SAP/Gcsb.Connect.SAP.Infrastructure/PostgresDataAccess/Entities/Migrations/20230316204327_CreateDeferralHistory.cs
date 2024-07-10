using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class CreateDeferralHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "DeferralOffer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "DeferralStatus",
                schema: "JsdnBill",
                table: "DeferralOffer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DeferralHistory",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BillTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    OrderCreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: true),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    ServiceCode = table.Column<string>(type: "text", nullable: false),
                    GrandTotalRetailPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalRetailPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountBillingCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountBillingDebit = table.Column<string>(type: "text", nullable: true),
                    Receivable = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PaymentOption = table.Column<string>(type: "text", nullable: true),
                    CostCenter = table.Column<string>(type: "text", nullable: true),
                    InternalOrder = table.Column<string>(type: "text", nullable: true),
                    BusinessLocation = table.Column<string>(type: "text", nullable: true),
                    FilialCode = table.Column<string>(type: "text", nullable: true),
                    UF = table.Column<string>(type: "text", nullable: true),
                    ServiceType = table.Column<string>(type: "text", nullable: true),
                    ProductStatus = table.Column<string>(type: "text", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinancialAccount = table.Column<string>(type: "text", nullable: false),
                    DeferralAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "integer", nullable: false),
                    DeferralCycleCut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeferralDescriptionInstallment = table.Column<string>(type: "text", nullable: false),
                    TotalShortBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountShortTermCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountShortTermDebit = table.Column<string>(type: "text", nullable: true),
                    TotalLongBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountLongTermCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountLongTermDebit = table.Column<string>(type: "text", nullable: true),
                    TotalShortBalanceExceeded = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountLongTermLowCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountLongTermLowDebit = table.Column<string>(type: "text", nullable: true),
                    DeferralAmountProvision = table.Column<decimal>(type: "numeric", nullable: false),
                    DeferralAmountProvisionShortTerm = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountShortTermProvisionCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountShortTermProvisionDebit = table.Column<string>(type: "text", nullable: true),
                    DeferralAmountLowProvisionShortTerm = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountShortTermLowProvisionCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountShortTermLowProvisionDebit = table.Column<string>(type: "text", nullable: true),
                    DeferralAmountProvisionLongTerm = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountLongTermProvisionCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountLongTermProvisionDebit = table.Column<string>(type: "text", nullable: true),
                    DeferralAmountLowProvisionLongTerm = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountingAccountLongTermLowProvisionCredit = table.Column<string>(type: "text", nullable: true),
                    AccountingAccountLongTermLowProvisionDebit = table.Column<string>(type: "text", nullable: true),
                    ContractDeadline = table.Column<string>(type: "text", nullable: false),
                    DateStartedContract = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StoreAcronymServiceProvider = table.Column<string>(type: "text", nullable: false),
                    CnpjServiceProviderCompany = table.Column<string>(type: "text", nullable: false),
                    DeferralType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeferralHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeferralHistory",
                schema: "JsdnBill");

            migrationBuilder.DropColumn(
                name: "DeferralStatus",
                schema: "JsdnBill",
                table: "DeferralOffer");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "DeferralOffer",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
