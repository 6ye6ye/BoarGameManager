using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class CreateUniqueGamePlaceIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserGamePlaces_UserId",
                table: "UserGamePlaces");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGamePlaces",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c31789d-9d18-4c65-8653-eea7c93e0096", "b2da1a1d-21cf-4d96-b1fe-a2287783f0d4", "User", "User" },
                    { "517715e4-2683-4b45-9f3a-374efcbbe5ae", "c2e8fb50-1431-42f8-9078-1693511fb232", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "495c75e1-9a89-4817-8524-9329fad30e57", 0, "80cb0b28-0ad8-4d22-87f2-92c2d5ca2a5b", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "2e04240d-684b-4f26-b1cd-c87595ac1629", false, "user@gmail.com" },
                    { "4b772e40-d931-4c96-a3fb-68cb9edb6362", 0, "cf8086ca-99a2-41c8-b3c9-0225477f88f0", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "11195537-da47-49e3-8b35-252bd89bfedf", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1c31789d-9d18-4c65-8653-eea7c93e0096", "495c75e1-9a89-4817-8524-9329fad30e57" },
                    { "517715e4-2683-4b45-9f3a-374efcbbe5ae", "4b772e40-d931-4c96-a3fb-68cb9edb6362" }
                });

            migrationBuilder.UpdateData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PartyCreatorId" },
                values: new object[] { new DateTime(2022, 11, 10, 10, 21, 51, 890, DateTimeKind.Local).AddTicks(2780), "4b772e40-d931-4c96-a3fb-68cb9edb6362" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: "4b772e40-d931-4c96-a3fb-68cb9edb6362");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: "495c75e1-9a89-4817-8524-9329fad30e57");

            migrationBuilder.UpdateData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                values: new object[] { "4b772e40-d931-4c96-a3fb-68cb9edb6362", "495c75e1-9a89-4817-8524-9329fad30e57" });

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "4b772e40-d931-4c96-a3fb-68cb9edb6362");

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "4b772e40-d931-4c96-a3fb-68cb9edb6362");

            migrationBuilder.CreateIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces",
                columns: new[] { "UserId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1c31789d-9d18-4c65-8653-eea7c93e0096", "495c75e1-9a89-4817-8524-9329fad30e57" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "517715e4-2683-4b45-9f3a-374efcbbe5ae", "4b772e40-d931-4c96-a3fb-68cb9edb6362" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c31789d-9d18-4c65-8653-eea7c93e0096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "517715e4-2683-4b45-9f3a-374efcbbe5ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "495c75e1-9a89-4817-8524-9329fad30e57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b772e40-d931-4c96-a3fb-68cb9edb6362");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGamePlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserGamePlaces_UserId",
                table: "UserGamePlaces",
                column: "UserId");
        }
    }
}
