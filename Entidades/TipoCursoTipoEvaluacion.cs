using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class TipoCursoTipoEvaluacion
    {
        [Key]
        public int idTipoCursoTipoEvaluacion { get; set; }
        [ForeignKey("IdTipoCurso")]
        public int IdTipoCurso { get; set; }
        [ForeignKey("IdTipoEvaluacion")]
        public int IdTipoEvaluacion { get; set; }
        public TipoCurso TipoCurso { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }

    }
}
