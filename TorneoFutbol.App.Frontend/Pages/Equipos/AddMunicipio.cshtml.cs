using System.Collections;
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
    public class AddMunicipioModel : PageModel
    {
        private readonly IRepositorioEquipos _repoEquipo;
        private readonly IRepositorioMunicipios _repoMunicipio;
        public Equipo equipo {get; set;}
        public IEnumerable<Municipio> municipios {get; set;}

        public AddMunicipioModel(IRepositorioEquipos repoEquipo, IRepositorioMunicipios repoMunicipio)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet(int Id)
        {
            equipo = _repoEquipo.GetEquipos(Id);
            municipios = _repoMunicipio.GetAllMunicipios();
        }

        public IActionResult OnPost(int IdEquipo, int IdMunicipio)
        {
            _repoEquipo.AsignarMunicipio(IdEquipo, IdMunicipio);
            return RedirectToPage("Details", new{Id = IdEquipo});
        }
    }
}
