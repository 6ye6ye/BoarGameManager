using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddGameRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("17afe30a-1b54-45ad-94dd-1d011d05e32f"), "e31af249-76de-406f-afee-1c6f7085e7b1", "User", "User" },
                    { new Guid("b805cb8c-dea2-45ba-a914-6cdabb219a2a"), "685a5308-183e-4850-b81a-c2bf5fb7ce78", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3609ff48-f92e-4ec5-be1a-799c6f1fe837"), 0, "61ad3865-03f8-44b7-baf1-3f7e56c9d9eb", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "b7c0e57b-cbda-4e56-a29b-da98486996ac", false, "use" },
                    { new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5"), 0, "32acb8ba-5e50-419c-b7b5-564effbc06ca", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "dcee7aae-cff0-4c65-833b-de82bf4b5dfb", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("11b96ab6-ad79-4a7f-93a0-8f4135383d95"), "StarWarsRebellion.jpg", 240, 14, 180, "Star Wars: Rebellion", "Star Wars: Rebellion", "Звездные войны: Восстание", 4, 2, 0.0, 0, 2016 },
                    { new Guid("98139978-7216-4679-9a76-f5522896f0d3"), "forbiddenStars.jpg", 120, 14, 60, "Forbidden Stars", "Forbidden Stars", "Запретные звезды", 4, 2, 0.0, 0, 2015 },
                    { new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"), "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("17afe30a-1b54-45ad-94dd-1d011d05e32f"), new Guid("3609ff48-f92e-4ec5-be1a-799c6f1fe837") },
                    { new Guid("b805cb8c-dea2-45ba-a914-6cdabb219a2a"), new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("32b2d516-b29b-4514-a52e-9afdc9860b31"), new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"), "Sheriff" },
                    { new Guid("3afae0f4-309c-4669-abe1-cf0e7c35691c"), new Guid("98139978-7216-4679-9a76-f5522896f0d3"), "Eldar" },
                    { new Guid("4b4c45e8-a6e1-430a-bc63-d599d580b0cc"), new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"), "Player" },
                    { new Guid("4ccd92cf-b937-48ec-96e1-28b4c37c9fce"), new Guid("98139978-7216-4679-9a76-f5522896f0d3"), "Emperor's Space Marine" },
                    { new Guid("55351ab2-130e-4477-931f-ca036d84b051"), new Guid("98139978-7216-4679-9a76-f5522896f0d3"), "Chaos Space Marine" },
                    { new Guid("69fb1f04-7c8f-47a2-82ec-ff3c16655755"), new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"), "Mafia" },
                    { new Guid("ae46e1c2-9367-46c9-b997-09015a7fab86"), new Guid("11b96ab6-ad79-4a7f-93a0-8f4135383d95"), "Rebels" },
                    { new Guid("bca4b1a3-40ef-49fa-b77a-8b5b0421e1a3"), new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"), "Doctor" },
                    { new Guid("d402ab6b-ecc0-4ea6-8045-c55bf002dd03"), new Guid("11b96ab6-ad79-4a7f-93a0-8f4135383d95"), "Empire" },
                    { new Guid("e606b6c5-7708-4b10-9884-12f7cafcf28c"), new Guid("98139978-7216-4679-9a76-f5522896f0d3"), "Ork" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("d2677cbb-3a6f-4b60-9cbc-05b209418c29"), new Guid("3609ff48-f92e-4ec5-be1a-799c6f1fe837"), null, "use" },
                    { new Guid("fc493618-7900-4ffb-8a60-32697eb7177b"), new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5"), null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("a78fd598-383c-4206-bc9b-d8d09d5e3bf2"), new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5"), new Guid("3609ff48-f92e-4ec5-be1a-799c6f1fe837"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a61e6cb-8e3f-4693-b629-ca68fd6a8534"), "MyHome", new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5") },
                    { new Guid("cc3465cc-46cd-44b3-b93d-174dc7f58b18"), "Work", new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("7b554636-243c-4075-80c6-0a00985ee3f7"), new DateTime(2022, 11, 28, 16, 0, 23, 850, DateTimeKind.Local).AddTicks(7490), new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"), new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5"), new Guid("2a61e6cb-8e3f-4693-b629-ca68fd6a8534") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("17afe30a-1b54-45ad-94dd-1d011d05e32f"), new Guid("3609ff48-f92e-4ec5-be1a-799c6f1fe837") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b805cb8c-dea2-45ba-a914-6cdabb219a2a"), new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("7b554636-243c-4075-80c6-0a00985ee3f7"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("32b2d516-b29b-4514-a52e-9afdc9860b31"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("3afae0f4-309c-4669-abe1-cf0e7c35691c"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("4b4c45e8-a6e1-430a-bc63-d599d580b0cc"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ccd92cf-b937-48ec-96e1-28b4c37c9fce"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("55351ab2-130e-4477-931f-ca036d84b051"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("69fb1f04-7c8f-47a2-82ec-ff3c16655755"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae46e1c2-9367-46c9-b997-09015a7fab86"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("bca4b1a3-40ef-49fa-b77a-8b5b0421e1a3"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("d402ab6b-ecc0-4ea6-8045-c55bf002dd03"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("e606b6c5-7708-4b10-9884-12f7cafcf28c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d2677cbb-3a6f-4b60-9cbc-05b209418c29"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("fc493618-7900-4ffb-8a60-32697eb7177b"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("a78fd598-383c-4206-bc9b-d8d09d5e3bf2"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("cc3465cc-46cd-44b3-b93d-174dc7f58b18"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17afe30a-1b54-45ad-94dd-1d011d05e32f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b805cb8c-dea2-45ba-a914-6cdabb219a2a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3609ff48-f92e-4ec5-be1a-799c6f1fe837"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11b96ab6-ad79-4a7f-93a0-8f4135383d95"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("98139978-7216-4679-9a76-f5522896f0d3"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("c35daf38-46df-4367-b693-6b7e65f7c0e1"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("2a61e6cb-8e3f-4693-b629-ca68fd6a8534"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a135049-efc7-4d03-8046-d0d7a3ae55a5"));

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
        }
    }
}
