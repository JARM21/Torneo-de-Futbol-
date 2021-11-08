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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartidos _repoPartido;
        public Partido partido {get; set;}

        public CreateModel(IRepositorioPartidos repoPartido)
        {
            _repoPartido = repoPartido;
        }
        public void OnGet()
        {
            partido = new Partido();
        }

        public IActionResult OnPost(Partido partido)
        {
            if (ModelState.IsValid)
            {
                _repoPartido.AddPartidos(partido);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
