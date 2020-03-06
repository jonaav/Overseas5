using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class HistorialEvaluacion
    {
        [Key]
        public int IdHistorialEvaluacion { get; set; }
        public string FeedbackHistorialEvaluacion { get; set; }
        [ForeignKey("IdEstudiante")]
        public int IdEstudiante { get; set; }
        [ForeignKey("IdCurso")]
        public int IdCurso { get; set; }

        public Curso Curso { get; set; }
        public Estudiante Estudiante { get; set; }


        public int CalcularPromedio(List<Evaluacion> evaluaciones)
        {
            int suma = 0;
            foreach (Evaluacion e in evaluaciones)
            {
                suma += e.CalificacionEvaluacion;
            }
            return suma / evaluaciones.Count;
        }



    }
}
