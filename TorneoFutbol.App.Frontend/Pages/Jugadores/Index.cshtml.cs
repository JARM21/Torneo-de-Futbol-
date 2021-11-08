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
    public class IndexModel : PageModel
    {
        private readonly IRepositorioJugadores _repoJugador;
        public IEnumerable <Jugador> jugador {get; set;}
        public Jugador Jugador{get; set;}
        public string gActual{get; set;}
        

        public IndexModel(IRepositorioJugadores repoJugador)
        {
            _repoJugador = repoJugador;
        }

        public void OnGet(string g)
        {
            if (string.IsNullOrEmpty(g))
            {
                gActual = "";
                
                jugador = _repoJugador.GetAllJugador();
            }
            else
            {
                gActual = g;
                jugador = _repoJugador.GetJugadoresNombre(g);
            }
            
        }
     
        
    }
}
