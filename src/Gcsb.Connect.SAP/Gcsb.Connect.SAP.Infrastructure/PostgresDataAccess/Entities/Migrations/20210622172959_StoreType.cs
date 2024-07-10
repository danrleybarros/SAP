using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class StoreType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreType",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "StoreType",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "StoreType",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreType",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "StoreType",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "StoreType",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
