using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyms.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Name", "Address" },
                values: new object[] { 1, "Silownia A", "Krakow" }
            );

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "FirstName", "LastName", "YearOfBirth" },
                values: new object[] { 1, "John", "Doe", 1980 }
            );

            migrationBuilder.InsertData(
                table: "OpeningHours",
                columns: new[] { "Id", "MondayFrom", "MondayTo", "TuesdayFrom", "TuesdayTo", "WednesdayFrom", "WednesdayTo", "ThursdayFrom", "ThursdayTo", "FridayFrom", "FridayTo", "SaturdayFrom", "SaturdayTo", "SundayFrom", "SundayTo" },
                values: new object[] { 1, "8:00", "20:00", "8:00", "20:00", "8:00", "20:00", "8:00", "20:00", "8:00", "20:00", "8:00", "20:00", "8:00", "20:00" }
            );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Title", "Day", "Time", "Duration", "ClubId", "CoachId", "ParticipantsLimit", "Regular", "ParticipantsNumber", "Cancelled" },
                values: new object[] { 1, "2023-07-20", "Bieganie", 4, "10:00", "1:00", 1, 1, 10, false, 1, false }
            );

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Title", "Day", "Time", "Duration", "ClubId", "CoachId", "ParticipantsLimit", "Regular", "ParticipantsNumber", "Cancelled" },
                values: new object[] { 2, "2023-07-23", "Konkurs", 0, "17:00", "2:00", 1, 1, 20, false, 2, false }
            );

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "EventId", "Name", "Surname" },
                values: new object[] { 1, 1, "Bruce", "Wayne" }
            );

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "EventId", "Name", "Surname" },
                values: new object[] { 2, 2, "John", "Kowalski" }
            );

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "EventId", "Name", "Surname" },
                values: new object[] { 3, 2, "Will", "Smith" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1
            );
        }
    }
}
