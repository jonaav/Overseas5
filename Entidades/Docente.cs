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
        //public ICollection<DetalleDocenteEspecialidad> DetalleDocenteEspecialidad { get; set; }
        //public ICollection<Curso> Curso { get; set; }
        //public ICollection<Traduccion> Traduccion { get; set; }
    }
}
