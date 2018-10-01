using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class AddedGameAndCharacterSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "SSB4", "Super Smash Bros For WiiU" },
                    { 2, "SSBB", "Super Smash Bros Brawl" },
                    { 3, "SSBM", "Super Smash Bros Melee" },
                    { 4, "SBB", "Super Smash Bros" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ComboId", "Description", "GameId", "Name" },
                values: new object[,]
                {
                    { 1, null, "The all-star", 1, "Mario" },
                    { 2, null, "The all-star", 2, "Mario" },
                    { 3, null, "The all-star", 3, "Mario" },
                    { 4, null, "The all-star", 4, "Mario" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
