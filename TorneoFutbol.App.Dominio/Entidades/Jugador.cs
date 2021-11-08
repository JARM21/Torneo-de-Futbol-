using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
   
   
    public class Jugador
    {
        

        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Numero es Obligatorio")]

        public int Numero { get; set; }
        [Required(ErrorMessage = "La Posicion es Obligatorio")]

        public string Posicion { get; set; }
        public Equipo Equipo { get; set; }

        
        
    }
}