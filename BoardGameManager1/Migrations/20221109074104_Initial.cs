using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    RatingCount = table.Column<int>(type: "int", nullable: false),
                    PlayersMinCount = table.Column<int>(type: "int", unicode: false, maxLength: 255, nullable: false),
                    PlayersMaxCount = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MinPartyTime = table.Column<int>(type: "int", nullable: false),
                    MaxPartyTime = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesForGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesForGame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InRequestUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OutRequestUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFriends_AspNetUsers_InRequestUserId",
                        column: x => x.InRequestUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFriends_AspNetUsers_OutRequestUserId",
                        column: x => x.OutRequestUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGamePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGamePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGamePlaces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    RoleForGameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRoles_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRoles_RolesForGame_RoleForGameId",
                        column: x => x.RoleForGameId,
                        principalTable: "RolesForGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameParties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserGamePlaceId = table.Column<int>(type: "int", nullable: true),
                    PartyCreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                        column: x => x.PartyCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameParties_UserGamePlaces_UserGamePlaceId",
                        column: x => x.UserGamePlaceId,
                        principalTable: "UserGamePlaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GamePartyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamePartyId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameRoleId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    IsWinner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePartyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePartyMembers_GameParties_GamePartyId",
                        column: x => x.GamePartyId,
                        principalTable: "GameParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePartyMembers_GameRoles_GameRoleId",
                        column: x => x.GameRoleId,
                        principalTable: "GameRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePartyMembers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cc42552-2bd8-4fa2-8ffe-9838d6740913", "248988d1-c9ec-4c4d-996d-3b488e25688f", "User", "User" },
                    { "91ba74e2-db63-433d-b7e2-f77ae138b682", "8e433615-2d4a-4bfe-a046-d086a1cd0ecc", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0cbc4253-bbac-4cdd-9706-bd1e405b7898", 0, "953fe705-8b27-4d43-84fb-7ed6384d5fff", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "e244af22-28e7-4a72-825c-a77d0b82e5fe", false, "admin@gmail.com" },
                    { "aea5a8cc-131d-4314-933e-7c69109aae43", 0, "3dca05b2-8462-4869-88d8-5e9e6e73c6ad", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "0293f41b-4bbf-4471-a5ff-c555a0698538", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[] { 1, "", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, null, 0, 2021 });

            migrationBuilder.InsertData(
                table: "RolesForGame",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mafia" },
                    { 2, "Player" },
                    { 3, "Doctor" },
                    { 4, "Sheriff" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "91ba74e2-db63-433d-b7e2-f77ae138b682", "0cbc4253-bbac-4cdd-9706-bd1e405b7898" },
                    { "0cc42552-2bd8-4fa2-8ffe-9838d6740913", "aea5a8cc-131d-4314-933e-7c69109aae43" }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "RoleForGameId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { 1, "0cbc4253-bbac-4cdd-9706-bd1e405b7898", null, "admin@gmail.com" },
                    { 2, "aea5a8cc-131d-4314-933e-7c69109aae43", null, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { 1, "0cbc4253-bbac-4cdd-9706-bd1e405b7898", "aea5a8cc-131d-4314-933e-7c69109aae43", 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "MyHome", "0cbc4253-bbac-4cdd-9706-bd1e405b7898" },
                    { 2, "Work", "0cbc4253-bbac-4cdd-9706-bd1e405b7898" }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { 1, new DateTime(2022, 11, 9, 13, 41, 4, 14, DateTimeKind.Local).AddTicks(460), "0cbc4253-bbac-4cdd-9706-bd1e405b7898", 1 });

            migrationBuilder.InsertData(
                table: "GamePartyMembers",
                columns: new[] { "Id", "GamePartyId", "GameRoleId", "IsWinner", "PlayerId", "Points" },
                values: new object[] { 1, 1, 1, true, 1, 0 });

            migrationBuilder.InsertData(
                table: "GamePartyMembers",
                columns: new[] { "Id", "GamePartyId", "GameRoleId", "IsWinner", "PlayerId", "Points" },
                values: new object[] { 2, 1, 2, false, 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_UserGamePlaceId",
                table: "GameParties",
                column: "UserGamePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_GamePartyId",
                table: "GamePartyMembers",
                column: "GamePartyId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_GameRoleId",
                table: "GamePartyMembers",
                column: "GameRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_PlayerId",
                table: "GamePartyMembers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoles_GameId",
                table: "GameRoles",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoles_RoleForGameId",
                table: "GameRoles",
                column: "RoleForGameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatorId",
                table: "Players",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_OutRequestUserId",
                table: "UserFriends",
                column: "OutRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGamePlaces_UserId",
                table: "UserGamePlaces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");
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
                name: "GamePartyMembers");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GameParties");

            migrationBuilder.DropTable(
                name: "GameRoles");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "UserGamePlaces");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "RolesForGame");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
