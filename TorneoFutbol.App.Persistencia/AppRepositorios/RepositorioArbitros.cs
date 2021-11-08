using System;
using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioArbitros : IRepositorioArbitros
    {
        private readonly AppContext _appContext = new AppContext();
    

        Arbitro IRepositorioArbitros.AddArbitro(Arbitro arbitro)
        {
            var arbitroAdicionado = _appContext.Arbitros.Add(arbitro);
            _appContext.SaveChanges();
            return arbitroAdicionado.Entity;
        }

        void IRepositorioArbitros.DeleteArbitro(int idArbitro)
        {
            var arbitroEncontrado=_appContext.Arbitros.FirstOrDefault(m=>m.Id==idArbitro);
            if(arbitroEncontrado==null)
                return;
            _appContext.Arbitros.Remove(arbitroEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Arbitro> IRepositorioArbitros.GetAllArbitros()
        {
            return _appContext.Arbitros;
        }

        Arbitro IRepositorioArbitros.GetArbitro(int idArbitro)
        {
            return _appContext.Arbitros.FirstOrDefault(m=>m.Id==idArbitro);
            
        }

        Arbitro IRepositorioArbitros.UpdateArbitro(Arbitro arbitro)
        {
            var arbitroEncontrado=_appContext.Arbitros.FirstOrDefault(m=>m.Id==arbitro.Id);
            if(arbitroEncontrado!=null)
            {
                arbitroEncontrado.Nombre = arbitro.Nombre;
                arbitroEncontrado.Documento = arbitro.Documento;
                _appContext.SaveChanges();
            }
            return arbitroEncontrado;
        }
        public IEnumerable<Arbitro> GetArbitroNombre(string nombre)
        {
            return _appContext.Arbitros
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}