using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class DetalleApoderadoEstudiante
    {
        [Key]
        public int IdDetalleApodEst { get; set; }
        [ForeignKey("IdEstudiante")]
        public int IdEstudiante { get; set; }
        [ForeignKey("IdApoderado")]
        public int IdApoderado { get; set; }

        public Apoderado Apoderado { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}
