using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class HorarioDao : IHorarioDao
    {
        private readonly DB_OverseasContext _context;
        public HorarioDao(DB_OverseasContext context) => _context = context;


        public List<Horario> BuscarHorariosCurso(int idCurso) => _context.Horario
                                                                 .Where(h => h.IdCurso == idCurso)                                                                 
                                                                 .Include(h => h.Ambiente)
                                                                 .ToList();

       
        private List<Horario> BuscarHorariosAmbiente(int idHorario, int idAmbiente, string dia) => _context.Horario
                                                                        .Where(h => (h.IdAmbiente == idAmbiente && h.Dia == dia && 
                                                                                     h.IdHorario != idHorario))
                                                                        .ToList();
        private List<Sesion> BuscarSesionesPorFecha(int idSesion, DateTime fecha, int idAmbiente) => _context.Sesion
                                                                        .Where(s => (s.FechaSesion == fecha && s.Horario.IdAmbiente == idAmbiente &&
                                                                                     s.IdSesion != idSesion))
                                                                        .Include(s => s.Horario)
                                                                            .ThenInclude(h => h.Ambiente)
                                                                        .ToList();

        public bool CrearHorarios(List<Horario> listaHorarios, List<Sesion> listaSesiones)
        {
            try
            {                
                int indice = 0;
                foreach (Horario horario in listaHorarios)
                {
                    _context.Horario.Add(horario);
                    _context.SaveChanges();                    
                    listaSesiones[indice].IdHorario = horario.IdHorario;
                    _context.Sesion.Add(listaSesiones[indice]);
                    _context.SaveChanges();
                    indice++;
                }                                
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditarHorariosCurso(List<Horario> listaHorarios, List<Sesion> listaSesionesActuales, int idCurso)
        {
            try
            {
                EliminarSesionesHorarioCurso(listaSesionesActuales);
                EliminarHorariosCurso(idCurso);
                CrearHorariosRegular(listaHorarios);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarSesionesHorarioCurso(List<Sesion> listaSesionesActuales)
        {
            try
            {
                foreach (Sesion sesion in listaSesionesActuales)
                {
                    _context.Sesion.Attach(sesion);
                    _context.Sesion.Remove(sesion);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarHorariosCurso(int idCurso)
        {
                
            List<Horario> horarios = BuscarHorariosCurso(idCurso);
            try
            {                
                foreach (Horario horario in horarios)
                {
                    _context.Horario.Attach(horario);
                    _context.Horario.Remove(horario);
                    _context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public int ObtenerIdUltimoHorario()
        {
            Horario horario = _context.Horario.OrderByDescending(h => h.IdHorario).FirstOrDefault();
            return horario.IdHorario;
        }

        public bool CrearHorariosRegular(List<Horario> listaHorarios)
        {
            try
            {
                foreach (Horario horario in listaHorarios)
                {
                    _context.Horario.Add(horario);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EsHorarioPermitido(Horario horarioEvaluar)
        {
            List<Horario> horarios = BuscarHorariosAmbiente(horarioEvaluar.IdHorario, horarioEvaluar.IdAmbiente, horarioEvaluar.Dia);
            bool correcto = true;
            foreach (Horario h in horarios)
            {
                if ((horarioEvaluar.HoraFin <= h.HoraInicio) || (horarioEvaluar.HoraInicio > h.HoraFin))
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                    break;
                }
            }        
            return correcto;
        }

        public bool EsSesionPermitida(Sesion sesionEvaluar)
        {
            List<Sesion> sesiones = BuscarSesionesPorFecha(sesionEvaluar.IdSesion, sesionEvaluar.FechaSesion, sesionEvaluar.Horario.IdAmbiente);
            bool correcto = true;
            foreach (Sesion s in sesiones)
            {
                if ((sesionEvaluar.Horario.HoraFin <= s.Horario.HoraInicio) || (sesionEvaluar.Horario.HoraInicio > s.Horario.HoraFin))
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                    break;
                }
            }
            return correcto;
        }
    }
}
