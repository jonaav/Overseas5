using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public partial class Ambiente
    {
        [Key]
        public int IdAmbiente { get; set; }
        public int Estado { get; set; }
        public string Aula { get; set; }
        public string DescripcionAmbiente { get; set;}
        public string Direccion { get; set;}
        //public ICollection<Horario> Horarios { get; set; }
    }
}
