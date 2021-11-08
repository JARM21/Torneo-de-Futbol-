using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
   
    public class Estadio
    {

        // Identificador del estadio
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        // Nombre del estadio 
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Direccion es Obligatoria")]
        // Dirección del estadio
        public string Direccion { get; set; }
        // Municipio al que pertenece 
        public Municipio Municipio { get; set; } 
    }
}