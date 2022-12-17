using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class RenameGameTesseraId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5") });

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("7ea4868f-b2ee-4373-b276-7d76f698d099"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e968c49c-3774-4dd6-adb1-34546745c2ad"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("6b148b17-a7fd-4fb5-9010-b153ebb55b6d"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("bbbb626c-0f6d-4e55-bda3-6bbe92e67b10"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("d161eda9-5015-4feb-a931-5c178e89a15f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"));

            migrationBuilder.RenameColumn(
                name: "TesseraId",
                table: "Games",
                newName: "TeseraId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("277f24e5-5288-4221-a7b0-6379a7ae6a44"), "73276c2e-fcb9-4478-9897-76e526e76a65", "User", "User" },
                    { new Guid("f840b230-fa8b-4683-ace7-c795c84ff989"), "d0811bff-f831-4fea-bc2b-10e4a31a146a", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb"), 0, "a35011f1-ad39-4cf2-be37-36da13908cbd", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "ecbdd0cb-b151-4714-a849-0f5d9f57478b", false, "admin" },
                    { new Guid("92cd2bc7-b2d3-4a83-ab6d-ac4077c0cf43"), 0, "02f609a5-8ff2-460f-a0ee-1a60c41983ad", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "8e74d32e-bed1-4705-beec-a1025c9fa977", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f840b230-fa8b-4683-ace7-c795c84ff989"), new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb") },
                    { new Guid("277f24e5-5288-4221-a7b0-6379a7ae6a44"), new Guid("92cd2bc7-b2d3-4a83-ab6d-ac4077c0cf43") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("bbc38532-1850-46ce-8f4d-f8f8e588e4fc"), new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb"), null, "admin" },
                    { new Guid("d7f307b7-fa3f-4500-b622-f73777d753f5"), new Guid("92cd2bc7-b2d3-4a83-ab6d-ac4077c0cf43"), null, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("53916d25-b633-480f-a17d-494c2daf1b82"), new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb"), new Guid("92cd2bc7-b2d3-4a83-ab6d-ac4077c0cf43"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("559ab69c-fb11-4863-83db-7d48aeef48ef"), "Work", new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb") },
                    { new Guid("ee59bc50-d271-426d-8e05-ef62fb6ae7fb"), "MyHome", new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f840b230-fa8b-4683-ace7-c795c84ff989"), new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("277f24e5-5288-4221-a7b0-6379a7ae6a44"), new Guid("92cd2bc7-b2d3-4a83-ab6d-ac4077c0cf43") });

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("bbc38532-1850-46ce-8f4d-f8f8e588e4fc"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d7f307b7-fa3f-4500-b622-f73777d753f5"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("53916d25-b633-480f-a17d-494c2daf1b82"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("559ab69c-fb11-4863-83db-7d48aeef48ef"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("ee59bc50-d271-426d-8e05-ef62fb6ae7fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("277f24e5-5288-4221-a7b0-6379a7ae6a44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f840b230-fa8b-4683-ace7-c795c84ff989"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("015dc6fa-ee49-45f9-862f-1197a585b1fb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("92cd2bc7-b2d3-4a83-ab6d-ac4077c0cf43"));

            migrationBuilder.RenameColumn(
                name: "TeseraId",
                table: "Games",
                newName: "TesseraId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"), "7fde8ce8-cf35-4197-97d2-794686f7672c", "User", "User" },
                    { new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"), "de0e16dc-6797-4f2c-b097-5e08ec5ab4ed", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"), 0, "4cb6cf9a-5c88-497d-8096-39b7dc5f31e0", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "10364dfe-d520-45be-9624-d23464ee5c00", false, "admin" },
                    { new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"), 0, "0b355f24-c5d4-4046-932e-f8c8129b22a7", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "b91c3e91-b252-4e20-b8ad-9da9eac60177", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") },
                    { new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("7ea4868f-b2ee-4373-b276-7d76f698d099"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"), null, "admin" },
                    { new Guid("e968c49c-3774-4dd6-adb1-34546745c2ad"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"), null, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("6b148b17-a7fd-4fb5-9010-b153ebb55b6d"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("bbbb626c-0f6d-4e55-bda3-6bbe92e67b10"), "Work", new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") },
                    { new Guid("d161eda9-5015-4feb-a931-5c178e89a15f"), "MyHome", new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") }
                });
        }
    }
}
