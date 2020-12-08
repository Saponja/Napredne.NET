using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Domain.Migrations
{
    public partial class inti3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Passangers_PassangerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Seat_SeatId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PassangerId",
                table: "Reservations",
                newName: "IX_Reservations_PassangerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                columns: new[] { "SeatId", "PassangerId", "DateOfReservation" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Passangers_PassangerId",
                table: "Reservations",
                column: "PassangerId",
                principalTable: "Passangers",
                principalColumn: "PassangerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seat_SeatId",
                table: "Reservations",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Passangers_PassangerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seat_SeatId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PassangerId",
                table: "Reservation",
                newName: "IX_Reservation_PassangerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                columns: new[] { "SeatId", "PassangerId", "DateOfReservation" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Passangers_PassangerId",
                table: "Reservation",
                column: "PassangerId",
                principalTable: "Passangers",
                principalColumn: "PassangerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Seat_SeatId",
                table: "Reservation",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
