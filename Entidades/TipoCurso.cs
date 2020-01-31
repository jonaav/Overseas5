using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public partial class TipoCurso
    {
        [Key]
        public int IdTipoCurso { get; set; }
        public string NombreCurso { get; set; }

        //public ICollection<TipoCursoTipoEvaluacion> TipoCursoTipoEvaluacion { get; set; }

    }
}
