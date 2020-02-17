using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class TipoEvaluacion
    {
        [Key]
        public int IdTipoEvaluacion { get; set; }
        public string NombreEvaluacion { get; set; }

    }
}
