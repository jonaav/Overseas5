using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class InscripcionDao: IInscripcionDao
    {
        private readonly DB_OverseasContext _context;
        public InscripcionDao(
            DB_OverseasContext context
        )
        {
            _context = context;
        }



        /*
         *  Listar Inscripciones por curso 
         */

        public List<Inscripcion> ListarInscripciones(int idCurso) => _context.Inscripcion
                                                                .Where(i => (i.IdCurso == idCurso &&
                                                                            i.EstadoInscripcion == 1))
                                                                .Include(i => i.Curso)
                                                                    .ThenInclude(c => c.Docente)
                                                                    .ThenInclude(d => d.Persona)
                                                                .Include(i => i.Curso)
                                                                    .ThenInclude(c => c.TipoCurso)
                                                                .Include(i => i.Estudiante)
                                                                    .ThenInclude(e => e.Persona)
                                                                .ToList();




        /*
         *  Buscar Inscripcion 
         */

        public bool BuscarInscripcion(Inscripcion nuevaInscripcion)
        {
            Inscripcion inscripcion = new Inscripcion();
            try
            {
                inscripcion = (from i in _context.Inscripcion
                               where i.IdEstudiante == nuevaInscripcion.IdEstudiante 
                               && i.IdCurso == nuevaInscripcion.IdCurso 
                               && i.EstadoInscripcion != 0
                               select new Inscripcion
                               {
                                   IdInscripcion = i.IdInscripcion,
                                   FechaInscripcion = i.FechaInscripcion,
                                   IdEstudiante = i.IdEstudiante,
                                   Curso = i.Curso
                               }).FirstOrDefault();
                if (inscripcion != null)
                    return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }



        /*
         *  Buscar Inscripcion por ID 
         */

        public Inscripcion BuscarInscripcionID(int id) => _context.Inscripcion
                                                            .Where(i => i.IdInscripcion == id)
                                                            .Include(i => i.Curso)
                                                                .ThenInclude(c => c.Docente)
                                                                .ThenInclude(d => d.Persona)
                                                            .Include(i => i.Curso)
                                                                .ThenInclude(c => c.TipoCurso)
                                                            .Include(i => i.Estudiante)
                                                                .ThenInclude(e => e.Persona)
                                                            .FirstOrDefault();



        /*
         *  Registrar Inscripcion
         */

        public bool RegistrarInscripcion(Inscripcion inscripcion)
        {
            try
            {
                inscripcion.EstadoInscripcion = 1;
                inscripcion.FechaInscripcion = DateTime.Today;
                _context.Inscripcion.Add(inscripcion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        /*
         *  Anular Inscripcion
         */

        public bool AnularInscripcion(Inscripcion inscripcion)
        {
            try
            {
                if (inscripcion != null)
                {
                    inscripcion.EstadoInscripcion = 0;
                    _context.Inscripcion.Attach(inscripcion);
                    _context.Inscripcion.Update(inscripcion);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }




        /*
         *  Contar total de Estudiantes matriculados activos
         */

        public int CantidadDeEstudiantesActivos() => _context.Inscripcion
                                                    .Where(i => i.EstadoInscripcion == 1)
                                                    .Count();


    }
}
