using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGamePlaces",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserGamePlaces",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InRequestUserId",
                table: "UserFriends",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OutRequestUserId",
                table: "UserFriends",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameRates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GameRates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GamePartyId",
                table: "GamePartyMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameRoleId",
                table: "GamePartyMembers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "GamePartyMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartyCreatorId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGamePlaceId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04b8eff8-6e00-469b-890b-7b32a4283042"), "32ef12b6-5674-4af9-89e8-6e9333a6212a", "User", "User" },
                    { new Guid("4dbfbf8b-3282-45b9-bb70-3ce505fe76ca"), "9fc38d83-e240-422b-bdc5-67ae492050b6", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"), 0, "b08fe337-08fb-47cf-ad98-bedaca048ff5", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "b4fe4c8f-0df9-4d85-8a23-1797d324b707", false, "admin" },
                    { new Guid("c47af41b-3025-4680-926c-3285b1ad707d"), 0, "21299ca4-c9e7-4f83-9299-e9213908c712", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "bc25d6ab-cc8f-4dc3-9e52-dbeea91a0a8e", false, "use" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"), "forbiddenStars.jpg", 120, 14, 60, "Forbidden Stars", "Forbidden Stars", "Запретные звезды", 4, 2, 0.0, 0, 2015 },
                    { new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"), "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 },
                    { new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"), "StarWarsRebellion.jpg", 240, 14, 180, "Star Wars: Rebellion", "Star Wars: Rebellion", "Звездные войны: Восстание", 4, 2, 0.0, 0, 2016 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4dbfbf8b-3282-45b9-bb70-3ce505fe76ca"), new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df") },
                    { new Guid("04b8eff8-6e00-469b-890b-7b32a4283042"), new Guid("c47af41b-3025-4680-926c-3285b1ad707d") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("16088ed3-8e50-4832-89cc-926fcadb4307"), new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"), "Chaos Space Marine" },
                    { new Guid("189405e5-d054-4117-ba80-9ad6c8fc41c5"), new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"), "Ork" },
                    { new Guid("1b6c842d-722b-4074-9ee6-3538cf04216d"), new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"), "Rebels" },
                    { new Guid("823c95c6-b1ce-4800-8afa-be5870eb1348"), new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"), "Player" },
                    { new Guid("8d58e1cc-758a-4b09-8116-4992a1f2a72b"), new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"), "Emperor's Space Marine" },
                    { new Guid("9fb56489-e959-4cc8-9e17-a71d24f97ae4"), new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"), "Eldar" },
                    { new Guid("b0a0b795-d9dd-42eb-8e7c-0e69315b2805"), new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"), "Empire" },
                    { new Guid("dce5bf83-137a-4ba2-883a-00d0fb05219c"), new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"), "Mafia" },
                    { new Guid("e27b2464-2d7e-4d29-98df-ff63be1becf2"), new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"), "Sheriff" },
                    { new Guid("e7d99955-ed27-4034-8327-16bc93b1ec48"), new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"), "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("93ad4030-c2fb-4f57-83e4-a729751fe6a4"), new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"), null, "admin" },
                    { new Guid("a8982c86-0c9c-43fd-9fc3-da344da52e55"), new Guid("c47af41b-3025-4680-926c-3285b1ad707d"), null, "use" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("74763513-a0ac-4551-b122-cf4e121d7ae0"), new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"), new Guid("c47af41b-3025-4680-926c-3285b1ad707d"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("37565d0e-05c9-44ee-8e28-966355d388e5"), "Work", new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df") },
                    { new Guid("fb17b5fe-971b-440f-8bc0-54bf4c8e2617"), "MyHome", new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("376b4ee8-766a-4747-b40b-94f36f11b6e6"), new DateTime(2022, 11, 28, 15, 59, 43, 668, DateTimeKind.Local).AddTicks(5251), new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"), new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"), new Guid("fb17b5fe-971b-440f-8bc0-54bf4c8e2617") });

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId_GameId",
                table: "UserGames",
                columns: new[] { "UserId", "GameId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces",
                columns: new[] { "UserId", "Name" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_OutRequestUserId",
                table: "UserFriends",
                column: "OutRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatorId",
                table: "Players",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoles_GameId",
                table: "GameRoles",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_GameId",
                table: "GameRates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_UserId",
                table: "GameRates",
                column: "UserId");

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
                name: "IX_GameParties_GameId",
                table: "GameParties",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_UserGamePlaceId",
                table: "GameParties",
                column: "UserGamePlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_UserGamePlaces_UserGamePlaceId",
                table: "GameParties",
                column: "UserGamePlaceId",
                principalTable: "UserGamePlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePartyMembers_GameParties_GamePartyId",
                table: "GamePartyMembers",
                column: "GamePartyId",
                principalTable: "GameParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePartyMembers_GameRoles_GameRoleId",
                table: "GamePartyMembers",
                column: "GameRoleId",
                principalTable: "GameRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePartyMembers_Players_PlayerId",
                table: "GamePartyMembers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRates_AspNetUsers_UserId",
                table: "GameRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRates_Games_GameId",
                table: "GameRates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRoles_Games_GameId",
                table: "GameRoles",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_AccountId",
                table: "Players",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_CreatorId",
                table: "Players",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_OutRequestUserId",
                table: "UserFriends",
                column: "OutRequestUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGamePlaces_AspNetUsers_UserId",
                table: "UserGamePlaces",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties");

            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_UserGamePlaces_UserGamePlaceId",
                table: "GameParties");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePartyMembers_GameParties_GamePartyId",
                table: "GamePartyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePartyMembers_GameRoles_GameRoleId",
                table: "GamePartyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePartyMembers_Players_PlayerId",
                table: "GamePartyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRates_AspNetUsers_UserId",
                table: "GameRates");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRates_Games_GameId",
                table: "GameRates");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRoles_Games_GameId",
                table: "GameRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_AccountId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_CreatorId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_InRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_OutRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGamePlaces_AspNetUsers_UserId",
                table: "UserGamePlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_UserId_GameId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_OutRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_Players_AccountId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CreatorId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_GameRoles_GameId",
                table: "GameRoles");

            migrationBuilder.DropIndex(
                name: "IX_GameRates_GameId",
                table: "GameRates");

            migrationBuilder.DropIndex(
                name: "IX_GameRates_UserId",
                table: "GameRates");

            migrationBuilder.DropIndex(
                name: "IX_GamePartyMembers_GamePartyId",
                table: "GamePartyMembers");

            migrationBuilder.DropIndex(
                name: "IX_GamePartyMembers_GameRoleId",
                table: "GamePartyMembers");

            migrationBuilder.DropIndex(
                name: "IX_GamePartyMembers_PlayerId",
                table: "GamePartyMembers");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_GameId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_UserGamePlaceId",
                table: "GameParties");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4dbfbf8b-3282-45b9-bb70-3ce505fe76ca"), new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("04b8eff8-6e00-469b-890b-7b32a4283042"), new Guid("c47af41b-3025-4680-926c-3285b1ad707d") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("376b4ee8-766a-4747-b40b-94f36f11b6e6"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("16088ed3-8e50-4832-89cc-926fcadb4307"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("189405e5-d054-4117-ba80-9ad6c8fc41c5"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b6c842d-722b-4074-9ee6-3538cf04216d"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("823c95c6-b1ce-4800-8afa-be5870eb1348"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d58e1cc-758a-4b09-8116-4992a1f2a72b"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("9fb56489-e959-4cc8-9e17-a71d24f97ae4"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0a0b795-d9dd-42eb-8e7c-0e69315b2805"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("dce5bf83-137a-4ba2-883a-00d0fb05219c"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("e27b2464-2d7e-4d29-98df-ff63be1becf2"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7d99955-ed27-4034-8327-16bc93b1ec48"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("93ad4030-c2fb-4f57-83e4-a729751fe6a4"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a8982c86-0c9c-43fd-9fc3-da344da52e55"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("74763513-a0ac-4551-b122-cf4e121d7ae0"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("37565d0e-05c9-44ee-8e28-966355d388e5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04b8eff8-6e00-469b-890b-7b32a4283042"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4dbfbf8b-3282-45b9-bb70-3ce505fe76ca"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c47af41b-3025-4680-926c-3285b1ad707d"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("fb17b5fe-971b-440f-8bc0-54bf4c8e2617"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserGamePlaces");

            migrationBuilder.DropColumn(
                name: "InRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "OutRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameRoles");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameRates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameRates");

            migrationBuilder.DropColumn(
                name: "GamePartyId",
                table: "GamePartyMembers");

            migrationBuilder.DropColumn(
                name: "GameRoleId",
                table: "GamePartyMembers");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GamePartyMembers");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameParties");

            migrationBuilder.DropColumn(
                name: "PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropColumn(
                name: "UserGamePlaceId",
                table: "GameParties");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGamePlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");
        }
    }
}
