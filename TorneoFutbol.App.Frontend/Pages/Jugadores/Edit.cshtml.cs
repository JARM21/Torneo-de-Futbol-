using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Jugadores
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioJugadores _repoJugador;
        public Jugador jugador {get; set;}
        public EditModel(IRepositorioJugadores repoJugador)
        {
            _repoJugador = repoJugador;
        }
        public IActionResult OnGet(int Id)
        {
            jugador = _repoJugador.GetJugador(Id);
            if (jugador == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Jugador jugador)
        {
            _repoJugador.UpdateJugador(jugador);
            return RedirectToPage("Index");
        }
    }
}
