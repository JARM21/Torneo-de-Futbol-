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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioJugadores _repoJugador;
        public Jugador jugador {get; set;}
        public CreateModel(IRepositorioJugadores repoJugador)
        {
            _repoJugador = repoJugador;
        }
        public void OnGet()
        {
             jugador = new Jugador();
        }

        public IActionResult OnPost(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _repoJugador.AddJugador(jugador);
                return RedirectToPage("Index");
            }

            else
            {
                return Page();
            }
            
        }
    }
}
