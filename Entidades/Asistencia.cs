using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Asistencia
    {
        [Key]
        public int IdAsistencia { get; set; }
        public int AsistenciaEstudiante { get; set; }
        [ForeignKey("IdEstudiante")]
        public int IdEstudiante { get; set; }
        [ForeignKey("IdSesion")]
        public int IdSesion { get; set; }

        public Estudiante Estudiante { get; set; }
        public Sesion Sesion { get; set; }
    }
}
