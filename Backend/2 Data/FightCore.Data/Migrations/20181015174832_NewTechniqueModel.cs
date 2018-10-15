using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class NewTechniqueModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Techniques_Characters_CharacterId",
                table: "Techniques");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Techniques",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Techniques_CharacterId",
                table: "Techniques",
                newName: "IX_Techniques_AuthorId");

            migrationBuilder.AddColumn<string>(
                name: "Application",
                table: "Techniques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharactersDescription",
                table: "Techniques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "Techniques",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Techniques",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExecuteDescription",
                table: "Techniques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StagesDescription",
                table: "Techniques",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterTechnique",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTechnique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterTechnique_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTechnique_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTechnique_CharacterId",
                table: "CharacterTechnique",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTechnique_TechniqueId",
                table: "CharacterTechnique",
                column: "TechniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Techniques_AspNetUsers_AuthorId",
                table: "Techniques",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Techniques_AspNetUsers_AuthorId",
                table: "Techniques");

            migrationBuilder.DropTable(
                name: "CharacterTechnique");

            migrationBuilder.DropColumn(
                name: "Application",
                table: "Techniques");

            migrationBuilder.DropColumn(
                name: "CharactersDescription",
                table: "Techniques");

            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "Techniques");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Techniques");

            migrationBuilder.DropColumn(
                name: "ExecuteDescription",
                table: "Techniques");

            migrationBuilder.DropColumn(
                name: "StagesDescription",
                table: "Techniques");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Techniques",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Techniques_AuthorId",
                table: "Techniques",
                newName: "IX_Techniques_CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Techniques_Characters_CharacterId",
                table: "Techniques",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
