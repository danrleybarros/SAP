using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class CreateDeferralOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeferralOffer",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CycleDate = table.Column<string>(type: "text", nullable: false),
                    ServiceCode = table.Column<string>(type: "text", nullable: false),
                    OfferCode = table.Column<string>(type: "text", nullable: true),
                    CustomerCode = table.Column<string>(type: "text", nullable: false),
                    OrderNumber = table.Column<string>(type: "text", nullable: false),
                    ProviderStoreAcronym = table.Column<string>(type: "text", nullable: false),
                    OfferDeferral = table.Column<string>(type: "text", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    StoreAcronym = table.Column<string>(type: "text", nullable: false),
                    BillingStateOrProvince = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    ServiceType = table.Column<string>(type: "text", nullable: false),
                    TotalShortBalance = table.Column<double>(type: "double precision", nullable: false),
                    TotalLongBalance = table.Column<double>(type: "double precision", nullable: false),
                    TotalBalance = table.Column<double>(type: "double precision", nullable: false),
                    InstallmentAmount = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "integer", nullable: false),
                    CurrentInstallment = table.Column<int>(type: "integer", nullable: false),
                    DeferralCreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeferralStarted = table.Column<bool>(type: "boolean", nullable: false),
                    DeferralProvisionStarted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsNFEmitted = table.Column<bool>(type: "boolean", nullable: false),
                    HasDiscount = table.Column<bool>(type: "boolean", nullable: false),
                    IsProvisioned = table.Column<bool>(type: "boolean", nullable: false),
                    DeferralType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeferralOffer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeferralOffer",
                schema: "JsdnBill");
        }
    }
}
