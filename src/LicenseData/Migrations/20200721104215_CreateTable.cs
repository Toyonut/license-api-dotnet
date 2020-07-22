using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicenseData.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "licenses",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LicenseText = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Permissions = table.Column<List<string>>(nullable: true),
                    Conditions = table.Column<List<string>>(nullable: true),
                    Limitations = table.Column<List<string>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licenses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "licenses");
        }
    }
}
