﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class CharacterModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    PerformersDescription = table.Column<string>(nullable: true),
                    ReceiversDescription = table.Column<string>(nullable: true),
                    StagesDescription = table.Column<string>(nullable: true),
                    InputDescription = table.Column<string>(nullable: true),
                    MixUpDescription = table.Column<string>(nullable: true),
                    DamageDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combos_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControllerInputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TextDescription = table.Column<string>(nullable: true),
                    KeyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerInputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    ExecuteDescription = table.Column<string>(nullable: true),
                    CharactersDescription = table.Column<string>(nullable: true),
                    StagesDescription = table.Column<string>(nullable: true),
                    DetailedDescription = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false),
                    Application = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techniques_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Techniques_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true),
                    InputId = table.Column<int>(nullable: true)
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
                        name: "FK_Moves_ControllerInputs_InputId",
                        column: x => x.InputId,
                        principalTable: "ControllerInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SourceUrl = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true),
                    ComboId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    MoveId = table.Column<int>(nullable: true),
                    TechniqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "Id", "Description", "GameId", "Name" },
                values: new object[,]
                {
                    { 1, "The all-star", 1, "Mario" },
                    { 2, "The all-star", 2, "Mario" },
                    { 3, "The all-star", 3, "Mario" },
                    { 4, "The all-star", 4, "Mario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameId",
                table: "Characters",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTechnique_CharacterId",
                table: "CharacterTechnique",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTechnique_TechniqueId",
                table: "CharacterTechnique",
                column: "TechniqueId");

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
                name: "IX_Combos_AuthorId",
                table: "Combos",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageMetric_ComboId",
                table: "DamageMetric",
                column: "ComboId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Media_CharacterId",
                table: "Media",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_ComboId",
                table: "Media",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_GameId",
                table: "Media",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MoveId",
                table: "Media",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_TechniqueId",
                table: "Media",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_CharacterId",
                table: "Moves",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_InputId",
                table: "Moves",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_Techniques_AuthorId",
                table: "Techniques",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Techniques_GameId",
                table: "Techniques",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterTechnique");

            migrationBuilder.DropTable(
                name: "ComboPerformers");

            migrationBuilder.DropTable(
                name: "ComboReceiver");

            migrationBuilder.DropTable(
                name: "DamageMetric");

            migrationBuilder.DropTable(
                name: "InputChain");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "ControllerInputs");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}