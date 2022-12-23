using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFootWebProject.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terrain",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    longueur = table.Column<float>(type: "real", nullable: false),
                    Pied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    dateEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    heure = table.Column<int>(type: "int", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idUtilisateur = table.Column<int>(type: "int", nullable: false),
                    idTerrain = table.Column<int>(type: "int", nullable: false),
                    idTypeEven = table.Column<int>(type: "int", nullable: false),
                    Utilisateurid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evenement_Terrain_idTerrain",
                        column: x => x.idTerrain,
                        principalTable: "Terrain",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evenement_utilisateur_Utilisateurid",
                        column: x => x.Utilisateurid,
                        principalTable: "utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_idTerrain",
                table: "Evenement",
                column: "idTerrain");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_Utilisateurid",
                table: "Evenement",
                column: "Utilisateurid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "Terrain");

            migrationBuilder.DropTable(
                name: "utilisateur");
        }
    }
}
