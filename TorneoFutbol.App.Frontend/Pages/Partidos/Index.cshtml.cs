using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Partidos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPartidos _repoPartido;
        public IEnumerable <Partido> partido {get; set;}
        public IndexModel(IRepositorioPartidos repoPartido)
        {
            _repoPartido = repoPartido;
        }
        public void OnGet()
        {
            partido = _repoPartido.GetAllPartidos();
        }
    }
}
