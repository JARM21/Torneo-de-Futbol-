using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Arbitros
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioArbitros _repoArbitro;
        public IEnumerable <Arbitro> arbitro {get; set;}
        public string gActual{get; set;}
        public IndexModel(IRepositorioArbitros repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }
        public void OnGet(string g)
        {
            if (string.IsNullOrEmpty(g))
            {
                gActual = "";
                
                arbitro = _repoArbitro.GetAllArbitros();
            }
            else
            {
                gActual = g;
                arbitro = _repoArbitro.GetArbitroNombre(g);
            }
        }
    }
}
