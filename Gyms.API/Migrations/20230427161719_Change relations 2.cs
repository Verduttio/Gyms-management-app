using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyms.API.Migrations
{
    /// <inheritdoc />
    public partial class Changerelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Clubs_ClubId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_ClubId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Coaches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Coaches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ClubId",
                table: "Coaches",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Clubs_ClubId",
                table: "Coaches",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }
    }
}
