using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NIPApplication.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Nip = table.Column<string>(nullable: true),
                    NipCountryCode = table.Column<string>(nullable: true, defaultValue: "PL"),
                    Regon = table.Column<string>(nullable: true),
                    Krs = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySearchQueries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Query = table.Column<string>(nullable: true),
                    QueryType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySearchQueries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Krs", "Name", "Nip", "PostCode", "Regon", "Street", "StreetNumber" },
                values: new object[] { 1, "Poznan", "0000231231", "GSK Services SP z O O", "7792254227", "60-322", "300040065", "Grunwaldzka", "189" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Krs", "Name", "Nip", "PostCode", "Regon", "Street", "StreetNumber" },
                values: new object[] { 2, "Warszawa", "0000240611", "Google Poland SP z O O", "5252344078", "00-113", "140182840", "Emilii Plater", "53" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Krs", "Name", "Nip", "PostCode", "Regon", "Street", "StreetNumber" },
                values: new object[] { 3, "Warszawa", "0000056838", "Microsoft SP z O O", "5270103391", "02-222", "010016565", "Aleje Jerozolimskie", "195A" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Krs",
                table: "Companies",
                column: "Krs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Nip",
                table: "Companies",
                column: "Nip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Regon",
                table: "Companies",
                column: "Regon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanySearchQueries_Timestamp",
                table: "CompanySearchQueries",
                column: "Timestamp",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompanySearchQueries");
        }
    }
}
