using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddColumnsPaymentFreedCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Acquirer",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorizationCode",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardLabel",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditCard",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNSU",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentDate",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentValue",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acquirer",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "AuthorizationCode",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CardLabel",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CreditCardNSU",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "PaymentValue",
                schema: "JsdnBill",
                table: "PaymentFeed");
        }
    }
}
