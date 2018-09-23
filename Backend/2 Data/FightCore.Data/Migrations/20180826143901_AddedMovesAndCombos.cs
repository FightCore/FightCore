using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class AddedMovesAndCombos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoveId",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MinimumDamage = table.Column<double>(nullable: false),
                    MaximumDamage = table.Column<double>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combos_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true),
                    InputId = table.Column<int>(nullable: true),
                    ComboId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_ControllerInputs_InputId",
                        column: x => x.InputId,
                        principalTable: "ControllerInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_MoveId",
                table: "Media",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ComboId",
                table: "Characters",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_CharacterId",
                table: "Combos",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_CharacterId",
                table: "Moves",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_ComboId",
                table: "Moves",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_InputId",
                table: "Moves",
                column: "InputId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Combos_ComboId",
                table: "Characters",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Moves_MoveId",
                table: "Media",
                column: "MoveId",
                principalTable: "Moves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Combos_ComboId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Moves_MoveId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Media_MoveId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ComboId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Characters");
        }
    }
}
