﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class SesionDao : ISesionDao
    {
        private readonly DB_OverseasContext _context;
        public SesionDao(DB_OverseasContext context)
        {
            _context = context;
        }

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

        public bool EditarSesionesCurso(List<Sesion> sesiones)
        {
            throw new NotImplementedException();
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