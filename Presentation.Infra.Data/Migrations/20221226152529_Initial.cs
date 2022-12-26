using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentation.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Animals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteMusic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteMovie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteTVShow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteSport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "Password", "PersonalInfoId" },
                values: new object[] { 1, "paolo.fullone@xpi.com.br", "Password123", 1 });

            migrationBuilder.InsertData(
                table: "PersonalInfos",
                columns: new[] { "Id", "Animals", "BirthDate", "City", "FavoriteBook", "FavoriteFood", "FavoriteMovie", "FavoriteMusic", "FavoriteSport", "FavoriteTVShow", "FullName", "LinkedinUrl", "MaritalStatus", "PersonId", "State" },
                values: new object[] { 1, "2 cachorros, 2(n) coelhos", new DateTime(1978, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coronel Fabriciano", "Ponto de Inflexão", "Churrasco", "Interstellar", "Depende", "Tenis", "Dark", "Paolo Enrico Iacono Fullone", "https://www.linkedin.com/in/paolofullone/", 1, 1, "MG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInfos");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
