using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class SetNullGameParies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties");

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties");
 

            migrationBuilder.AddForeignKey(
                name: "FK_GameParties_Games_GameId",
                table: "GameParties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
