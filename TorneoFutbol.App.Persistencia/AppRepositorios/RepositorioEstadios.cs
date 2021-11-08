using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioEstadios : IRepositorioEstadios
    {
        private readonly AppContext _appContext = new AppContext();
        

        Estadio IRepositorioEstadios.AddEstadio(Estadio estadio)
        {
            var estadioAdicionado = _appContext.Estadios.Add(estadio);
            _appContext.SaveChanges();
            return estadioAdicionado.Entity;
        }

        void IRepositorioEstadios.DeleteEstadio(int idEstadio)
        {
            var estadioEncontrado=_appContext.Estadios.FirstOrDefault(e=>e.Id==idEstadio);
            if(estadioEncontrado==null)
                return;
            _appContext.Estadios.Remove(estadioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Estadio> IRepositorioEstadios.GetAllEstadios()
        {
            return _appContext.Estadios;
        }

        Estadio IRepositorioEstadios.GetEstadio(int idEstadio)
        {
            return _appContext.Estadios.FirstOrDefault(e=>e.Id==idEstadio);
            
        }

        Estadio IRepositorioEstadios.UpdateEstadio(Estadio estadio)
        {
            var estadioEncontrado=_appContext.Estadios.FirstOrDefault(e=>e.Id==estadio.Id);
            if(estadioEncontrado!=null)
            {
                estadioEncontrado.Nombre = estadio.Nombre;
                estadioEncontrado.Direccion = estadio.Direccion;
                estadioEncontrado.Municipio = estadio.Municipio;
                
                _appContext.SaveChanges();
            }
            return estadioEncontrado;
        }

        public Estadio GetEstadio(int IdEstadio)
        {
            var estadio = _appContext.Estadios
                .Where(e => e.Id == IdEstadio)
                .Include(e => e.Municipio)
                .FirstOrDefault();
            return estadio;
            
        }

        Municipio IRepositorioEstadios.AsignarMunicipio(int IdEstadio, int IdMunicipio)
        { var estadioEncontrado = _appContext.Estadios.Find(IdEstadio);
            if (estadioEncontrado != null)
            { var municipioEncontrado = _appContext.Municipios.Find(IdMunicipio);
            if (municipioEncontrado != null)
            { estadioEncontrado.Municipio = municipioEncontrado;
            _appContext.SaveChanges();
            }
            return municipioEncontrado;
            }
            return null;
        }
        public IEnumerable<Estadio> GetEstadioNombre(string nombre)
        {
            return _appContext.Estadios
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}