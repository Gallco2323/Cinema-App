using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCinemasToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0057392a-7377-404b-9f24-6de1de5b05f3"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("64a21a0e-0c6d-47df-bf65-54f8d82fa14d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e1edf91e-0568-4d27-88a9-afc1f9305ee5"));

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemasMovies",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemasMovies", x => new { x.CinemaId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("04189060-0379-4c51-b344-8996137dda4a"), "Varna", "Cine Max" },
                    { new Guid("1b19e0be-1e02-43bc-ba72-1da07d94a3e2"), "Yambol", "Cine Grand" },
                    { new Guid("2b9bba32-1147-46cc-8565-094f0f79e7f1"), "Pazardzhik", "Cine Grand" },
                    { new Guid("3051ac95-2f8d-4b9e-ac0d-16efcc1f9203"), "Dobrich", "Cine Grand" },
                    { new Guid("331bb93d-e18f-42c9-8d1d-e03c2681f9e1"), "Stara Zagora", "Cine Grand" },
                    { new Guid("36041389-ba8d-45be-8aaa-26a68adfd1cd"), "Vratsa", "Cine Grand" },
                    { new Guid("4573875d-7a2a-4986-9269-34301ba1a1e3"), "Sliven", "Cine Grand" },
                    { new Guid("4ccf9cf6-e296-4fc5-81f4-69d43491285f"), "Blagoevgrad", "Cine Grand" },
                    { new Guid("54094914-1b0b-49e2-8d1b-08378ce1ce5d"), "Burgas", "Cine Grand" },
                    { new Guid("55ae2f15-bb09-4bc7-a6bd-516a53526728"), "Veliko Tarnovo", "Cine Grand" },
                    { new Guid("acc2f18d-1291-46ac-9e7d-e5b5093451a7"), "Pleven", "Cine Grand" },
                    { new Guid("af0324e0-bfa1-4512-a869-282fab48b9ca"), "Shumen", "Cine Grand" },
                    { new Guid("b9556a9b-b854-4b15-a7cb-5029d2f59ba8"), "Kazanlak", "Cine Grand" },
                    { new Guid("c732801a-750e-4cf3-b1c3-a49aa055c214"), "Gabrovo", "Cine Grand" },
                    { new Guid("cb4b47fa-c0cb-4633-a954-f217119b95e3"), "Plovdiv", "Cine Grand" },
                    { new Guid("d26d6ab5-098d-4280-bdaf-c9c1a63cf5da"), "Sofia", "Cinema City" },
                    { new Guid("dcd65071-6dde-46be-bf4e-836121dbd720"), "Ruse", "Cine Grand" },
                    { new Guid("efe1e59b-850d-4dc3-8c63-a6f0a8a54453"), "Haskovo", "Cine Grand" },
                    { new Guid("f9ab2f51-2ecc-40cf-a229-37a76d8a42eb"), "Asenovgrad", "Cine Grand" },
                    { new Guid("ffdfe74a-de4f-409a-bb70-c7b8f084d6c9"), "Pernik", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1fc3fc65-612c-4cf4-bc4c-d0a90e92bc5c"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("8766ca7f-8ca1-494f-9a13-0abc29952e36"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("97f5ea67-60b7-4324-9478-f038f8454276"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Crime", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemasMovies_MovieId",
                table: "CinemasMovies",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemasMovies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1fc3fc65-612c-4cf4-bc4c-d0a90e92bc5c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8766ca7f-8ca1-494f-9a13-0abc29952e36"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("97f5ea67-60b7-4324-9478-f038f8454276"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0057392a-7377-404b-9f24-6de1de5b05f3"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("64a21a0e-0c6d-47df-bf65-54f8d82fa14d"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Crime", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("e1edf91e-0568-4d27-88a9-afc1f9305ee5"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });
        }
    }
}
