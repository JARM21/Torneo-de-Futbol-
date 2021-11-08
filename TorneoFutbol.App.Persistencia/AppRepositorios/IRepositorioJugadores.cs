using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioJugadores
    {   
        IEnumerable<Jugador> GetAllJugador();
        Jugador AddJugador(Jugador jugador);
        Jugador UpdateJugador(Jugador jugador);
        void DeleteJugador(int idJugador);
        Jugador GetJugador(int idJugador);
        Equipo AsignarEquipo(int IdJugador, int IdEquipo);
        public IEnumerable<Jugador> GetJugadoresNombre(string nombre);

    }
}