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
            .Where(h => h.IdCurso == idCurso && h.EstadoHorario == 1)                                                                 
            .Include(h => h.Ambiente)
            .Include(h => h.Curso).ThenInclude(c => c.TipoCurso)
            .Include(h => h.Curso).ThenInclude(c => c.Docente).ThenInclude(d => d.Persona)
            .ToList();

       
        private List<Horario> BuscarHorariosAmbiente(int idHorario, int idAmbiente, string dia) => _context.Horario
            .Where(h => (h.IdAmbiente == idAmbiente && h.Dia == dia && 
                            h.IdHorario != idHorario && h.EstadoHorario == 1))
            .ToList();
        private List<Sesion> BuscarSesionesPorFecha(int idHorario, DateTime fecha, int idAmbiente) => _context.Sesion
            .Where(s => (s.FechaSesion == fecha && s.Horario.IdAmbiente == idAmbiente &&
                            s.Horario.IdHorario != idHorario && s.Horario.EstadoHorario == 1))
            .Include(s => s.Horario)                                                                             
                .ThenInclude(h => h.Ambiente)            
            .ToList();
        

        
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

        public void EliminarHorariosCurso(List<Horario> listaHorarios)
        {                             
            try
            {                
                foreach (Horario horario in listaHorarios)
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

        public bool CrearHorarios(List<Horario> listaHorarios)
        {
            try
            {
                foreach (Horario horario in listaHorarios)
                {
                    if(BuscarHorario(horario.IdHorario) == null)
                    {
                        horario.IdHorario = 0;
                        _context.Horario.Add(horario);
                        _context.SaveChanges();
                    }                    
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
            List<Sesion> sesiones = BuscarSesionesPorFecha(sesionEvaluar.Horario.IdHorario, sesionEvaluar.FechaSesion, sesionEvaluar.Horario.IdAmbiente);
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

        public bool DeshabilitarHorariosCurso(int idCurso)
        {
            List<Horario> horarios = BuscarHorariosCurso(idCurso);
            try
            {
                foreach (Horario horario in horarios)
                {
                    horario.EstadoHorario = 2;
                    _context.Horario.Attach(horario);
                    _context.Horario.Update(horario);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  REMAKE
         */


        /*
         *  CREAR HORARIO
         */
        public bool CrearHorario(Horario horario)
        {
            try
            {
                horario.EstadoHorario = 1;
                _context.Horario.Add(horario);
                _context.SaveChanges();               
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         *  EDITAR HORARIO
         */
        public bool EditarHorario(Horario horario)
        {
            try
            {
                _context.Horario.Attach(horario);
                _context.Horario.Update(horario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        

        public Horario BuscarHorario(int idHorario) => _context.Horario
                                                       .Where(h => h.IdHorario == idHorario)
                                                       .Include(h => h.Ambiente)
                                                       .Include(h => h.Curso)
                                                       .FirstOrDefault();


        /*
         * buscar horario por ambiente, dia, estado=1
         */
        public List<Horario> BuscarHorariosPorAmbienteDia(Horario nuevo) => _context.Horario
            .Where(h => (h.EstadoHorario == 1 && h.Dia == nuevo.Dia && h.IdAmbiente == nuevo.IdAmbiente ))
            .Include(h => h.Ambiente)
            .Include(h => h.Curso)
                .ThenInclude(c => c.TipoCurso)
            .Include(h => h.Curso)
                .ThenInclude(c => c.Docente)
            .ToList();

    }
}
