using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class SetLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartyCreatorId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("41b00840-ac57-44a9-ba17-c1a38feb4f66"), "9660f6f4-4ef2-4f9d-b5a4-aa512957aaa1", "Admin", "Admin" },
                    { new Guid("b80a3cd3-f1b1-49bb-9792-2319b8949557"), "4437d247-9fcc-4e57-b7d9-84274f07c257", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"), 0, "6f71d685-e9a2-418c-895b-a94750c81a0d", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "656f1900-24ba-4302-a496-8b27213bcba4", false, "admin" },
                    { new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"), 0, "356ca530-5983-4da3-8e13-36525ea3175c", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "d93c02c8-60e1-4541-978d-b621463333ca", false, "use" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[] { new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"), "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("41b00840-ac57-44a9-ba17-c1a38feb4f66"), new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe") },
                    { new Guid("b80a3cd3-f1b1-49bb-9792-2319b8949557"), new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("28d54e59-c1ac-4054-bb11-aff6c8a3c93a"), new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"), "Player" },
                    { new Guid("41945b37-f493-4976-b1e1-f925d845789d"), new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"), "Sheriff" },
                    { new Guid("a17d0dbb-43bf-4d93-8c5c-1138bdde42f8"), new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"), "Doctor" },
                    { new Guid("cdb63d90-a48f-4f49-98ae-ed6da9b0dfe0"), new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"), "Mafia" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("aeddcba3-4211-44ec-8a43-d2e74e0c31d8"), new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"), null, "admin" },
                    { new Guid("b3af6add-b12d-471c-9db0-f5bddd4e9a0c"), new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"), null, "use" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("7c90d75d-ccf2-40d4-b171-5445e3e3668b"), new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"), new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("3159f8e1-8dc6-4169-85e4-09f74a44e3c7"), "Work", new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe") },
                    { new Guid("8d04ffc6-43fd-49e8-b63d-562cb826a9fe"), "MyHome", new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("4fd52939-3cae-471d-bb36-b66e8c8faab5"), new DateTime(2022, 11, 24, 14, 3, 50, 225, DateTimeKind.Local).AddTicks(8241), new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"), new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"), new Guid("8d04ffc6-43fd-49e8-b63d-562cb826a9fe") });

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("41b00840-ac57-44a9-ba17-c1a38feb4f66"), new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b80a3cd3-f1b1-49bb-9792-2319b8949557"), new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("4fd52939-3cae-471d-bb36-b66e8c8faab5"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("28d54e59-c1ac-4054-bb11-aff6c8a3c93a"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("41945b37-f493-4976-b1e1-f925d845789d"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("a17d0dbb-43bf-4d93-8c5c-1138bdde42f8"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdb63d90-a48f-4f49-98ae-ed6da9b0dfe0"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("aeddcba3-4211-44ec-8a43-d2e74e0c31d8"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b3af6add-b12d-471c-9db0-f5bddd4e9a0c"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("7c90d75d-ccf2-40d4-b171-5445e3e3668b"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("3159f8e1-8dc6-4169-85e4-09f74a44e3c7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41b00840-ac57-44a9-ba17-c1a38feb4f66"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b80a3cd3-f1b1-49bb-9792-2319b8949557"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("8d04ffc6-43fd-49e8-b63d-562cb826a9fe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PartyCreatorId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
