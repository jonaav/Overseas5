using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Inscripcion
    {
        [Key]
        public int IdInscripcion { get; set; }
        public int EstadoInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }
        [ForeignKey("IdEstudiante")]
        public int IdEstudiante { get; set; }
        [ForeignKey("IdCurso")]
        public int IdCurso { get; set; }

        public Curso Curso { get; set; }
        public Estudiante Estudiante { get; set; }


    }
}
