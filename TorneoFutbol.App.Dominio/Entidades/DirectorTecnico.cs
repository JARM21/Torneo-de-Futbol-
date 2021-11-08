using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
    
    public class DirectorTecnico
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Documento es Obligatorio")]

        public string Documento { get; set; }
        [Required(ErrorMessage = "El Telefono es Obligatorio")]

        public string Telefono { get; set; }
    }
}