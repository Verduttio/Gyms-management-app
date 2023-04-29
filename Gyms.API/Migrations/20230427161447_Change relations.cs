using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyms.API.Migrations
{
    /// <inheritdoc />
    public partial class Changerelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clubs_OpeningHoursId",
                table: "Clubs");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Coaches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ClubId",
                table: "Coaches",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_OpeningHoursId",
                table: "Clubs",
                column: "OpeningHoursId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Clubs_ClubId",
                table: "Coaches",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Clubs_ClubId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_ClubId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_OpeningHoursId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Coaches");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_OpeningHoursId",
                table: "Clubs",
                column: "OpeningHoursId");
        }
    }
}
