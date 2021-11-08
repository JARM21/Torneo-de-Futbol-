//using Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Consola
{
    class Program
    {
        private static IRepositorioDirectorTecnico _repoDirectorTecnico = new RepositorioDirectorTecnico();
        private static IRepositorioEquipos _repoEquipo = new RepositorioEquipos();
        private static IRepositorioMunicipios _repoMunicipio = new RepositorioMunicipios();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddMunicipio();
            //AddEquipos();
            //AddDirectoresTecnicos();
            //BuscarDirectoresTecnicos(1);

        }

        private static void AddDirectoresTecnicos()
        {
            var DirectoresTecnicos = new DirectorTecnico
            {
                Nombre = "Isabella",
                Documento = "1232444",
                Telefono = "318943572"
            };

            _repoDirectorTecnico.AddDirectoresTecnicos(DirectoresTecnicos);
        }

        private static void BuscarDirectoresTecnicos(int IdDirectoresTecnicos)
        {
            var DirectoresTecnicos = _repoDirectorTecnico.GetDirectoresTecnicos(IdDirectoresTecnicos);
            Console.WriteLine(DirectoresTecnicos.Nombre + " " + DirectoresTecnicos.Documento);
        }
        
        
        private static void AddEquipos()
        {
            var Equipos = new Equipo
            {
                Nombre = "Aguilas Doradas",
                CantidadPartidosJugados = 0,
                CantidadPartidosEmpatados = 0,
                GolesAFavor = 0,
                GolesEnContra = 0,
                Puntos = 0
                
            };

            _repoEquipo.AddEquipos(Equipos);
        }

        private static void AddMunicipio()
        {
            var Municipios = new Municipio
            {
                Nombre = "Marinilla"
               
            };

            _repoMunicipio.AddMunicipio(Municipios);
        }
    }

}
