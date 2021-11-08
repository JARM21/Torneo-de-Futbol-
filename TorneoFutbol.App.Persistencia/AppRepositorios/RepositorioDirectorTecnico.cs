using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioDirectorTecnico : IRepositorioDirectorTecnico
    {
        private readonly AppContext _appContext = new AppContext();
        
        DirectorTecnico IRepositorioDirectorTecnico.AddDirectoresTecnicos(DirectorTecnico DirectoresTecnicos)
        {
            var DirectorTecnicoAdicionado = _appContext.DirectoresTecnicos.Add(DirectoresTecnicos);
            _appContext.SaveChanges();
            return DirectorTecnicoAdicionado.Entity;
        }

        void IRepositorioDirectorTecnico.DeleteDirectoresTecnicos(int IdDirectoresTecnicos)
        {
            var DirectorTecnicoEncontrado=_appContext.DirectoresTecnicos.FirstOrDefault(m=>m.Id==IdDirectoresTecnicos);
            if(DirectorTecnicoEncontrado==null)
                return;
            _appContext.DirectoresTecnicos.Remove(DirectorTecnicoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<DirectorTecnico> IRepositorioDirectorTecnico.GetAllDirectoresTecnicos()
        {
            return _appContext.DirectoresTecnicos;
        }

        DirectorTecnico IRepositorioDirectorTecnico.GetDirectoresTecnicos(int IdDirectoresTecnicos)
        {
            return _appContext.DirectoresTecnicos.FirstOrDefault(m=>m.Id==IdDirectoresTecnicos);
            
        }

        DirectorTecnico IRepositorioDirectorTecnico.UpdateDirectoresTecnicos(DirectorTecnico DirectorTecnico)
        {
            var DirectorTecnicoEncontrado=_appContext.DirectoresTecnicos.FirstOrDefault(m=>m.Id==DirectorTecnico.Id);
            if(DirectorTecnicoEncontrado!=null)
            {
                DirectorTecnicoEncontrado.Nombre = DirectorTecnico.Nombre;
                DirectorTecnicoEncontrado.Documento = DirectorTecnico.Documento;
                DirectorTecnicoEncontrado.Telefono = DirectorTecnico.Telefono;
                _appContext.SaveChanges();
            }
            return DirectorTecnicoEncontrado;
        }
        public IEnumerable<DirectorTecnico> GetDirectorTecnicoNombre(string nombre)
        {
            return _appContext.DirectoresTecnicos
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}


