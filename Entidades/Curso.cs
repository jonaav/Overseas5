using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Idioma { get; set; }
        public string Nivel { get; set; }
        public string Programa { get; set; }
        public int Estado { get; set; }
        public int Ciclo { get; set; }
        public string ModalidadEstudiantes { get; set; }
        public string Detalle { get; set; }
        [ForeignKey("IdTipoCurso")]
        public int IdTipoCurso { get; set;}
        public TipoCurso TipoCurso { get; set; }

        [ForeignKey("IdDocente")]
        public int? IdDocente { get; set;}
        public virtual Docente Docente { get; set; }
        public ICollection<HistorialEvaluacion> HistorialEvaluacion { get; set; }
        public ICollection<Horario> Horario { get; set; }
        public ICollection<Inscripcion> Inscripcion { get; set; }


        #region Metodos


        //public string SoloFechaInicio()
        //{
        //    return this.FechaInicio.ToShortDateString();
        //}


        /*
         * Validar fecha fin > fecha inicio
         */

        public bool ValidarFechaFin()
        {
            return (FechaFin > FechaInicio) ? true : false;
        }

        



        #endregion Metodos


    }
}
