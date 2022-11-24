using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddSecurityStampToSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("64b63fe0-cf87-4a70-8e22-e68fb9a84a67"), new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("deb5739d-6d35-40cf-a320-305755c3256f"), new Guid("bf0f2666-b8ed-4ef7-bdb2-0b11dc16a769") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("dcd7b90a-fb71-471c-9363-2e3862bacdd5"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("42b44b7c-8a43-4295-8e42-8ed6aa8807d3"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("96323f0f-aaaf-45fc-b78e-3bf25bc15624"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("ccda1fed-dda3-4d2c-bffd-6dd99717ac3c"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd9f5852-931d-4426-a039-191be6fb32ba"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("30e38932-ee13-46ca-a094-b1c03a8aac83"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("386024cc-3e49-4fec-8601-abcb9b6b9d90"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("902d6ef5-994c-4a1f-96b9-8f553dc90deb"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("ea7ffbca-1b66-43bf-8213-64501bb5dc52"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64b63fe0-cf87-4a70-8e22-e68fb9a84a67"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("deb5739d-6d35-40cf-a320-305755c3256f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bf0f2666-b8ed-4ef7-bdb2-0b11dc16a769"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("cb9742b8-0533-4019-80a5-1b8f19a0ed19"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("5f9ad00b-dda1-42d6-91ba-2b16d98c9d11"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { new Guid("0fd8f85c-b3d0-4f19-9435-3491f149a0d3"), "cc8c35bc-29de-4bb4-8847-760a791be8cd", "User", "User", null },
                    { new Guid("7abe15b5-c450-45df-909e-f4be35702e26"), "35d2a532-6eac-40f5-a2ba-2b8881ba052d", "Admin", "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a6c98e8d-156b-4761-b81f-e5608c10dd53"), 0, "83bc897f-18c9-4982-8a2b-fb5faccd7024", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "2d0e993f-d3dd-407f-9635-c0d049c2bf97", false, "use" },
                    { new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f"), 0, "b5e5d651-c071-4aef-a627-d374264f0513", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "c35b7117-1149-4eef-b3c9-c0137ca279c6", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[] { new Guid("9cc1ef53-f7f9-4fc5-8983-26491c8f9831"), "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0fd8f85c-b3d0-4f19-9435-3491f149a0d3"), new Guid("a6c98e8d-156b-4761-b81f-e5608c10dd53") },
                    { new Guid("7abe15b5-c450-45df-909e-f4be35702e26"), new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("17be6a9a-9666-4cd3-ab06-a04be3d2c868"), new Guid("9cc1ef53-f7f9-4fc5-8983-26491c8f9831"), "Player" },
                    { new Guid("56f1d108-8b69-42be-8fd1-231efbc83156"), new Guid("9cc1ef53-f7f9-4fc5-8983-26491c8f9831"), "Mafia" },
                    { new Guid("9f747a3e-cc33-4a0b-a2df-ac3c74eae1cb"), new Guid("9cc1ef53-f7f9-4fc5-8983-26491c8f9831"), "Doctor" },
                    { new Guid("eec5c9d0-8aa5-47b4-9e2c-5655d3201332"), new Guid("9cc1ef53-f7f9-4fc5-8983-26491c8f9831"), "Sheriff" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("1419ab01-f2ab-4beb-9ec9-f02f72454e90"), new Guid("a6c98e8d-156b-4761-b81f-e5608c10dd53"), null, "use" },
                    { new Guid("a36a9200-0367-4f9b-9617-1b330a3f3f34"), new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f"), null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("6b0e7aeb-b3a6-43a8-b467-df50125043a4"), new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f"), new Guid("a6c98e8d-156b-4761-b81f-e5608c10dd53"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("3782ca05-7da0-479f-a01d-d055cd335948"), "MyHome", new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f") },
                    { new Guid("bc839054-e767-4e0c-badb-e3d724ad85de"), "Work", new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("63c243c8-5b52-4bc4-b93b-6cd0a0a24211"), new DateTime(2022, 11, 24, 10, 46, 38, 379, DateTimeKind.Local).AddTicks(1168), null, new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f"), new Guid("3782ca05-7da0-479f-a01d-d055cd335948") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0fd8f85c-b3d0-4f19-9435-3491f149a0d3"), new Guid("a6c98e8d-156b-4761-b81f-e5608c10dd53") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7abe15b5-c450-45df-909e-f4be35702e26"), new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("63c243c8-5b52-4bc4-b93b-6cd0a0a24211"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("17be6a9a-9666-4cd3-ab06-a04be3d2c868"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("56f1d108-8b69-42be-8fd1-231efbc83156"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f747a3e-cc33-4a0b-a2df-ac3c74eae1cb"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("eec5c9d0-8aa5-47b4-9e2c-5655d3201332"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("1419ab01-f2ab-4beb-9ec9-f02f72454e90"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a36a9200-0367-4f9b-9617-1b330a3f3f34"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("6b0e7aeb-b3a6-43a8-b467-df50125043a4"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("bc839054-e767-4e0c-badb-e3d724ad85de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fd8f85c-b3d0-4f19-9435-3491f149a0d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7abe15b5-c450-45df-909e-f4be35702e26"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a6c98e8d-156b-4761-b81f-e5608c10dd53"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("9cc1ef53-f7f9-4fc5-8983-26491c8f9831"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("3782ca05-7da0-479f-a01d-d055cd335948"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e046931a-650a-42c1-a41a-4e6d11ea6b5f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { new Guid("64b63fe0-cf87-4a70-8e22-e68fb9a84a67"), "2229962a-adee-4998-bb27-47509049fb82", "Admin", "Admin", null },
                    { new Guid("deb5739d-6d35-40cf-a320-305755c3256f"), "daa604b5-e4e2-4ad5-86fe-6f3781a8ca1d", "User", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e"), 0, "1adf6303-4eed-4d86-9847-b0a533d35079", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, null, false, "admin" },
                    { new Guid("bf0f2666-b8ed-4ef7-bdb2-0b11dc16a769"), 0, "ccd9aab9-24fa-450d-a92b-f028da345bcf", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, null, false, "use" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[] { new Guid("cb9742b8-0533-4019-80a5-1b8f19a0ed19"), "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("64b63fe0-cf87-4a70-8e22-e68fb9a84a67"), new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e") },
                    { new Guid("deb5739d-6d35-40cf-a320-305755c3256f"), new Guid("bf0f2666-b8ed-4ef7-bdb2-0b11dc16a769") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("42b44b7c-8a43-4295-8e42-8ed6aa8807d3"), new Guid("cb9742b8-0533-4019-80a5-1b8f19a0ed19"), "Sheriff" },
                    { new Guid("96323f0f-aaaf-45fc-b78e-3bf25bc15624"), new Guid("cb9742b8-0533-4019-80a5-1b8f19a0ed19"), "Mafia" },
                    { new Guid("ccda1fed-dda3-4d2c-bffd-6dd99717ac3c"), new Guid("cb9742b8-0533-4019-80a5-1b8f19a0ed19"), "Player" },
                    { new Guid("fd9f5852-931d-4426-a039-191be6fb32ba"), new Guid("cb9742b8-0533-4019-80a5-1b8f19a0ed19"), "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("30e38932-ee13-46ca-a094-b1c03a8aac83"), new Guid("bf0f2666-b8ed-4ef7-bdb2-0b11dc16a769"), null, "use" },
                    { new Guid("386024cc-3e49-4fec-8601-abcb9b6b9d90"), new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e"), null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("902d6ef5-994c-4a1f-96b9-8f553dc90deb"), new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e"), new Guid("bf0f2666-b8ed-4ef7-bdb2-0b11dc16a769"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f9ad00b-dda1-42d6-91ba-2b16d98c9d11"), "MyHome", new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e") },
                    { new Guid("ea7ffbca-1b66-43bf-8213-64501bb5dc52"), "Work", new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("dcd7b90a-fb71-471c-9363-2e3862bacdd5"), new DateTime(2022, 11, 24, 10, 31, 9, 940, DateTimeKind.Local).AddTicks(5161), null, new Guid("a891547d-64da-4dc9-91c8-3762ff0d259e"), new Guid("5f9ad00b-dda1-42d6-91ba-2b16d98c9d11") });
        }
    }
}
