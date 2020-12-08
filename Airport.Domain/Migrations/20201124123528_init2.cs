using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Domain.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.AirplaneId);
                });

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    PassangerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.PassangerId);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "AirplaneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    PassangerId = table.Column<int>(type: "int", nullable: false),
                    DateOfReservation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.SeatId, x.PassangerId, x.DateOfReservation });
                    table.ForeignKey(
                        name: "FK_Reservation_Passangers_PassangerId",
                        column: x => x.PassangerId,
                        principalTable: "Passangers",
                        principalColumn: "PassangerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassangerId",
                table: "Reservation",
                column: "PassangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_AirplaneId",
                table: "Seat",
                column: "AirplaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Airplanes");
        }
    }
}
