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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioPartidos _repoPartido;
        public Partido partido {get; set;}
        public DetailsModel(IRepositorioPartidos repoPartido)
        {
            _repoPartido = repoPartido;
        }
        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
