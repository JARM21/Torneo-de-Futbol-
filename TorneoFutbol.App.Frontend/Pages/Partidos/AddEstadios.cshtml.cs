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
    public class AddEstadiosModel : PageModel
    {
        private readonly IRepositorioPartidos _repoPartido;
        private readonly IRepositorioEstadios _repoEstadio;
        public Partido partido {get; set;}
        public IEnumerable<Estadio> estadio {get; set;}

        public AddEstadiosModel(IRepositorioPartidos repoPartido, IRepositorioEstadios repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEstadio = repoEstadio;
        }
        public void OnGet(int Id)
        {
            partido = _repoPartido.GetPartido(Id);
            estadio = _repoEstadio.GetAllEstadios();
        }
        public IActionResult OnPost(int IdPartido, int IdEstadio)
        {
            _repoPartido.AsignarEstadio(IdPartido, IdEstadio);
            return RedirectToPage("Details", new{Id = IdPartido});
        }
    }
}
