using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Sesion
    {
        [Key]
        public int IdSesion { get; set; }
        public int AsistenciaDocente { get; set; }
        public DateTime FechaSesion { get; set; }
        public int NumeroSesion { get; set; }
        [ForeignKey("IdHorario")]
        public int IdHorario { get; set; }

        public Horario Horario { get; set; }



        #region Metodos    

        public double CalcularHorasDeLaSesion()
        {
            //double horas = Horario.HoraFin.TotalMinutes - Horario.HoraInicio.TotalMinutes;
            double horas = Horario.HoraFin.TotalHours - Horario.HoraInicio.TotalHours;
            return horas;
        }

        public bool EsFechaSesionValida()
        {
            return (FechaSesion >= DateTime.Today) ? true : false;            
        }

        public bool EsHoraInicioSesionValida()
        {
            bool decision = true;
            if(FechaSesion == DateTime.Today)
            {
                if (!Horario.EsHoraInicioCorrecta())
                    decision = false;
            }

            return decision;
        }

        #endregion Metodos

        
    }
}
