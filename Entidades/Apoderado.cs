using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public partial class Apoderado
    {
        [Key]
        public int IdApoderado { get; set; }
        public string NombresApoderado { get; set; }
        public string ApellidosApoderado { get; set; }
        public string CorreoApoderado { get; set; }

        public DetalleApoderadoEstudiante DetalleApoderadoEstudiante { get; set; }
    }
}
