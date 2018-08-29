using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class AddedInputChains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControllerInputs_Techniques_TechniqueId",
                table: "ControllerInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Combos_ComboId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_ComboId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_ControllerInputs_TechniqueId",
                table: "ControllerInputs");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "TechniqueId",
                table: "ControllerInputs");

            migrationBuilder.CreateTable(
                name: "InputChain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoveId = table.Column<int>(nullable: true),
                    TechniqueId = table.Column<int>(nullable: true),
                    InputId = table.Column<int>(nullable: true),
                    FirstFrame = table.Column<int>(nullable: false),
                    LastFrame = table.Column<int>(nullable: false),
                    ComboId = table.Column<int>(nullable: true),
                    TechniqueId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputChain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputChain_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputChain_ControllerInputs_InputId",
                        column: x => x.InputId,
                        principalTable: "ControllerInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputChain_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputChain_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputChain_Techniques_TechniqueId1",
                        column: x => x.TechniqueId1,
                        principalTable: "Techniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputChain_ComboId",
                table: "InputChain",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_InputChain_InputId",
                table: "InputChain",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_InputChain_MoveId",
                table: "InputChain",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_InputChain_TechniqueId",
                table: "InputChain",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_InputChain_TechniqueId1",
                table: "InputChain",
                column: "TechniqueId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputChain");

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Moves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechniqueId",
                table: "ControllerInputs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_ComboId",
                table: "Moves",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerInputs_TechniqueId",
                table: "ControllerInputs",
                column: "TechniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerInputs_Techniques_TechniqueId",
                table: "ControllerInputs",
                column: "TechniqueId",
                principalTable: "Techniques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Combos_ComboId",
                table: "Moves",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
