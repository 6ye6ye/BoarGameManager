using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameManager1.Migrations
{
    public partial class AddGameRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
              table: "Games",
              keyColumn: "Id",
              keyValue: 1,
              column: "Rating",
              value: 0.0);

            migrationBuilder.Sql(@"UPDATE [dbo].[Games] SET [Rating] = 0.0 WHERE [Rating] IS NULL");
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GameRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          
            migrationBuilder.CreateIndex(
                name: "IX_GameRates_GameId",
                table: "GameRates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_UserId",
                table: "GameRates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRates");

         

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Games",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

        
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: null);

         
        }
    }
}
