using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioInformacionPartido : IRepositorioInformacionPartido
    {
        private readonly AppContext _appContext = new AppContext();
        

        InformacionPartido IRepositorioInformacionPartido.AddInformacionPartido(InformacionPartido informacionPartido)
        {
            var informacionPartidoAdicionado = _appContext.InformacionPartido.Add(informacionPartido);
            _appContext.SaveChanges();
            return informacionPartidoAdicionado.Entity;
        }

        void IRepositorioInformacionPartido.DeleteInformacionPartido(int idInformacionPartido)
        {
            var informacionPartidoEncontrado=_appContext.InformacionPartido.FirstOrDefault(i=>i.Id==idInformacionPartido);
            if(informacionPartidoEncontrado==null)
                return;
            _appContext.InformacionPartido.Remove(informacionPartidoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<InformacionPartido> IRepositorioInformacionPartido.GetAllInformacionPartido()
        {
            return _appContext.InformacionPartido;
        }

        InformacionPartido IRepositorioInformacionPartido.GetInformacionPartido(int idInformacionPartido)
        {
            return _appContext.InformacionPartido.FirstOrDefault(i=>i.Id==idInformacionPartido);
            
        }

        InformacionPartido IRepositorioInformacionPartido.UpdateInformacionPartido(InformacionPartido informacionPartido)
        {
            var informacionPartidoEncontrado=_appContext.InformacionPartido.FirstOrDefault(i=>i.Id==informacionPartido.Id);
            if(informacionPartidoEncontrado!=null)
            {
                informacionPartidoEncontrado.Evento = informacionPartido.Evento;
                informacionPartidoEncontrado.Minuto = informacionPartido.Minuto;
                informacionPartidoEncontrado.JugadorInvolucrado = informacionPartido.JugadorInvolucrado;
                informacionPartidoEncontrado.Partido = informacionPartido.Partido;
                
                _appContext.SaveChanges();
            }
            return informacionPartidoEncontrado;
        }

        Partido IRepositorioInformacionPartido.AsignPartido(int idInformacionPartido, int idPartido)
        {
            var informacionPartidoEncontrado = _appContext.InformacionPartido.Find(idInformacionPartido);
            if(informacionPartidoEncontrado != null)
            {
                var partidoEncontrado = _appContext.Partidos.Find(idPartido);
                if(partidoEncontrado != null)
                {
                    informacionPartidoEncontrado.Partido = partidoEncontrado;
                    _appContext.SaveChanges();
                }
                return partidoEncontrado;
            }
            return null;
        }
    }
}