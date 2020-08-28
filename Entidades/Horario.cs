using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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

        #region Metodos


        /*
         * Validar hora Fin > hora inicio
         */

        public bool EsHoraFinCorrecta()
        {
            return (HoraFin > HoraInicio) ? true : false;
        }

        public bool EsHoraInicioCorrecta()
        {
            TimeSpan now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            return (HoraInicio > now) ? true : false;
        }



        /* nuevohorai <= inicio y nuevohoraf <= inicio
         * nuevohorai > fin y nuevohoraf > fin
         */

        public bool VerificarCruce(Horario h)
        {
            if ((HoraInicio <= h.HoraInicio && HoraFin <= h.HoraInicio) || 
                (HoraInicio >= h.HoraFin    && HoraFin >= h.HoraFin))
                return true;
            else
                return false;
        }

        /*
         * Comparar el dia actual con el horario
         */
        public bool EsDiaCorrespondiente()
        {
            CultureInfo ci = new CultureInfo("Es-Es");
            var hoy = ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            return (Dia.ToUpper() == hoy.ToUpper()) ? true : false;
        }


        #endregion Metodos
    }
}
