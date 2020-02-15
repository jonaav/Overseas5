using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Evaluacion
    {
        [Key]
        public int IdEvaluacion { get; set; }
        public int CalificacionEvaluacion { get; set; }
        [ForeignKey("IdHistorialEvaluacion")]
        public int IdHistorialEvaluacion { get; set; }
        [ForeignKey("IdTipoEvaluacion")]
        public int IdTipoEvaluacion { get; set; }

        public TipoEvaluacion TipoEvaluacion { get; set; }
        public HistorialEvaluacion HistorialEvaluacion { get; set; }
    }
}
