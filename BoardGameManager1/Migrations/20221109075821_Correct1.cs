using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class Correct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bac8fb03-d70f-41f1-85c8-15de3a44f1e2", "4191aa0f-f893-4e02-ba18-a8667f9f6ac3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d47018e-8f20-40d9-962e-34949c110076", "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d47018e-8f20-40d9-962e-34949c110076");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac8fb03-d70f-41f1-85c8-15de3a44f1e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4191aa0f-f893-4e02-ba18-a8667f9f6ac3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "935e687b-2179-4f7c-a870-db99706539e1", "8646fbce-a05a-4228-acf4-4519bf0d52ee", "User", "User" },
                    { "b5945110-7255-4b32-b266-fbf0e84e2f3a", "ea717a44-2d31-4f6b-b606-7e96328beac3", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "97d5ff10-58d2-4d9c-ab5f-a6c052183937", 0, "2b8384fb-a802-4af3-ad62-0135b11b80e3", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "bfa1636a-c045-4ac2-b06a-0532fdd349bb", false, "user@gmail.com" },
                    { "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef", 0, "3867f3f4-ab05-4ec6-9dc4-b41e77de8d9e", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "216d3fc5-89c6-4c6f-9c0a-f04b5ec1df26", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "935e687b-2179-4f7c-a870-db99706539e1", "97d5ff10-58d2-4d9c-ab5f-a6c052183937" },
                    { "b5945110-7255-4b32-b266-fbf0e84e2f3a", "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef" }
                });

            migrationBuilder.UpdateData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PartyCreatorId" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 58, 21, 29, DateTimeKind.Local).AddTicks(3852), "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: "97d5ff10-58d2-4d9c-ab5f-a6c052183937");

            migrationBuilder.UpdateData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                values: new object[] { "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef", "97d5ff10-58d2-4d9c-ab5f-a6c052183937" });

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef");

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "935e687b-2179-4f7c-a870-db99706539e1", "97d5ff10-58d2-4d9c-ab5f-a6c052183937" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b5945110-7255-4b32-b266-fbf0e84e2f3a", "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935e687b-2179-4f7c-a870-db99706539e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5945110-7255-4b32-b266-fbf0e84e2f3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97d5ff10-58d2-4d9c-ab5f-a6c052183937");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5a4182e-d71f-4cf5-b1a9-bdec83afa7ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d47018e-8f20-40d9-962e-34949c110076", "450674b5-dee2-469b-9d87-7eb1a68b5660", "Admin", "Admin" },
                    { "bac8fb03-d70f-41f1-85c8-15de3a44f1e2", "6022db93-a922-4479-90f3-4a779156a673", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4191aa0f-f893-4e02-ba18-a8667f9f6ac3", 0, "ecfad1a0-9e19-4f0a-b769-6d9bb7cda572", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "1f79697d-fc2e-4856-93bc-3f368bdb23bd", false, "user@gmail.com" },
                    { "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5", 0, "b4ce29c5-ffa7-4c22-af3d-b6738ef23e83", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "68fbf8bf-3b8a-4deb-8f37-4b56ccea0abb", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bac8fb03-d70f-41f1-85c8-15de3a44f1e2", "4191aa0f-f893-4e02-ba18-a8667f9f6ac3" },
                    { "0d47018e-8f20-40d9-962e-34949c110076", "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5" }
                });

            migrationBuilder.UpdateData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PartyCreatorId" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 49, 27, 107, DateTimeKind.Local).AddTicks(1431), "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: "4191aa0f-f893-4e02-ba18-a8667f9f6ac3");

            migrationBuilder.UpdateData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                values: new object[] { "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5", "4191aa0f-f893-4e02-ba18-a8667f9f6ac3" });

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5");

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "d9760a26-0cc7-4e7c-be4d-e4c403bf82f5");
        }
    }
}
