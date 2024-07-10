using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class UploadType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Upload",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UploadType = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    StatusType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadType",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Upload",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "UploadType",
                schema: "JsdnBill");
        }
    }
}
