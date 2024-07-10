using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddBillfeedIdOnDeferralOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeferralProvisionStarted",
                schema: "JsdnBill",
                table: "DeferralOffer",
                newName: "IsIncomeRecognized");

            migrationBuilder.AddColumn<Guid>(
                name: "BillfeedFileId",
                schema: "JsdnBill",
                table: "DeferralOffer",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillfeedFileId",
                schema: "JsdnBill",
                table: "DeferralOffer");

            migrationBuilder.RenameColumn(
                name: "IsIncomeRecognized",
                schema: "JsdnBill",
                table: "DeferralOffer",
                newName: "DeferralProvisionStarted");
        }
    }
}
