using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ProfileStatus = table.Column<bool>(nullable: false),
                    Newsletter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "PracticeFrequencies",
                columns: table => new
                {
                    PracticeFrequencyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeFrequencies", x => x.PracticeFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(nullable: false),
                    Postcode = table.Column<string>(nullable: true),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_Agent_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInstruments",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstruments", x => new { x.ApplicationUserId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_UserInstruments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInstruments_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ensembles",
                columns: table => new
                {
                    EnsembleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Homepage = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    SizeId = table.Column<int>(nullable: false),
                    PracticeFrequencyId = table.Column<int>(nullable: false),
                    PlayRegular = table.Column<bool>(nullable: false),
                    PlayProject = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensembles", x => x.EnsembleId);
                    table.ForeignKey(
                        name: "FK_Ensembles_PracticeFrequencies_PracticeFrequencyId",
                        column: x => x.PracticeFrequencyId,
                        principalTable: "PracticeFrequencies",
                        principalColumn: "PracticeFrequencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ensembles_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AgentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    EnsembleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Ensembles_EnsembleId",
                        column: x => x.EnsembleId,
                        principalTable: "Ensembles",
                        principalColumn: "EnsembleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnsembleGenre",
                columns: table => new
                {
                    EnsembleId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleGenre", x => new { x.GenreId, x.EnsembleId });
                    table.ForeignKey(
                        name: "FK_EnsembleGenre_Ensembles_EnsembleId",
                        column: x => x.EnsembleId,
                        principalTable: "Ensembles",
                        principalColumn: "EnsembleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnsembleGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInstrumentGenres",
                columns: table => new
                {
                    UserInstrumentGenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    InstrumentId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstrumentGenres", x => x.UserInstrumentGenreId);
                    table.ForeignKey(
                        name: "FK_UserInstrumentGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInstrumentGenres_UserInstruments_ApplicationUserId_InstrumentId",
                        columns: x => new { x.ApplicationUserId, x.InstrumentId },
                        principalTable: "UserInstruments",
                        principalColumns: new[] { "ApplicationUserId", "InstrumentId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostGenres",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGenres", x => new { x.PostId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_PostGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostGenres_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "City", "ConcurrencyStamp", "DateCreated", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Newsletter", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "Postcode", "ProfileStatus", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "63842def-25af-4884-895d-1dd0ce23c0c5", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "daniel@daniel.dk", false, "Daniel", "Smith", false, null, false, null, null, null, null, false, null, null, false, "4cc2735e-576a-48aa-9886-96edaab3a473", false, "daniel@daniel.dk" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "City", "ConcurrencyStamp", "DateCreated", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Newsletter", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "Postcode", "ProfileStatus", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "93f909c5-cb65-42b7-9810-7f33cf81f279", new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "simone@simone.dk", false, "Simone", "White", false, null, false, null, null, null, null, false, null, null, false, "b9e41e23-61ed-47dc-83ba-cef87cef3489", false, "simone@simone.dk" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 1, null, "Classical" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 2, null, "Rock" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 3, null, "Blues" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 4, null, "Country" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 5, null, "Pop" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 6, null, "Jazz" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 7, null, "Metal" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 8, null, "Folk" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 9, null, "HipHop" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "AgentId", "Name" },
                values: new object[] { 10, null, "PunkRock" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 9, "Guitar" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 8, "Drums" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 7, "Flute" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 6, "Accordion" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 4, "Saxophone" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 3, "Trumpet" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 2, "Violin" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 1, "Piano" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 5, "Cello" });

            migrationBuilder.InsertData(
                table: "PracticeFrequencies",
                columns: new[] { "PracticeFrequencyId", "Description" },
                values: new object[] { 1, "Many times a week" });

            migrationBuilder.InsertData(
                table: "PracticeFrequencies",
                columns: new[] { "PracticeFrequencyId", "Description" },
                values: new object[] { 2, "1 time a week" });

            migrationBuilder.InsertData(
                table: "PracticeFrequencies",
                columns: new[] { "PracticeFrequencyId", "Description" },
                values: new object[] { 3, "1 time every other week" });

            migrationBuilder.InsertData(
                table: "PracticeFrequencies",
                columns: new[] { "PracticeFrequencyId", "Description" },
                values: new object[] { 4, "1 time a month" });

            migrationBuilder.InsertData(
                table: "PracticeFrequencies",
                columns: new[] { "PracticeFrequencyId", "Description" },
                values: new object[] { 5, "1 time every other month or less" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Description" },
                values: new object[] { 4, "25 - 49 musicians" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Description" },
                values: new object[] { 1, "1 - 4 musicians" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Description" },
                values: new object[] { 2, "5 - 9 musicians" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Description" },
                values: new object[] { 3, "10 - 24 musicians" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Description" },
                values: new object[] { 5, "50 or more musicians" });

            migrationBuilder.InsertData(
                table: "Ensembles",
                columns: new[] { "EnsembleId", "ApplicationUserId", "City", "Description", "Homepage", "Name", "Picture", "PlayProject", "PlayRegular", "Postcode", "PracticeFrequencyId", "SizeId" },
                values: new object[] { 1, null, "Kobenhavn", "Cool band", null, "Spice Girls", null, false, false, "2200", 1, 1 });

            migrationBuilder.InsertData(
                table: "Ensembles",
                columns: new[] { "EnsembleId", "ApplicationUserId", "City", "Description", "Homepage", "Name", "Picture", "PlayProject", "PlayRegular", "Postcode", "PracticeFrequencyId", "SizeId" },
                values: new object[] { 2, null, "Kobenhavn", "Cool band", null, "U2", null, false, false, "2200", 1, 1 });

            migrationBuilder.InsertData(
                table: "Ensembles",
                columns: new[] { "EnsembleId", "ApplicationUserId", "City", "Description", "Homepage", "Name", "Picture", "PlayProject", "PlayRegular", "Postcode", "PracticeFrequencyId", "SizeId" },
                values: new object[] { 3, null, "Kobenhavn", "Cool band", null, "3 doors down", null, false, false, "2200", 1, 1 });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "ApplicationUserId", "InstrumentId", "Level" },
                values: new object[] { "1", 7, 1 });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "ApplicationUserId", "InstrumentId", "Level" },
                values: new object[] { "1", 8, 3 });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "ApplicationUserId", "InstrumentId", "Level" },
                values: new object[] { "2", 8, 3 });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "ApplicationUserId", "InstrumentId", "Level" },
                values: new object[] { "1", 9, 3 });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "ApplicationUserId", "InstrumentId", "Level" },
                values: new object[] { "2", 9, 1 });

            migrationBuilder.InsertData(
                table: "EnsembleGenre",
                columns: new[] { "GenreId", "EnsembleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "EnsembleGenre",
                columns: new[] { "GenreId", "EnsembleId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "EnsembleGenre",
                columns: new[] { "GenreId", "EnsembleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 1, "1", 1, 7 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 2, "1", 3, 7 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 3, "1", 3, 8 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 5, "2", 2, 8 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 4, "1", 2, 9 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 6, "2", 7, 9 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 7, "2", 1, 9 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 8, "2", 4, 9 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "ApplicationUserId", "GenreId", "InstrumentId" },
                values: new object[] { 9, "2", 6, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_InstrumentId",
                table: "Agent",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnsembleGenre_EnsembleId",
                table: "EnsembleGenre",
                column: "EnsembleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensembles_PracticeFrequencyId",
                table: "Ensembles",
                column: "PracticeFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensembles_SizeId",
                table: "Ensembles",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_AgentId",
                table: "Genres",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGenres_GenreId",
                table: "PostGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EnsembleId",
                table: "Posts",
                column: "EnsembleId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_InstrumentId",
                table: "Posts",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstrumentGenres_GenreId",
                table: "UserInstrumentGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstrumentGenres_ApplicationUserId_InstrumentId",
                table: "UserInstrumentGenres",
                columns: new[] { "ApplicationUserId", "InstrumentId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserInstruments_InstrumentId",
                table: "UserInstruments",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EnsembleGenre");

            migrationBuilder.DropTable(
                name: "PostGenres");

            migrationBuilder.DropTable(
                name: "UserInstrumentGenres");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "UserInstruments");

            migrationBuilder.DropTable(
                name: "Ensembles");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PracticeFrequencies");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Instruments");
        }
    }
}
