using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddStoreAcronymInBillFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoreAcronym",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreAcronym",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreAcronym",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "StoreAcronym",
                schema: "JsdnBill",
                table: "BillFeed");
        }
    }
}
