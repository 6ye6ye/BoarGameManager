using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGamePlaces",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserGamePlaces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InRequestUserId",
                table: "UserFriends",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OutRequestUserId",
                table: "UserFriends",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameRates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GameRates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GamePartyId",
                table: "GamePartyMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameRoleId",
                table: "GamePartyMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "GamePartyMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartyCreatorId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserGamePlaceId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces",
                columns: new[] { "UserId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_OutRequestUserId",
                table: "UserFriends",
                column: "OutRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatorId",
                table: "Players",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoles_GameId",
                table: "GameRoles",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_GameId",
                table: "GameRates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_UserId",
                table: "GameRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_GamePartyId",
                table: "GamePartyMembers",
                column: "GamePartyId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_GameRoleId",
                table: "GamePartyMembers",
                column: "GameRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_PlayerId",
                table: "GamePartyMembers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_GameId",
                table: "GameParties",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_UserGamePlaceId",
                table: "GameParties",
                column: "UserGamePlaceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_UserGamePlaces_UserGamePlaceId",
                table: "GameParties",
                column: "UserGamePlaceId",
                principalTable: "UserGamePlaces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePartyMembers_GameParties_GamePartyId",
                table: "GamePartyMembers",
                column: "GamePartyId",
                principalTable: "GameParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePartyMembers_GameRoles_GameRoleId",
                table: "GamePartyMembers",
                column: "GameRoleId",
                principalTable: "GameRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePartyMembers_Players_PlayerId",
                table: "GamePartyMembers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRates_AspNetUsers_UserId",
                table: "GameRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRates_Games_GameId",
                table: "GameRates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRoles_Games_GameId",
                table: "GameRoles",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserGamePlaces_AspNetUsers_UserId",
                table: "UserGamePlaces",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_UserGamePlaces_UserGamePlaceId",
                table: "GameParties");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePartyMembers_GameParties_GamePartyId",
                table: "GamePartyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePartyMembers_GameRoles_GameRoleId",
                table: "GamePartyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePartyMembers_Players_PlayerId",
                table: "GamePartyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRates_AspNetUsers_UserId",
                table: "GameRates");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRates_Games_GameId",
                table: "GameRates");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRoles_Games_GameId",
                table: "GameRoles");

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

            migrationBuilder.DropForeignKey(
                name: "FK_UserGamePlaces_AspNetUsers_UserId",
                table: "UserGamePlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_OutRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_Players_AccountId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CreatorId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_GameRoles_GameId",
                table: "GameRoles");

            migrationBuilder.DropIndex(
                name: "IX_GameRates_GameId",
                table: "GameRates");

            migrationBuilder.DropIndex(
                name: "IX_GameRates_UserId",
                table: "GameRates");

            migrationBuilder.DropIndex(
                name: "IX_GamePartyMembers_GamePartyId",
                table: "GamePartyMembers");

            migrationBuilder.DropIndex(
                name: "IX_GamePartyMembers_GameRoleId",
                table: "GamePartyMembers");

            migrationBuilder.DropIndex(
                name: "IX_GamePartyMembers_PlayerId",
                table: "GamePartyMembers");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_GameId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_GameParties_UserGamePlaceId",
                table: "GameParties");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserGamePlaces");

            migrationBuilder.DropColumn(
                name: "InRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "OutRequestUserId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameRoles");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameRates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameRates");

            migrationBuilder.DropColumn(
                name: "GamePartyId",
                table: "GamePartyMembers");

            migrationBuilder.DropColumn(
                name: "GameRoleId",
                table: "GamePartyMembers");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GamePartyMembers");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameParties");

            migrationBuilder.DropColumn(
                name: "PartyCreatorId",
                table: "GameParties");

            migrationBuilder.DropColumn(
                name: "UserGamePlaceId",
                table: "GameParties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGamePlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
