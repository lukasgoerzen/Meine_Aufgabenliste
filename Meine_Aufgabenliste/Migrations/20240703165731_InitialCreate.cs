using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meine_Aufgabenliste.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verantwortlicher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verantwortlicher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schluesselwort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategorieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schluesselwort", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schluesselwort_Kategorie_KategorieId",
                        column: x => x.KategorieId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategorieId = table.Column<int>(type: "INTEGER", nullable: false),
                    SchluesselwortId = table.Column<int>(type: "INTEGER", nullable: false),
                    Aufgabe = table.Column<string>(type: "TEXT", nullable: false),
                    Beschreibung = table.Column<string>(type: "TEXT", nullable: false),
                    Loesung = table.Column<string>(type: "TEXT", nullable: false),
                    VerantwortlicherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_Kategorie_KategorieId",
                        column: x => x.KategorieId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDos_Schluesselwort_SchluesselwortId",
                        column: x => x.SchluesselwortId,
                        principalTable: "Schluesselwort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDos_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDos_Verantwortlicher_VerantwortlicherId",
                        column: x => x.VerantwortlicherId,
                        principalTable: "Verantwortlicher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schluesselwort_KategorieId",
                table: "Schluesselwort",
                column: "KategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_KategorieId",
                table: "ToDos",
                column: "KategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_SchluesselwortId",
                table: "ToDos",
                column: "SchluesselwortId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_StatusId",
                table: "ToDos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_VerantwortlicherId",
                table: "ToDos",
                column: "VerantwortlicherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Schluesselwort");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Verantwortlicher");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
