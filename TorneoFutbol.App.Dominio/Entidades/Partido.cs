using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
namespace TorneoFutbol.App.Dominio
{
     
    public class Partido
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La Fecha Y Hora son Obligatorias")]
        public DateTime FechaYHora { get; set; }
        public Equipo EquipoLocal { get; set; }
        [Required(ErrorMessage = "El Marcador Inicial es Obligatorio")]
        public int MarcadorInicialLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        [Required(ErrorMessage = "El Marcador Inicial es Obligatorio")]
        public int MarcadorInicialVisitante { get; set; }
        public Estadio Estadio { get; set; }
        public Arbitro Arbitro { get; set; }
        [Required(ErrorMessage = "El Marcador Final es Obligatorio")]
        public int MarcadorFinal { get; set; }
        public List<InformacionPartido> InformacionPartido { get; set; }
    }
}