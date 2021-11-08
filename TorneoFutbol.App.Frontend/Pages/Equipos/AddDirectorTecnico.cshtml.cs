using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Equipos
{
    public class AddDirectorTecnicoModel : PageModel
    {
        private readonly IRepositorioEquipos _repoEquipo;
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        public Equipo equipo {get; set;}
        public IEnumerable<DirectorTecnico> directorestecnicos {get; set;}

        public AddDirectorTecnicoModel(IRepositorioEquipos repoEquipo, IRepositorioDirectorTecnico repoDirectorTecnico)
        {
            _repoEquipo = repoEquipo;
            _repoDirectorTecnico = repoDirectorTecnico;
        }
        public void OnGet(int Id)
        {
            equipo = _repoEquipo.GetEquipos(Id);
            directorestecnicos = _repoDirectorTecnico.GetAllDirectoresTecnicos();
        }

        public IActionResult OnPost(int IdEquipo, int IdDirectorTecnico)
        {
            _repoEquipo.AsignarDirectorTecnico(IdEquipo, IdDirectorTecnico);
            return RedirectToPage("Details", new{Id = IdEquipo});
        }
    }
}
