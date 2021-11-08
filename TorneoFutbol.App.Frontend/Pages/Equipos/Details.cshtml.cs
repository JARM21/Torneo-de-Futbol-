using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioEquipos _repoEquipo;
        public Equipo equipo {get; set;}
        public DetailsModel(IRepositorioEquipos repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }
        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipos(id);
            if (equipo == null)
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
