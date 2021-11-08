using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioDirectorTecnico
    {
        IEnumerable<DirectorTecnico> GetAllDirectoresTecnicos();

        DirectorTecnico AddDirectoresTecnicos(DirectorTecnico DirectoresTecnicos);

        DirectorTecnico UpdateDirectoresTecnicos(DirectorTecnico DirectoresTecnicos);

        void DeleteDirectoresTecnicos(int IdDirectoresTecnicos);

        DirectorTecnico GetDirectoresTecnicos(int IdDirectoresTecnicos);
        public IEnumerable<DirectorTecnico> GetDirectorTecnicoNombre(string nombre);
    }
}