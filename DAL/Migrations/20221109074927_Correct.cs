using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class Correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "91ba74e2-db63-433d-b7e2-f77ae138b682", "0cbc4253-bbac-4cdd-9706-bd1e405b7898" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0cc42552-2bd8-4fa2-8ffe-9838d6740913", "aea5a8cc-131d-4314-933e-7c69109aae43" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cc42552-2bd8-4fa2-8ffe-9838d6740913");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ba74e2-db63-433d-b7e2-f77ae138b682");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0cbc4253-bbac-4cdd-9706-bd1e405b7898");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aea5a8cc-131d-4314-933e-7c69109aae43");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "91ba74e2-db63-433d-b7e2-f77ae138b682", "0cbc4253-bbac-4cdd-9706-bd1e405b7898" },
                    { "0cc42552-2bd8-4fa2-8ffe-9838d6740913", "aea5a8cc-131d-4314-933e-7c69109aae43" }
                });

            migrationBuilder.UpdateData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PartyCreatorId" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 41, 4, 14, DateTimeKind.Local).AddTicks(460), "0cbc4253-bbac-4cdd-9706-bd1e405b7898" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: "0cbc4253-bbac-4cdd-9706-bd1e405b7898");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: "aea5a8cc-131d-4314-933e-7c69109aae43");

            migrationBuilder.UpdateData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                values: new object[] { "0cbc4253-bbac-4cdd-9706-bd1e405b7898", "aea5a8cc-131d-4314-933e-7c69109aae43" });

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "0cbc4253-bbac-4cdd-9706-bd1e405b7898");

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "0cbc4253-bbac-4cdd-9706-bd1e405b7898");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_AccountId",
                table: "Players",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_CreatorId",
                table: "Players",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_OutRequestUserId",
                table: "UserFriends",
                column: "OutRequestUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
