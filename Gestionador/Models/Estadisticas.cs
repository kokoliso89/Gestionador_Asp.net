namespace Gestionador.Models
{
    public class Estadisticas
    {
        public int ID { get; set; }
        public string JugadorID { get; set; }
        public int EquipoID { get; set; }
        public int PartidosJugados { get; set; }
        public int Canastas1Punto { get; set; }
        public int Canastas2Puntos { get; set; }
        public int Canastas3Puntos { get; set; }
        public int PuntosTotales { get; set; }
        public int RebotesTotales { get; set; }
        public int AsistenciasTotales { get; set; }
   
    }
}
