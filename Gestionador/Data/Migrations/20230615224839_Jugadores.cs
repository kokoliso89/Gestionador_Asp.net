using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestionador.Data.Migrations
{
    /// <inheritdoc />
    public partial class Jugadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estadisticas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JugadorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipoID = table.Column<int>(type: "int", nullable: false),
                    PartidosJugados = table.Column<int>(type: "int", nullable: false),
                    Canastas1Punto = table.Column<int>(type: "int", nullable: false),
                    Canastas2Puntos = table.Column<int>(type: "int", nullable: false),
                    Canastas3Puntos = table.Column<int>(type: "int", nullable: false),
                    PuntosTotales = table.Column<int>(type: "int", nullable: false),
                    RebotesTotales = table.Column<int>(type: "int", nullable: false),
                    AsistenciasTotales = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadisticas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    EquipoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    EquipoLocalID = table.Column<int>(type: "int", nullable: false),
                    EquipoVisitanteID = table.Column<int>(type: "int", nullable: false),
                    MesaPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArbitroAsistente1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArbitroAsistente2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntosLocal = table.Column<int>(type: "int", nullable: false),
                    PuntosVisitante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estadisticas");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
