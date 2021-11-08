using System;
using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioMunicipios : IRepositorioMunicipios
    {
        private readonly AppContext _appContext = new AppContext();
        
        Municipio IRepositorioMunicipios.AddMunicipio(Municipio municipio)
        {
            var MunicipioAdicionado = _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return MunicipioAdicionado.Entity;
        }

        void IRepositorioMunicipios.DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado=_appContext.Municipios.FirstOrDefault(m=>m.Id==idMunicipio);
            if(municipioEncontrado==null)
                return;
            _appContext.Municipios.Remove(municipioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Municipio> IRepositorioMunicipios.GetAllMunicipios()
        {
            return _appContext.Municipios;
        }

        Municipio IRepositorioMunicipios.GetMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.FirstOrDefault(m=>m.Id==idMunicipio);
            
        }

        Municipio IRepositorioMunicipios.UpdateMunicipio(Municipio municipio)
        {
            var municipioEncontrado=_appContext.Municipios.FirstOrDefault(m=>m.Id==municipio.Id);
            if(municipioEncontrado!=null)
            {
                municipioEncontrado.Nombre = municipio.Nombre;
                _appContext.SaveChanges();
            }
            return municipioEncontrado;
        }
        public IEnumerable<Municipio> GetMunicipioNombre(string nombre)
        {
            return _appContext.Municipios
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}