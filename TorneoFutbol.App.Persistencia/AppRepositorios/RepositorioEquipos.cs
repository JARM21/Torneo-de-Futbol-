using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioEquipos : IRepositorioEquipos
    {
        private readonly AppContext _appContext = new AppContext();
        

        Equipo IRepositorioEquipos.AddEquipos(Equipo Equipos)
        {
            var EquipoAdicionado = _appContext.Equipos.Add(Equipos);
            _appContext.SaveChanges();
            return EquipoAdicionado.Entity;
        }

        void IRepositorioEquipos.DeleteEquipos(int IdEquipos)
        {
            var EquipoEncontrado=_appContext.Equipos.FirstOrDefault(m=>m.Id==IdEquipos);
            if(EquipoEncontrado==null)
                return;
            _appContext.Equipos.Remove(EquipoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Equipo> IRepositorioEquipos.GetAllEquipos()
        {
            return _appContext.Equipos;
        }

        public Equipo GetEquipos(int IdEquipos)
        {
            var equipo = _appContext.Equipos
                .Where(p => p.Id == IdEquipos)
                .Include(p => p.Municipio)
                .Include(p => p.DirectorTecnico)
                
                .FirstOrDefault();
            return equipo;
            
        }

        Equipo IRepositorioEquipos.UpdateEquipos(Equipo Equipo)
        {
            var EquipoEncontrado=_appContext.Equipos.FirstOrDefault(m=>m.Id==Equipo.Id);
            if(EquipoEncontrado!=null)
            {
                EquipoEncontrado.Nombre = Equipo.Nombre;
                EquipoEncontrado.CantidadPartidosJugados = Equipo.CantidadPartidosJugados;
                EquipoEncontrado.CantidadPartidosEmpatados = Equipo.CantidadPartidosEmpatados;
                EquipoEncontrado.GolesAFavor = Equipo.GolesAFavor;
                EquipoEncontrado.GolesEnContra = Equipo.GolesEnContra;
                EquipoEncontrado.Puntos = Equipo.Puntos;
                
                
                _appContext.SaveChanges();
            }
            return EquipoEncontrado;
        }

        Municipio IRepositorioEquipos.AsignarMunicipio(int IdEquipo, int IdMunicipio)
        { var equipoEncontrado = _appContext.Equipos.Find(IdEquipo);
            if (equipoEncontrado != null)
            { var municipioEncontrado = _appContext.Municipios.Find(IdMunicipio);
            if (municipioEncontrado != null)
            { equipoEncontrado.Municipio = municipioEncontrado;
            _appContext.SaveChanges();
            }
            return municipioEncontrado;
            }
            return null;
        }

        DirectorTecnico IRepositorioEquipos.AsignarDirectorTecnico(int IdEquipo, int IdDirectorTecnico)
        { var equipoEncontrado = _appContext.Equipos.Find(IdEquipo);
            if (equipoEncontrado != null)
            { var directortecnicoEncontrado = _appContext.DirectoresTecnicos.Find(IdDirectorTecnico);
            if (directortecnicoEncontrado != null)
            { equipoEncontrado.DirectorTecnico = directortecnicoEncontrado;
            _appContext.SaveChanges();
            }
            return directortecnicoEncontrado;
            }
            return null;
        }
        public IEnumerable<Equipo> GetEquipoNombre(string nombre)
        {
            return _appContext.Equipos
                   .Where(P => P.Nombre.Contains(nombre));
        }

        
    }
}
