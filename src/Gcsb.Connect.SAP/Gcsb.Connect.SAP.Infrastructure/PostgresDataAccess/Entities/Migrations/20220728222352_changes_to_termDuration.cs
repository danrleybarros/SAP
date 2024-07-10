using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class changes_to_termDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TermDuration",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true,
                oldType: "int",
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermDuration",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true,
                oldType: "int",
                oldClrType: typeof(int),
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "TermDuration",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TermDuration",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
