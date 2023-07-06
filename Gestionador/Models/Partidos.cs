namespace Gestionador.Models
{
    public class Partidos
    {
        public int ID { get; set; }
        public string Dia { get; set; }
        public TimeSpan Hora { get; set; }
        public int EquipoLocalID { get; set; }
        public int EquipoVisitanteID { get; set; }
        public string MesaPrincipal { get; set; }
        public string ArbitroAsistente1 { get; set; }
        public string ArbitroAsistente2 { get; set; }
        public int PuntosLocal { get; set; }
        public int PuntosVisitante { get; set; }

    }
}
