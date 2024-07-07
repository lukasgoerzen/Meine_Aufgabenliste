using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meine_Aufgabenliste.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSchluesselwort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schluesselwort_Kategorie_KategorieId",
                table: "Schluesselwort");

            migrationBuilder.DropIndex(
                name: "IX_Schluesselwort_KategorieId",
                table: "Schluesselwort");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Schluesselwort_KategorieId",
                table: "Schluesselwort",
                column: "KategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schluesselwort_Kategorie_KategorieId",
                table: "Schluesselwort",
                column: "KategorieId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
