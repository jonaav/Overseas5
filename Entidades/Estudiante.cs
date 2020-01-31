using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public string ReferenciaEstudiante { get; set; }
        public int PoseeApoderado { get; set; }
        [ForeignKey("IdPersona")]
        public int IdPersona { get; set; }

        public Persona Persona { get; set; }
        //public ICollection<Asistencia> Asistencia { get; set; }
        //public ICollection<DetalleApoderadoEstudiante> DetalleApoderadoEstudiante { get; set; }
        //public ICollection<HistorialEvaluacion> HistorialEvaluacion { get; set; }
        //public ICollection<Inscripcion> Inscripcion { get; set; }
    }
}
