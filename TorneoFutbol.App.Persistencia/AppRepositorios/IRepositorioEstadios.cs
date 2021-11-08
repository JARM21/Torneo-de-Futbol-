using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioEstadios
    {   
        IEnumerable<Estadio> GetAllEstadios();
        Estadio AddEstadio(Estadio estadio);
        Estadio UpdateEstadio(Estadio estadio);
        void DeleteEstadio(int idEstadio);
        Estadio GetEstadio(int idEstadio);

        Municipio AsignarMunicipio(int IdEstadio, int IdMunicipio);
        public IEnumerable<Estadio> GetEstadioNombre(string nombre);
    }
}