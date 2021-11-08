using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioInformacionPartido
    {   
        IEnumerable<InformacionPartido> GetAllInformacionPartido();
        InformacionPartido AddInformacionPartido(InformacionPartido informacionPartido);
        InformacionPartido UpdateInformacionPartido(InformacionPartido informacionPartido);
        void DeleteInformacionPartido(int idInformacionPartido);
        InformacionPartido GetInformacionPartido(int idInformacionPartido);
        Partido AsignPartido(int idInformacionPartido, int idPartido);
    }
}