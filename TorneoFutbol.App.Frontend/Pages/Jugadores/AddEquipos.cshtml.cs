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
    public class AddEquiposModel : PageModel
    {
        private readonly IRepositorioJugadores _repoJugador;
        private readonly IRepositorioEquipos _repoEquipo;
        public Jugador jugador {get; set;}
        public IEnumerable<Equipo> equipos {get; set;}

        public AddEquiposModel(IRepositorioJugadores repoJugador, IRepositorioEquipos repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
        }
        public void OnGet(int Id)
        {
            jugador = _repoJugador.GetJugador(Id);
            equipos = _repoEquipo.GetAllEquipos();
        }
        public IActionResult OnPost(int IdJugador, int IdEquipo)
        {
            _repoJugador.AsignarEquipo(IdJugador, IdEquipo);
            return RedirectToPage("Details", new{Id = IdJugador});
        }
    }
}
