using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class SesionDao : ISesionDao
    {
        private readonly DB_OverseasContext _context;
        public SesionDao(DB_OverseasContext context)
        {
            _context = context;
        }

        /*
         * BUSCAR HORARIOS DEL DIA ADMIN
         */
        public List<Sesion> BuscarHorariosDelDia() => _context.Sesion
            .Where(s => s.FechaSesion == DateTime.Today && s.Horario.EstadoHorario == 1)
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.Docente).ThenInclude(d => d.Persona)
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.TipoCurso)
            .Include(s => s.Horario).ThenInclude(h => h.Ambiente)
            .ToList();



        /*
         * BUSCAR HORARIOS DEL DIA DE UN DOCENTE
         */
        public List<Sesion> BuscarHorariosDelDiaDocente(int idDocente) => _context.Sesion
            .Where(s => (s.FechaSesion == DateTime.Today && s.Horario.Curso.Docente.IdDocente == idDocente && s.Horario.EstadoHorario == 1))
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.Docente).ThenInclude(d => d.Persona)
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.TipoCurso)
            .Include(s => s.Horario).ThenInclude(h => h.Ambiente)
            .ToList();

        


        /*
         * BUSCAR SESIONES DEL DOCENTE EN EL MES
         */
        public List<Sesion> BuscarSesionesDelDocentePorMes(int mes, int año, int idDocente) => _context.Sesion
            .Where(s => (s.FechaSesion.Month == mes && s.FechaSesion.Year == año && s.Horario.Curso.Docente.IdDocente == idDocente && s.Horario.EstadoHorario == 1))
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.Docente).ThenInclude(d => d.Persona)
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.TipoCurso)
            .Include(s => s.Horario).ThenInclude(h => h.Ambiente)
            .ToList();

        

        /*
         * BUSCAR SESION POR FECHA Y CURSO
         */
        public Sesion BuscarSesionPorFechaYCurso(int idCurso, DateTime fecha) => _context.Sesion
            .Where(s => (s.FechaSesion == fecha && s.Horario.Curso.IdCurso == idCurso && s.Horario.EstadoHorario == 1))
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.Docente).ThenInclude(d => d.Persona)
            .Include(s => s.Horario).ThenInclude(h => h.Curso).ThenInclude(c => c.TipoCurso)
            .Include(s => s.Horario).ThenInclude(h => h.Ambiente)
            .FirstOrDefault();


        /*
         * BUSCAR SESION
         */
        public Sesion BuscarSesionPorID(int idSesion) => _context.Sesion.Find(idSesion);


        /*
         * BUSCAR SESION AUN NO REGISTRADAS
         */

        public List<Sesion> BuscarSesionesCursoNoRegistradas(int idCurso) => _context.Sesion
                                                                        .Where(s => s.Horario.IdCurso == idCurso && s.AsistenciaDocente == 0)
                                                                        .Include(s => s.Horario)
                                                                        .ToList();




        /*
         * BUSCAR SESION
         */
        public Sesion BuscarSesion(int idHorario)
        {
            Sesion sesion = new Sesion();
            try
            {
                sesion    = (from s in _context.Sesion
                            join h in _context.Horario on s.IdHorario equals h.IdHorario
                            join c in _context.Curso on h.Curso.IdCurso equals c.IdCurso
                            where s.IdHorario == idHorario

                            select new Sesion
                            {
                                IdSesion = s.IdSesion,
                                AsistenciaDocente = s.AsistenciaDocente,
                                FechaSesion = s.FechaSesion,
                                NumeroSesion = s.NumeroSesion,
                                IdHorario = h.IdHorario,
                                Horario = h
                            }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return sesion;
        }

        public List<Sesion> BuscarSesionesCurso(int idCurso)
        {
            List<Sesion> sesiones = new List<Sesion>();
            try
            {
                sesiones = (from s in _context.Sesion
                            join h in _context.Horario on s.IdHorario equals h.IdHorario
                            join c in _context.Curso on h.Curso.IdCurso equals c.IdCurso
                            join a in _context.Ambiente on h.IdAmbiente equals a.IdAmbiente
                            where h.IdCurso == idCurso

                            select new Sesion
                            {
                                IdSesion = s.IdSesion,
                                AsistenciaDocente = s.AsistenciaDocente,
                                FechaSesion = s.FechaSesion,
                                NumeroSesion = s.NumeroSesion,
                                IdHorario = h.IdHorario                                
                            }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return sesiones;
        }

        public bool CrearSesion(Sesion sesion)
        {
            try
            {
               
                _context.Sesion.Add(sesion);
                _context.SaveChanges();
                
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditarSesion(Sesion sesion)
        {
            try
            {
                _context.Sesion.Attach(sesion);
                _context.Sesion.Update(sesion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Sesion> ListarSesionesCurso(int idCurso)
        {
            List<Sesion> sesiones = new List<Sesion>();
            try
            {
                sesiones = (from s in _context.Sesion
                            join h in _context.Horario on s.IdHorario equals h.IdHorario
                            join c in _context.Curso on h.Curso.IdCurso equals c.IdCurso
                            join a in _context.Ambiente on h.IdAmbiente equals a.IdAmbiente
                            where h.IdCurso == idCurso

                            select new Sesion
                            {
                                IdSesion = s.IdSesion,
                                AsistenciaDocente = s.AsistenciaDocente,
                                FechaSesion = s.FechaSesion,
                                NumeroSesion = s.NumeroSesion,
                                IdHorario = h.IdHorario,
                                Horario = new Horario
                                {
                                    IdHorario = h.IdHorario,
                                    Dia = h.Dia,
                                    HoraInicio = h.HoraInicio,
                                    HoraFin = h.HoraFin,
                                    IdCurso = h.IdCurso,
                                    IdAmbiente = h.IdAmbiente,
                                    Curso = new Curso
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
                                }
                        }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return sesiones;
        }
    }
}
