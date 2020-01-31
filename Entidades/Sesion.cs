using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Sesion
    {
        [Key]
        public int IdSesion { get; set; }
        public int AsistenciaDocente { get; set; }
        public DateTime FechaSesion { get; set; }
        public int NumeroSesion { get; set; }
        [ForeignKey("IdHorario")]
        public int IdHorario { get; set; }

        public Horario Horario { get; set; }
        //public ICollection<Asistencia> Asistencia { get; set; }
    }
}
