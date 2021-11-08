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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioEquipos _repoEquipo;
        public Equipo equipo {get; set;}

        public CreateModel(IRepositorioEquipos repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }
        public void OnGet()
        {
            equipo = new Equipo();
        }

        public IActionResult OnPost(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _repoEquipo.AddEquipos(equipo);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
