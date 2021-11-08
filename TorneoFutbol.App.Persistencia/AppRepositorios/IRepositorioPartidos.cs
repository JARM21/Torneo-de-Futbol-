using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioPartidos
    {   
        IEnumerable<Partido> GetAllPartidos();
        Partido AddPartidos(Partido partidos);
        Partido UpdatePartido(Partido partidos);
        void DeletePartidos(int partidos);
        Partido GetPartido(int partido);
        Equipo AsignarEquipolocal(int IdPartido, int IdEquipo);
        Equipo AsignarEquipovisitante(int IdPartido, int IdEquipo);
        Estadio AsignarEstadio(int IdPartido, int IdEstadio);
        Arbitro AsignarArbitro(int IdPartido, int IdArbitro);
        public InformacionPartido AsignarInfoPartido(int IdPartido, InformacionPartido inforPartido);
    }
}