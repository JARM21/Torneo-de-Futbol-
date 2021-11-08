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
    public class EditModel : PageModel
    {
        private readonly IRepositorioEquipos _repoEquipo;
        public Equipo equipo {get; set;}
        public EditModel(IRepositorioEquipos repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }
        public IActionResult OnGet(int Id)
        {
            equipo = _repoEquipo.GetEquipos(Id);
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Equipo equipo)
        {
            _repoEquipo.UpdateEquipos(equipo);
            return RedirectToPage("Index");
        }
    }
}
