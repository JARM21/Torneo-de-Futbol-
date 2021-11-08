using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Municipios
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMunicipios _repoMunicipio;
        public IEnumerable <Municipio> municipio {get; set;}
        public string gActual{get; set;}

        public IndexModel(IRepositorioMunicipios repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet(string g)
        {
            if (string.IsNullOrEmpty(g))
            {
                gActual = "";
                
                municipio = _repoMunicipio.GetAllMunicipios();
            }
            else
            {
                gActual = g;
                municipio = _repoMunicipio.GetMunicipioNombre(g);
            }
        }
    }
}
