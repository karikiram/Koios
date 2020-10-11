using Microsoft.EntityFrameworkCore.Migrations;

namespace Koios.Migrations
{
    public partial class Uniquetownandpostalcodeforreal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Towns_TownName_PostalCode",
                table: "Towns",
                columns: new[] { "TownName", "PostalCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Towns_TownName_PostalCode",
                table: "Towns");
        }
    }
}
