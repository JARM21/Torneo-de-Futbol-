using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.DirectoresTecnicos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        public DirectorTecnico directortecnico {get; set;}
        public CreateModel(IRepositorioDirectorTecnico repoDirectorTecnico)
        {
            _repoDirectorTecnico = repoDirectorTecnico;
        }
        public void OnGet()
        {
            directortecnico = new DirectorTecnico();
        }

        public IActionResult OnPost(DirectorTecnico directortecnico)
        {
            if (ModelState.IsValid)
            {
                _repoDirectorTecnico.AddDirectoresTecnicos(directortecnico);
                return RedirectToPage("Index");
            }

            else
            {
                return Page(); 
            }
            
        }
    }
}
