using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioMunicipios
    {   
        IEnumerable<Municipio> GetAllMunicipios();
        Municipio AddMunicipio(Municipio municipio);
        Municipio UpdateMunicipio(Municipio municipio);
        void DeleteMunicipio(int idMunicipio);
        Municipio GetMunicipio(int idMunicipio);
        public IEnumerable<Municipio> GetMunicipioNombre(string nombre);
    }
}