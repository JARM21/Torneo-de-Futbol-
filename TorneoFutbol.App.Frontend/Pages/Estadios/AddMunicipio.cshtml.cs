using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Estadios
{
    public class AddMunicipioModel : PageModel
    {
        private readonly IRepositorioEstadios _repoEstadio;
        private readonly IRepositorioMunicipios _repoMunicipio;
        public Estadio estadio {get; set;}
        public IEnumerable<Municipio> municipios {get; set;}

        public AddMunicipioModel(IRepositorioEstadios repoEstadio, IRepositorioMunicipios repoMunicipio)
        {
            _repoEstadio = repoEstadio;
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet(int Id)
        {
            estadio = _repoEstadio.GetEstadio(Id);
            municipios = _repoMunicipio.GetAllMunicipios();
        }

        public IActionResult OnPost(int IdEstadio, int IdMunicipio)
        {
            _repoEstadio.AsignarMunicipio(IdEstadio, IdMunicipio);
            return RedirectToPage("Details", new{Id = IdEstadio});
        }
    }
}
