using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class GamePartiesSetGameNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("466398d3-0ba9-4845-a9d4-e2323e8c439f"), new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5bfca672-bf0f-47de-8a87-8e12dda03fea"), new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359") });

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c2773453-6d6f-4c50-ab47-40b563f4075a"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d742dc30-c8b1-4415-9829-3acffc19ce7b"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("16380b66-1636-4a50-9bb5-341d869e3780"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("1f871d0f-b7be-4918-9b90-646b6034a5fe"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("63baca01-7381-4943-a0d3-b962ac5467f8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("466398d3-0ba9-4845-a9d4-e2323e8c439f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5bfca672-bf0f-47de-8a87-8e12dda03fea"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"));

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GameParties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a3e4c777-01c6-4da2-9e0d-a484cf6f9e53"), "b782ad4d-6ff1-4ed2-913d-f3afa31c4ee6", "User", "User" },
                    { new Guid("d78c27cb-7dea-4d10-941c-25b0da5cc316"), "9e50beb8-1202-401b-9e92-549d15a6fbbd", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a"), 0, "acb7a201-3b13-45e9-bc96-11e53a09838d", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "0210cfd7-a69f-4b6a-9f2a-017424001722", false, "admin" },
                    { new Guid("e3ed884b-5ca2-45ec-8cd7-b0318b475d5f"), 0, "32d2a06b-55bd-4c17-afb9-405ac2822612", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "6b00202f-5efe-4bff-a29d-9a5af1acb10b", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d78c27cb-7dea-4d10-941c-25b0da5cc316"), new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a") },
                    { new Guid("a3e4c777-01c6-4da2-9e0d-a484cf6f9e53"), new Guid("e3ed884b-5ca2-45ec-8cd7-b0318b475d5f") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("95547a45-a09e-4d5d-9652-4ad3614107aa"), new Guid("e3ed884b-5ca2-45ec-8cd7-b0318b475d5f"), null, "user" },
                    { new Guid("d34c4e32-a7a1-40d4-93b6-119ff6327ef9"), new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a"), null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("66d6e313-a33e-4222-a902-079d7e771f83"), new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a"), new Guid("e3ed884b-5ca2-45ec-8cd7-b0318b475d5f"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("450272f1-e487-4702-8beb-ad5d0e8fcb74"), "Work", new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a") },
                    { new Guid("b0089db9-85be-4864-8921-e7d987297699"), "MyHome", new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d78c27cb-7dea-4d10-941c-25b0da5cc316"), new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a3e4c777-01c6-4da2-9e0d-a484cf6f9e53"), new Guid("e3ed884b-5ca2-45ec-8cd7-b0318b475d5f") });

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("95547a45-a09e-4d5d-9652-4ad3614107aa"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d34c4e32-a7a1-40d4-93b6-119ff6327ef9"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("66d6e313-a33e-4222-a902-079d7e771f83"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("450272f1-e487-4702-8beb-ad5d0e8fcb74"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("b0089db9-85be-4864-8921-e7d987297699"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3e4c777-01c6-4da2-9e0d-a484cf6f9e53"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d78c27cb-7dea-4d10-941c-25b0da5cc316"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("37bd3f88-dcb9-4909-9703-ddd005f0e42a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e3ed884b-5ca2-45ec-8cd7-b0318b475d5f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
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
                    { new Guid("466398d3-0ba9-4845-a9d4-e2323e8c439f"), "f754335b-0827-46eb-8aff-d7b7cbb06016", "User", "User" },
                    { new Guid("5bfca672-bf0f-47de-8a87-8e12dda03fea"), "61f7d472-a065-431e-8166-185209da101a", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"), 0, "4f1ea01d-26bf-4e2d-8089-12a8f5c1fd5d", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "16abf1ee-4d4d-4e91-a3fc-7a476b263dc1", false, "user" },
                    { new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"), 0, "52fb6e47-730d-4e59-b5de-de1c7aa09f8c", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "caa6feeb-906e-4cc7-a3db-5f554dc8c46c", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("466398d3-0ba9-4845-a9d4-e2323e8c439f"), new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc") },
                    { new Guid("5bfca672-bf0f-47de-8a87-8e12dda03fea"), new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("c2773453-6d6f-4c50-ab47-40b563f4075a"), new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"), null, "admin" },
                    { new Guid("d742dc30-c8b1-4415-9829-3acffc19ce7b"), new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"), null, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("16380b66-1636-4a50-9bb5-341d869e3780"), new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"), new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f871d0f-b7be-4918-9b90-646b6034a5fe"), "Work", new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359") },
                    { new Guid("63baca01-7381-4943-a0d3-b962ac5467f8"), "MyHome", new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359") }
                });
        }
    }
}
