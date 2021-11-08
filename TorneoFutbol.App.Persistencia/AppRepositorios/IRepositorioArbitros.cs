using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioArbitros
    {   
        IEnumerable<Arbitro> GetAllArbitros();
        Arbitro AddArbitro(Arbitro arbitro);
        Arbitro UpdateArbitro(Arbitro arbitro);
        void DeleteArbitro(int idArbitro);
        Arbitro GetArbitro(int idArbitros);
        public IEnumerable<Arbitro> GetArbitroNombre(string nombre);
    }
}