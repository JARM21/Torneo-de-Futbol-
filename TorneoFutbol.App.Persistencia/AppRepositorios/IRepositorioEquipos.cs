using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioEquipos
    {
        IEnumerable<Equipo> GetAllEquipos();

        Equipo AddEquipos(Equipo Equipos);

        Equipo UpdateEquipos(Equipo Equipos);

        void DeleteEquipos(int IdEquipos);

        Equipo GetEquipos(int IdEquipos);

        Municipio AsignarMunicipio(int IdEquipo, int IdMunicipio);

        DirectorTecnico AsignarDirectorTecnico(int IdEquipo, int IdDirectorTecnico);
        public IEnumerable<Equipo> GetEquipoNombre(string nombre);

    }
}