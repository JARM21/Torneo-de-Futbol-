using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioPartidos : IRepositorioPartidos
    {
        private readonly AppContext _appContext = new AppContext();
        

        Partido IRepositorioPartidos.AddPartidos(Partido partidos)
        {
            var partidoAdicionado = _appContext.Partidos.Add(partidos);
            _appContext.SaveChanges();
            return partidoAdicionado.Entity;
        }

        void IRepositorioPartidos.DeletePartidos(int idPartidos)
        {
            var partidoEncontrado=_appContext.Partidos.FirstOrDefault(p=>p.Id==idPartidos);
            if(partidoEncontrado==null)
                return;
            _appContext.Partidos.Remove(partidoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Partido> IRepositorioPartidos.GetAllPartidos()
        {
            return _appContext.Partidos;
        }

        Partido IRepositorioPartidos.GetPartido(int idPartido)
        {
            return _appContext.Partidos.FirstOrDefault(p=>p.Id==idPartido);
            
        }

        Partido IRepositorioPartidos.UpdatePartido(Partido partido)
        {
            var partidoEncontrado=_appContext.Partidos.FirstOrDefault(p=>p.Id==partido.Id);
            if(partidoEncontrado!=null)
            {
                partidoEncontrado.FechaYHora = partido.FechaYHora;
                
                partidoEncontrado.MarcadorInicialLocal = partido.MarcadorInicialLocal;
               
                partidoEncontrado.MarcadorInicialVisitante = partido.MarcadorInicialVisitante;
               
                partidoEncontrado.MarcadorFinal = partido.MarcadorFinal;
                
                _appContext.SaveChanges();
            }
            return partidoEncontrado;
        }
        public Partido GetPartido(int IdPartido)
        {
            var partido = _appContext.Partidos
                .Where(pa => pa.Id == IdPartido)
                .Include(pa => pa.EquipoLocal)
                .Include(pa => pa.EquipoVisitante)
                .Include(pa => pa.Estadio)
                .Include(pa => pa.Arbitro)
                .Include(pa => pa.InformacionPartido)
                .FirstOrDefault();
            return partido;
            
        }

        Equipo IRepositorioPartidos.AsignarEquipolocal(int IdPartido, int IdEquipo)
        { var partidoEncontrado = _appContext.Partidos.Find(IdPartido);
            if (partidoEncontrado != null)
            { var equipoEncontrado = _appContext.Equipos.Find(IdEquipo);
            if (equipoEncontrado != null)
            { partidoEncontrado.EquipoLocal = equipoEncontrado;
            _appContext.SaveChanges();
            }
            return equipoEncontrado;
            }
            return null;
        }

        Equipo IRepositorioPartidos.AsignarEquipovisitante(int IdPartido, int IdEquipo)
        { var partidoEncontrado = _appContext.Partidos.Find(IdPartido);
            if (partidoEncontrado != null)
            { var equipoEncontrado = _appContext.Equipos.Find(IdEquipo);
            if (equipoEncontrado != null)
            { partidoEncontrado.EquipoVisitante = equipoEncontrado;
            _appContext.SaveChanges();
            }
            return equipoEncontrado;
            }
            return null;
        }

        Estadio IRepositorioPartidos.AsignarEstadio(int IdPartido, int IdEstadio)
        { var partidoEncontrado = _appContext.Partidos.Find(IdPartido);
            if (partidoEncontrado != null)
            { var estadioEncontrado = _appContext.Estadios.Find(IdEstadio);
            if (estadioEncontrado != null)
            { partidoEncontrado.Estadio = estadioEncontrado;
            _appContext.SaveChanges();
            }
            return estadioEncontrado;
            }
            return null;
        }
        Arbitro IRepositorioPartidos.AsignarArbitro(int IdPartido, int IdArbitro)
        { var partidoEncontrado = _appContext.Partidos.Find(IdPartido);
            if (partidoEncontrado != null)
            { var arbitroEncontrado = _appContext.Arbitros.Find(IdArbitro);
            if (arbitroEncontrado != null)
            { partidoEncontrado.Arbitro = arbitroEncontrado;
            _appContext.SaveChanges();
            }
            return arbitroEncontrado;
            }
            return null;
        }

        public InformacionPartido AsignarInfoPartido(int IdPartido, InformacionPartido inforPartido)
        {
            var partidoEncontrado = _appContext.Partidos
                .Where(pa => pa.Id == IdPartido)
                .Include(pa => pa.InformacionPartido)
                .FirstOrDefault();
            if (partidoEncontrado != null)
            {
                partidoEncontrado.InformacionPartido.Add(inforPartido);
                _appContext.SaveChanges();
                return inforPartido;
            }
            return null;
        }
    }
}