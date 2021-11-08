using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Arbitros
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioArbitros _repoArbitro;
        public Arbitro arbitro {get; set;}
        public EditModel(IRepositorioArbitros repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }
        public IActionResult OnGet(int Id)
        {
            arbitro = _repoArbitro.GetArbitro(Id);
            if (arbitro == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Arbitro arbitro)
        {
            _repoArbitro.UpdateArbitro(arbitro);
            return RedirectToPage("Index");
        }
    }
}
