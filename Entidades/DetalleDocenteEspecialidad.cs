using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class DetalleDocenteEspecialidad
    {
        [Key]
        public int IdDetalleDocenteEspecialidad { get; set; }
        [ForeignKey("IdDocente")]
        public int IdDocente { get; set; }
        [ForeignKey("IdEspecialidad")]
        public int IdEspecialidad { get; set; }

        public Docente Docente { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}
