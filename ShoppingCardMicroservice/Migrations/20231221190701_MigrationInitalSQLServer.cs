using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCardMicroservice.Migrations
{
    public partial class MigrationInitalSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarritoSessions",
                columns: table => new
                {
                    CarritoSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSessions", x => x.CarritoSessionId);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSessionDetalles",
                columns: table => new
                {
                    CarritoSessionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarritoSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSessionDetalles", x => x.CarritoSessionDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoSessionDetalles_CarritoSessions_CarritoSessionId",
                        column: x => x.CarritoSessionId,
                        principalTable: "CarritoSessions",
                        principalColumn: "CarritoSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSessionDetalles_CarritoSessionId",
                table: "CarritoSessionDetalles",
                column: "CarritoSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSessionDetalles");

            migrationBuilder.DropTable(
                name: "CarritoSessions");
        }
    }
}
