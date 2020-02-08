using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Traduccion
    {
        [Key]
        public int IdTraduccion { get; set; }
        public string ClienteTraduccion { get; set; }
        public string TipoTraduccion { get; set; }
        public string DetalleTraduccion { get; set; }
        public string IdiomaOrigenTraduccion { get; set; }
        public string IdiomaDestinoTraduccion { get; set; }
        public DateTime FechaTraduccion { get; set; }
        public int EstadoTraduccion { get; set; }
        [ForeignKey("IdDocente")]
        public int? IdDocente { get; set; }

        public Docente Docente { get; set; }
    }
}
