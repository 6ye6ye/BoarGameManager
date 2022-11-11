using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class AddGameToGameParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GameParties",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2914c25-2fc2-49f1-bb96-788252594fda", "4499dfac-1c3f-4ef4-a515-b30c415cd2d4", "Admin", "Admin" },
                    { "efbb345e-44ab-435a-a018-4e698cf50bc6", "53a66dda-22a1-41a1-af01-b6426c63dbfa", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04963b95-e838-4648-a0fd-92ecb4e5883c", 0, "416c11df-02c0-407a-a02b-1d17c6388ca4", "user@gmail.com", false, false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "766e900e-6b89-4f79-a994-03890d8cce5f", false, "user@gmail.com" },
                    { "ad3ee538-1452-45c9-8bc1-5332356b8576", 0, "a09a3042-e6b9-4a09-b0ae-ffa117d3d2cc", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "28c63c33-2fbd-4127-84ec-f788c4ead232", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "efbb345e-44ab-435a-a018-4e698cf50bc6", "04963b95-e838-4648-a0fd-92ecb4e5883c" },
                    { "d2914c25-2fc2-49f1-bb96-788252594fda", "ad3ee538-1452-45c9-8bc1-5332356b8576" }
                });

            migrationBuilder.UpdateData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "PartyCreatorId" },
                values: new object[] { new DateTime(2022, 11, 10, 10, 58, 35, 162, DateTimeKind.Local).AddTicks(1646), "ad3ee538-1452-45c9-8bc1-5332356b8576" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: "ad3ee538-1452-45c9-8bc1-5332356b8576");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: "04963b95-e838-4648-a0fd-92ecb4e5883c");

            migrationBuilder.UpdateData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InRequestUserId", "OutRequestUserId" },
                values: new object[] { "ad3ee538-1452-45c9-8bc1-5332356b8576", "04963b95-e838-4648-a0fd-92ecb4e5883c" });

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "ad3ee538-1452-45c9-8bc1-5332356b8576");

            migrationBuilder.UpdateData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "ad3ee538-1452-45c9-8bc1-5332356b8576");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_GameId",
                table: "GameParties",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_GameId",
                table: "GameParties");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "efbb345e-44ab-435a-a018-4e698cf50bc6", "04963b95-e838-4648-a0fd-92ecb4e5883c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2914c25-2fc2-49f1-bb96-788252594fda", "ad3ee538-1452-45c9-8bc1-5332356b8576" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2914c25-2fc2-49f1-bb96-788252594fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efbb345e-44ab-435a-a018-4e698cf50bc6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04963b95-e838-4648-a0fd-92ecb4e5883c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad3ee538-1452-45c9-8bc1-5332356b8576");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameParties");

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
        }
    }
}
