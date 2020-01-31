using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public partial class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }
        public string DescripcionEspecialidad { get; set; }

        //public ICollection<DetalleDocenteEspecialidad> DetalleDocenteEspecialidad { get; set; }
    }
}
