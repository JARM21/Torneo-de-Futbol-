using System.Collections.Generic;
namespace TorneoFutbol.App.Dominio
{
     
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadPartidosJugados { get; set; }
        public int CantidadPartidosGanados { get; set; }
        public int CantidadPartidosEmpatados { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public int Puntos { get; set; }
        public Municipio Municipio { get; set; }
        ///  Referencia a la lista de jugadores
    
        public DirectorTecnico DirectorTecnico { get; set; }
    }
}