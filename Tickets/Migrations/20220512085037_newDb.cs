using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tickets.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperationType = table.Column<string>(type: "text", nullable: true),
                    OperationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OperationPlace = table.Column<string>(type: "text", nullable: true),
                    AirlineCode = table.Column<string>(type: "text", nullable: true),
                    FlightNum = table.Column<int>(type: "integer", nullable: false),
                    DepartPlace = table.Column<string>(type: "text", nullable: true),
                    DepartDatetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ArrivePlace = table.Column<string>(type: "text", nullable: true),
                    ArriveDatetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    DocType = table.Column<string>(type: "text", nullable: true),
                    DocNumber = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    PassengerType = table.Column<string>(type: "text", nullable: true),
                    TicketNumber = table.Column<string>(type: "text", nullable: true),
                    TicketType = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Segments_TicketNumber_SerialNumber",
                table: "Segments",
                columns: new[] { "TicketNumber", "SerialNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");
        }
    }
}
