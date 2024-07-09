using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meine_Aufgabenliste.Migrations
{
    /// <inheritdoc />
    public partial class NormalisierungTabelleToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Kategorie_KategorieId",
                table: "ToDos");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Schluesselwort_SchluesselwortId",
                table: "ToDos");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Status_StatusId",
                table: "ToDos");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Verantwortlicher_VerantwortlicherId",
                table: "ToDos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos");

            migrationBuilder.RenameTable(
                name: "ToDos",
                newName: "ToDo");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_VerantwortlicherId",
                table: "ToDo",
                newName: "IX_ToDo_VerantwortlicherId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_StatusId",
                table: "ToDo",
                newName: "IX_ToDo_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_SchluesselwortId",
                table: "ToDo",
                newName: "IX_ToDo_SchluesselwortId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_KategorieId",
                table: "ToDo",
                newName: "IX_ToDo_KategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Kategorie_KategorieId",
                table: "ToDo",
                column: "KategorieId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Schluesselwort_SchluesselwortId",
                table: "ToDo",
                column: "SchluesselwortId",
                principalTable: "Schluesselwort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Status_StatusId",
                table: "ToDo",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Verantwortlicher_VerantwortlicherId",
                table: "ToDo",
                column: "VerantwortlicherId",
                principalTable: "Verantwortlicher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Kategorie_KategorieId",
                table: "ToDo");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Schluesselwort_SchluesselwortId",
                table: "ToDo");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Status_StatusId",
                table: "ToDo");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Verantwortlicher_VerantwortlicherId",
                table: "ToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "ToDos");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_VerantwortlicherId",
                table: "ToDos",
                newName: "IX_ToDos_VerantwortlicherId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_StatusId",
                table: "ToDos",
                newName: "IX_ToDos_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_SchluesselwortId",
                table: "ToDos",
                newName: "IX_ToDos_SchluesselwortId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_KategorieId",
                table: "ToDos",
                newName: "IX_ToDos_KategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Kategorie_KategorieId",
                table: "ToDos",
                column: "KategorieId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Schluesselwort_SchluesselwortId",
                table: "ToDos",
                column: "SchluesselwortId",
                principalTable: "Schluesselwort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Status_StatusId",
                table: "ToDos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Verantwortlicher_VerantwortlicherId",
                table: "ToDos",
                column: "VerantwortlicherId",
                principalTable: "Verantwortlicher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
