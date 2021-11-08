using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Estadios
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEstadios _repoEstadio;
        public IEnumerable <Estadio> estadio {get; set;}
        public string gActual{get; set;}
        public IndexModel(IRepositorioEstadios repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }
        public void OnGet(string g)
        {
            if (string.IsNullOrEmpty(g))
            {
                gActual = "";
                
                estadio = _repoEstadio.GetAllEstadios();
            }
            else
            {
                gActual = g;
                estadio = _repoEstadio.GetEstadioNombre(g);
            }
        }
    }
}
