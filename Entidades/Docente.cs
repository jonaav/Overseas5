using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Docente
    {
        [Key]
        public int IdDocente { get; set; }
        public int Estado { get; set; }
        [ForeignKey("IdPersona")]
        public int IdPersona { get; set; }

        public Persona Persona { get; set; }
    }
}
