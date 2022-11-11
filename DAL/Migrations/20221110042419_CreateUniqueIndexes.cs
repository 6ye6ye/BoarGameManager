using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class CreateUniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_Players_AccountId",
                table: "Players");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e299add-29d1-48d0-8180-27bd46603ca8", "333129fe-f188-48ed-b2d1-745e1f573103", "User", "User" },
                    { "4c12d481-acaf-4a32-bad4-89affb3e7166", "18bb0b7a-5907-4d65-8e35-7f7fcb69567d", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "90af6fe2-9891-45be-b98e-9b09eee716d2", 0, "1e8ce347-cbb1-4a29-a165-b8d41def6346", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "301c1053-b918-4655-b1bf-548a355b846e", false, "admin@gmail.com" },
                    { "e1509a89-d92d-462a-b02c-d1abdfe4f391", 0, "f1160f08-b357-40e1-b1a2-55bbce426d09", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "b268ff44-81a5-4140-a427-6b5891bc3e99", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4c12d481-acaf-4a32-bad4-89affb3e7166", "90af6fe2-9891-45be-b98e-9b09eee716d2" },
                    { "2e299add-29d1-48d0-8180-27bd46603ca8", "e1509a89-d92d-462a-b02c-d1abdfe4f391" }
                });

            migrationBuilder.UpdateData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PartyCreatorId" },
                values: new object[] { new DateTime(2022, 11, 10, 10, 24, 18, 739, DateTimeKind.Local).AddTicks(4500), "90af6fe2-9891-45be-b98e-9b09eee716d2" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: "90af6fe2-9891-45be-b98e-9b09eee716d2");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: "e1509a89-d92d-462a-b02c-d1abdfe4f391");

            migrationBuilder.UpdateData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                values: new object[] { "90af6fe2-9891-45be-b98e-9b09eee716d2", "e1509a89-d92d-462a-b02c-d1abdfe4f391" });

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "90af6fe2-9891-45be-b98e-9b09eee716d2");

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "90af6fe2-9891-45be-b98e-9b09eee716d2");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId_GameId",
                table: "UserGames",
                columns: new[] { "UserId", "GameId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_InRequestUserId_OutRequestUserId",
                table: "UserFriends",
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                unique: true,
                filter: "[InRequestUserId] IS NOT NULL AND [OutRequestUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserGames_UserId_GameId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_InRequestUserId_OutRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_Players_AccountId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c12d481-acaf-4a32-bad4-89affb3e7166", "90af6fe2-9891-45be-b98e-9b09eee716d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e299add-29d1-48d0-8180-27bd46603ca8", "e1509a89-d92d-462a-b02c-d1abdfe4f391" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e299add-29d1-48d0-8180-27bd46603ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c12d481-acaf-4a32-bad4-89affb3e7166");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90af6fe2-9891-45be-b98e-9b09eee716d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1509a89-d92d-462a-b02c-d1abdfe4f391");

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
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId");
        }
    }
}
