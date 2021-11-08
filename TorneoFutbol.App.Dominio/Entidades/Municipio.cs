using System;
using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
      
    public class Municipio 
    {
        // Identificador único de cada SugerenciaCuidado
        public int Id { get; set; }
        /// Nombre del municipio
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre  { get; set; }
        
    }
}