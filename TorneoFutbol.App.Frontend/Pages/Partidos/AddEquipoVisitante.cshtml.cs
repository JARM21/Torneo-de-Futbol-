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
    public class AddEquipoVisitanteModel : PageModel
    {
        private readonly IRepositorioPartidos _repoPartido;
        private readonly IRepositorioEquipos _repoEquipo;
        public Partido partido {get; set;}
        public IEnumerable<Equipo> equipo {get; set;}

        public AddEquipoVisitanteModel(IRepositorioPartidos repoPartido, IRepositorioEquipos repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }
        public void OnGet(int Id)
        {
            partido = _repoPartido.GetPartido(Id);
            equipo = _repoEquipo.GetAllEquipos();
        }

        public IActionResult OnPost(int IdPartido, int IdEquipo)
        {
            _repoPartido.AsignarEquipovisitante(IdPartido, IdEquipo);
            return RedirectToPage("Details", new{Id = IdPartido});
        }
    }
}