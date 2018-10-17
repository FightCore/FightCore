using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class ComboRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Combos_ComboId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ComboId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MaximumDamage",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "MinimumDamage",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageDescription",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InputDescription",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MixUpDescription",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerformersDescription",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiversDescription",
                table: "Combos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StagesDescription",
                table: "Combos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComboPerformers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    ComboId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboPerformers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboPerformers_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboPerformers_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboReceiver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    ComboId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboReceiver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboReceiver_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboReceiver_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamageMetric",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDamage = table.Column<double>(nullable: false),
                    EndDamage = table.Column<double>(nullable: false),
                    ComboId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageMetric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamageMetric_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combos_AuthorId",
                table: "Combos",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboPerformers_CharacterId",
                table: "ComboPerformers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboPerformers_ComboId",
                table: "ComboPerformers",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboReceiver_CharacterId",
                table: "ComboReceiver",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboReceiver_ComboId",
                table: "ComboReceiver",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageMetric_ComboId",
                table: "DamageMetric",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_AspNetUsers_AuthorId",
                table: "Combos",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combos_AspNetUsers_AuthorId",
                table: "Combos");

            migrationBuilder.DropTable(
                name: "ComboPerformers");

            migrationBuilder.DropTable(
                name: "ComboReceiver");

            migrationBuilder.DropTable(
                name: "DamageMetric");

            migrationBuilder.DropIndex(
                name: "IX_Combos_AuthorId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "DamageDescription",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "InputDescription",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "MixUpDescription",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "PerformersDescription",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "ReceiversDescription",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "StagesDescription",
                table: "Combos");

            migrationBuilder.AddColumn<double>(
                name: "MaximumDamage",
                table: "Combos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinimumDamage",
                table: "Combos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ComboId",
                table: "Characters",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Combos_ComboId",
                table: "Characters",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
