using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class UploadType3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "JsdnBill",
                table: "UploadType");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "JsdnBill",
                table: "UploadType",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                schema: "JsdnBill",
                table: "UploadType",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                schema: "JsdnBill",
                table: "UploadType");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "JsdnBill",
                table: "UploadType",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "JsdnBill",
                table: "UploadType",
                nullable: true);
        }
    }
}
