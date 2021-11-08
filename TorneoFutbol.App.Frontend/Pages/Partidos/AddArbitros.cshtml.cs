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
    public class AddArbitrosModel : PageModel
    {
        private readonly IRepositorioPartidos _repoPartido;
        private readonly IRepositorioArbitros _repoArbitro;
        public Partido partido {get; set;}
        public IEnumerable<Arbitro> arbitro {get; set;}

        public AddArbitrosModel(IRepositorioPartidos repoPartido, IRepositorioArbitros repoArbitro)
        {
            _repoPartido = repoPartido;
            _repoArbitro = repoArbitro;
        }
        public void OnGet(int Id)
        {
            partido = _repoPartido.GetPartido(Id);
            arbitro = _repoArbitro.GetAllArbitros();
        }

        public IActionResult OnPost(int IdPartido, int IdArbitro)
        {
            _repoPartido.AsignarArbitro(IdPartido, IdArbitro);
            return RedirectToPage("Details", new{Id = IdPartido});
        }
    }
}
