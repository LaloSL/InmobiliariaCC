using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace InmobiliariaCC.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inquilino",
                columns: table => new
                {
                    IdInquilino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilino", x => x.IdInquilino);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    IdPropietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.IdPropietario);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inmueble",
                columns: table => new
                {
                    IdInmueble = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPropietario = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    TipoInmueble = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: false),
                    PrecioPorDia = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Disponible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PorcentajeReserva = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmueble", x => x.IdInmueble);
                    table.ForeignKey(
                        name: "FK_Inmueble_Propietario_IdPropietario",
                        column: x => x.IdPropietario,
                        principalTable: "Propietario",
                        principalColumn: "IdPropietario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdInquilino = table.Column<int>(type: "int", nullable: false),
                    IdInmueble = table.Column<int>(type: "int", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MontoPorDia = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    FechaFinAnticipada = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Inmueble_IdInmueble",
                        column: x => x.IdInmueble,
                        principalTable: "Inmueble",
                        principalColumn: "IdInmueble",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Inquilino_IdInquilino",
                        column: x => x.IdInquilino,
                        principalTable: "Inquilino",
                        principalColumn: "IdInquilino",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_IdPropietario",
                table: "Inmueble",
                column: "IdPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdInmueble",
                table: "Reserva",
                column: "IdInmueble");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdInquilino",
                table: "Reserva",
                column: "IdInquilino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Inmueble");

            migrationBuilder.DropTable(
                name: "Inquilino");

            migrationBuilder.DropTable(
                name: "Propietario");
        }
    }
}
