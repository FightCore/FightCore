﻿// <auto-generated />
using System;
using FightCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FightCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181015174832_NewTechniqueModel")]
    partial class NewTechniqueModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FightCore.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = 1, AccessFailedCount = 0, ConcurrencyStamp = "680f3083-462f-4c8f-ba9a-c09a44145495", Email = "user@test.nl", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "USER@TEST.NL", NormalizedUserName = "USER@TEST.NL", PasswordHash = "AQAAAAEAACcQAAAAEEF7WgDaqY347VdczNcxXwYb6F7IkpBvK5zRg/PU/t5hYIAgKGZanV5GJEco41ILUQ==", PhoneNumberConfirmed = false, SecurityStamp = "WYJC6FNA3WBJEXMXPVVNJTJOB3ZQLL2D", TwoFactorEnabled = false, UserName = "user@test.nl" }
                    );
                });

            modelBuilder.Entity("FightCore.Models.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComboId");

                    b.Property<string>("Description");

                    b.Property<int>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ComboId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("Characters");

                    b.HasData(
                        new { Id = 1, Description = "The all-star", GameId = 1, Name = "Mario" },
                        new { Id = 2, Description = "The all-star", GameId = 2, Name = "Mario" },
                        new { Id = 3, Description = "The all-star", GameId = 3, Name = "Mario" },
                        new { Id = 4, Description = "The all-star", GameId = 4, Name = "Mario" }
                    );
                });

            modelBuilder.Entity("FightCore.Models.Characters.CharacterTechnique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<int>("TechniqueId");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("TechniqueId");

                    b.ToTable("CharacterTechnique");
                });

            modelBuilder.Entity("FightCore.Models.Characters.Combo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId");

                    b.Property<double>("MaximumDamage");

                    b.Property<double>("MinimumDamage");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("FightCore.Models.Characters.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId");

                    b.Property<int?>("InputId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("InputId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("FightCore.Models.Characters.Technique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application");

                    b.Property<int?>("AuthorId");

                    b.Property<string>("CharactersDescription");

                    b.Property<string>("Description");

                    b.Property<string>("DetailedDescription");

                    b.Property<int>("Difficulty");

                    b.Property<string>("ExecuteDescription");

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.Property<string>("StagesDescription");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GameId");

                    b.ToTable("Techniques");
                });

            modelBuilder.Entity("FightCore.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new { Id = 1, Abbreviation = "SSB4", Name = "Super Smash Bros For WiiU" },
                        new { Id = 2, Abbreviation = "SSBB", Name = "Super Smash Bros Brawl" },
                        new { Id = 3, Abbreviation = "SSBM", Name = "Super Smash Bros Melee" },
                        new { Id = 4, Abbreviation = "SBB", Name = "Super Smash Bros" }
                    );
                });

            modelBuilder.Entity("FightCore.Models.Shared.ControllerInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KeyCode");

                    b.Property<string>("TextDescription");

                    b.HasKey("Id");

                    b.ToTable("ControllerInputs");
                });

            modelBuilder.Entity("FightCore.Models.Shared.InputChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComboId");

                    b.Property<int>("FirstFrame");

                    b.Property<int?>("InputId");

                    b.Property<int>("LastFrame");

                    b.Property<int?>("MoveId");

                    b.Property<int?>("TechniqueId");

                    b.Property<int?>("TechniqueId1");

                    b.HasKey("Id");

                    b.HasIndex("ComboId");

                    b.HasIndex("InputId");

                    b.HasIndex("MoveId");

                    b.HasIndex("TechniqueId");

                    b.HasIndex("TechniqueId1");

                    b.ToTable("InputChain");
                });

            modelBuilder.Entity("FightCore.Models.Shared.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId");

                    b.Property<string>("Description");

                    b.Property<int?>("GameId");

                    b.Property<int>("MediaType");

                    b.Property<int?>("MoveId");

                    b.Property<string>("Source");

                    b.Property<string>("SourceUrl");

                    b.Property<int?>("TechniqueId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("GameId");

                    b.HasIndex("MoveId");

                    b.HasIndex("TechniqueId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.Property<string>("ClientSecret");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("ConsentType");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Permissions");

                    b.Property<string>("PostLogoutRedirectUris");

                    b.Property<string>("Properties");

                    b.Property<string>("RedirectUris");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("Properties");

                    b.Property<string>("Scopes");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictScope", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Properties");

                    b.Property<string>("Resources");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset?>("CreationDate");

                    b.Property<DateTimeOffset?>("ExpirationDate");

                    b.Property<string>("Payload");

                    b.Property<string>("Properties");

                    b.Property<string>("ReferenceId");

                    b.Property<string>("Status");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasFilter("[ReferenceId] IS NOT NULL");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("FightCore.Models.Characters.Character", b =>
                {
                    b.HasOne("FightCore.Models.Characters.Combo")
                        .WithMany("WorksOn")
                        .HasForeignKey("ComboId");

                    b.HasOne("FightCore.Models.Game", "Game")
                        .WithOne()
                        .HasForeignKey("FightCore.Models.Characters.Character", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FightCore.Models.Characters.CharacterTechnique", b =>
                {
                    b.HasOne("FightCore.Models.Characters.Character", "Character")
                        .WithMany("Techniques")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FightCore.Models.Characters.Technique", "Technique")
                        .WithMany("Characters")
                        .HasForeignKey("TechniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FightCore.Models.Characters.Combo", b =>
                {
                    b.HasOne("FightCore.Models.Characters.Character", "Character")
                        .WithMany("Combos")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("FightCore.Models.Characters.Move", b =>
                {
                    b.HasOne("FightCore.Models.Characters.Character", "Character")
                        .WithMany("Moves")
                        .HasForeignKey("CharacterId");

                    b.HasOne("FightCore.Models.Shared.ControllerInput", "Input")
                        .WithMany()
                        .HasForeignKey("InputId");
                });

            modelBuilder.Entity("FightCore.Models.Characters.Technique", b =>
                {
                    b.HasOne("FightCore.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("FightCore.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("FightCore.Models.Shared.InputChain", b =>
                {
                    b.HasOne("FightCore.Models.Characters.Combo")
                        .WithMany("Inputs")
                        .HasForeignKey("ComboId");

                    b.HasOne("FightCore.Models.Shared.ControllerInput", "Input")
                        .WithMany()
                        .HasForeignKey("InputId");

                    b.HasOne("FightCore.Models.Characters.Move", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId");

                    b.HasOne("FightCore.Models.Characters.Technique", "Technique")
                        .WithMany()
                        .HasForeignKey("TechniqueId");

                    b.HasOne("FightCore.Models.Characters.Technique")
                        .WithMany("Inputs")
                        .HasForeignKey("TechniqueId1");
                });

            modelBuilder.Entity("FightCore.Models.Shared.Media", b =>
                {
                    b.HasOne("FightCore.Models.Characters.Character")
                        .WithMany("Media")
                        .HasForeignKey("CharacterId");

                    b.HasOne("FightCore.Models.Game")
                        .WithMany("Media")
                        .HasForeignKey("GameId");

                    b.HasOne("FightCore.Models.Characters.Move")
                        .WithMany("Media")
                        .HasForeignKey("MoveId");

                    b.HasOne("FightCore.Models.Characters.Technique")
                        .WithMany("Media")
                        .HasForeignKey("TechniqueId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("FightCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("FightCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FightCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("FightCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictAuthorization", b =>
                {
                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictApplication", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictApplication", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictAuthorization", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");
                });
#pragma warning restore 612, 618
        }
    }
}
