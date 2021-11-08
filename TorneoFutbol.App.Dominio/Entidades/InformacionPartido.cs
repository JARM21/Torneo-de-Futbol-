using System.Collections.Generic;

namespace TorneoFutbol.App.Dominio
{
     
    public class InformacionPartido
    {
        public int Id { get; set; }
        public Eventos Evento { get; set; }
        public int Minuto { get; set; }
        public Jugador JugadorInvolucrado { get; set; }
        public Partido Partido { get; set; }
    }
}