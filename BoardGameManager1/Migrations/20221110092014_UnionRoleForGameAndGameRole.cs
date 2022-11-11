using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class UnionRoleForGameAndGameRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameRoles_RolesForGame_RoleForGameId",
                table: "GameRoles");

            migrationBuilder.DropTable(
                name: "RolesForGame");

            migrationBuilder.DropIndex(
                name: "IX_GameRoles_RoleForGameId",
                table: "GameRoles");

          
            migrationBuilder.DropColumn(
                name: "RoleForGameId",
                table: "GameRoles");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GameRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

         
            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mafia");

            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Player");

            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Doctor");

            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Sheriff");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropColumn(
                name: "Name",
                table: "GameRoles");

            migrationBuilder.AddColumn<int>(
                name: "RoleForGameId",
                table: "GameRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RolesForGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesForGame", x => x.Id);
                });

            
            migrationBuilder.InsertData(
                table: "RolesForGame",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mafia" },
                    { 2, "Player" },
                    { 3, "Doctor" },
                    { 4, "Sheriff" }
                });

          
        
            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleForGameId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleForGameId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleForGameId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleForGameId",
                value: 4);


            migrationBuilder.CreateIndex(
                name: "IX_GameRoles_RoleForGameId",
                table: "GameRoles",
                column: "RoleForGameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRoles_RolesForGame_RoleForGameId",
                table: "GameRoles",
                column: "RoleForGameId",
                principalTable: "RolesForGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
