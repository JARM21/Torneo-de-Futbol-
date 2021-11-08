using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Municipios
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioMunicipios _repoMunicipio;
        public Municipio municipio {get; set;}

        public CreateModel(IRepositorioMunicipios repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet()
        {
            municipio = new Municipio();
        }

        public IActionResult OnPost(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                _repoMunicipio.AddMunicipio(municipio);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
