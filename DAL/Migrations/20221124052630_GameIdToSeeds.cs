using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class GameIdToSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("09a71bac-36ac-486e-a329-dd2dcacef3cf"), "b1ee1edd-2ce9-4ad7-a01c-31626ce46c99", "Admin", "Admin", null },
                    { new Guid("37ce31a4-8fcd-48c1-955d-624eae437285"), "a7d978ce-2766-426e-b888-aa53731b146e", "User", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("28039ade-97b4-4bfb-a21a-08013e668506"), 0, "5b3d7699-d35b-4012-bbd2-93230b271205", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "01eeb201-eb49-43fe-b427-9c5525432f56", false, "admin" },
                    { new Guid("6aeefb77-fd67-40dd-a8ff-ddd75133b0fb"), 0, "3f885f38-5e50-4888-8c0d-dded25717226", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "23a424b7-589d-4d61-9b50-312b8e34b43d", false, "use" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[] { new Guid("db045535-2deb-45a5-872b-9717a87f973d"), "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("09a71bac-36ac-486e-a329-dd2dcacef3cf"), new Guid("28039ade-97b4-4bfb-a21a-08013e668506") },
                    { new Guid("37ce31a4-8fcd-48c1-955d-624eae437285"), new Guid("6aeefb77-fd67-40dd-a8ff-ddd75133b0fb") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("107539e4-2949-47d9-bedf-b33651422af3"), new Guid("db045535-2deb-45a5-872b-9717a87f973d"), "Doctor" },
                    { new Guid("11a9f0d7-3bcd-44bf-8bba-e85c890830cb"), new Guid("db045535-2deb-45a5-872b-9717a87f973d"), "Mafia" },
                    { new Guid("221b816f-5778-4a00-8e28-fecb5599ea6e"), new Guid("db045535-2deb-45a5-872b-9717a87f973d"), "Player" },
                    { new Guid("86660d1a-e1d3-4da6-ad6c-d2884d80d0a5"), new Guid("db045535-2deb-45a5-872b-9717a87f973d"), "Sheriff" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("494e9d4e-1290-4319-a859-959b5f7aa535"), new Guid("6aeefb77-fd67-40dd-a8ff-ddd75133b0fb"), null, "use" },
                    { new Guid("b0bc4978-8655-43ae-93cc-51a8e3b8aae7"), new Guid("28039ade-97b4-4bfb-a21a-08013e668506"), null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("45f6b408-a811-4132-8493-a7c36e376f50"), new Guid("28039ade-97b4-4bfb-a21a-08013e668506"), new Guid("6aeefb77-fd67-40dd-a8ff-ddd75133b0fb"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("17b8be2d-e906-4ce9-9e41-6f6692628dc7"), "MyHome", new Guid("28039ade-97b4-4bfb-a21a-08013e668506") },
                    { new Guid("56565a17-9ecc-48c5-9bea-713b8968401d"), "Work", new Guid("28039ade-97b4-4bfb-a21a-08013e668506") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("2cb2532f-4004-4212-8228-f34802a87f40"), new DateTime(2022, 11, 24, 11, 26, 30, 130, DateTimeKind.Local).AddTicks(6432), new Guid("db045535-2deb-45a5-872b-9717a87f973d"), new Guid("28039ade-97b4-4bfb-a21a-08013e668506"), new Guid("17b8be2d-e906-4ce9-9e41-6f6692628dc7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09a71bac-36ac-486e-a329-dd2dcacef3cf"), new Guid("28039ade-97b4-4bfb-a21a-08013e668506") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("37ce31a4-8fcd-48c1-955d-624eae437285"), new Guid("6aeefb77-fd67-40dd-a8ff-ddd75133b0fb") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("2cb2532f-4004-4212-8228-f34802a87f40"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("107539e4-2949-47d9-bedf-b33651422af3"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("11a9f0d7-3bcd-44bf-8bba-e85c890830cb"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("221b816f-5778-4a00-8e28-fecb5599ea6e"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("86660d1a-e1d3-4da6-ad6c-d2884d80d0a5"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("494e9d4e-1290-4319-a859-959b5f7aa535"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b0bc4978-8655-43ae-93cc-51a8e3b8aae7"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("45f6b408-a811-4132-8493-a7c36e376f50"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("56565a17-9ecc-48c5-9bea-713b8968401d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09a71bac-36ac-486e-a329-dd2dcacef3cf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("37ce31a4-8fcd-48c1-955d-624eae437285"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6aeefb77-fd67-40dd-a8ff-ddd75133b0fb"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("db045535-2deb-45a5-872b-9717a87f973d"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("17b8be2d-e906-4ce9-9e41-6f6692628dc7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28039ade-97b4-4bfb-a21a-08013e668506"));

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
    }
}
