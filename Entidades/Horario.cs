using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Horario
    {
        [Key]
        public int IdHorario { get; set; }
        public string Dia { get; set; }
        public TimeSpan HoraFin { get; set; }
        public TimeSpan HoraInicio { get; set; }
        [ForeignKey("IdCurso")]
        public int IdCurso { get; set; }
        [ForeignKey("IdAmbiente")]
        public int IdAmbiente { get; set; }
        public int EstadoHorario { get; set; }

        public Curso Curso { get; set; }

        public Ambiente Ambiente { get; set; }
    }
}
