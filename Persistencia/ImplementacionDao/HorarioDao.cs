using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class HorarioDao : IHorarioDao
    {
        private readonly DB_OverseasContext _context;
        public HorarioDao(DB_OverseasContext context)
        {
            _context = context;
        }

        public List<Horario> BuscarHorariosCurso(int idCurso)
        {
            List<Horario> horarios = new List<Horario>();
            try
            {
                horarios = (from h in _context.Horario
                            join c in _context.Curso on h.Curso.IdCurso equals c.IdCurso
                            join a in _context.Ambiente on h.IdAmbiente equals a.IdAmbiente
                            where h.IdCurso == idCurso 

                            select new Horario
                            {
                                IdHorario = h.IdHorario,
                                Dia = h.Dia,
                                HoraInicio = h.HoraInicio,
                                HoraFin = h.HoraFin,
                                IdCurso = h.IdCurso,
                                IdAmbiente = h.IdAmbiente,
                                Curso =  new Curso
                                {
                                    IdCurso = c.IdCurso
                                },
                                Ambiente = new Ambiente
                                {
                                    IdAmbiente = a.IdAmbiente,
                                    Aula = a.Aula,
                                    DescripcionAmbiente = a.DescripcionAmbiente,
                                    Direccion = a.Direccion                                    
                                }
                            }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return horarios;
        }

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

    }
}
