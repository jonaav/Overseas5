using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class AsistenciaDao: IAsistenciaDao
    {

        private readonly DB_OverseasContext _context;
        public AsistenciaDao(DB_OverseasContext context)
        {
            _context = context;
        }



        /*
         *  Listar Asistencias de un Estudiante en un Curso
         */
        public List<Asistencia> ListarAsistenciasPorEstudianteYCurso(int idEstudiante, int idCurso) => _context.Asistencia
            .Where(a => (a.IdEstudiante == idEstudiante && a.Sesion.Horario.Curso.IdCurso == idCurso))
            .Include(a => a.Sesion).ToList();




        /*
         *  Listar Asistencias de un Docente en un Curso
         */
        public List<Asistencia> ListarAsistenciasPorDocenteYCurso(int idCurso) => _context.Asistencia
            .Where(a => a.Sesion.Horario.Curso.IdCurso == idCurso)
            .Include(a => a.Sesion).ToList();



        /*
         *  Listar Asistencias de una Sesion
         */
        public List<Asistencia> ListarAsistenciasPorSesion(int idCurso, DateTime fechaActual) => _context.Asistencia
            .Where(a => (a.Sesion.Horario.Curso.IdCurso == idCurso && a.Sesion.FechaSesion == fechaActual))
            .Include(a => a.Sesion)
            .Include(a => a.Estudiante).ThenInclude(e => e.Persona)
            .ToList();


        /*
         *  Listar Cursos Habiles
         */
        public List<Curso> ListarCursosHabiles() => _context.Curso
                                                    .Where(c => c.Estado == 1)
                                                    .Include(c => c.TipoCurso)
                                                    .Include(c => c.Docente)
                                                    .ToList();



        /*
         *  Registrar Asistencia
         */
        public void RegistrarAsistencia(Asistencia asistencia)
        {
            try
            {
                _context.Asistencia.Add(asistencia);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         *  Editar Asistencia
         */
        public bool EditarAsistencia(Asistencia asistencia)
        {
            try
            {
                _context.Asistencia.Attach(asistencia);
                _context.Asistencia.Update(asistencia);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  Contar Asistencias de un Docente en un Curso
         */
        public int ContarAsistenciasDeDocente(int idCurso) => _context.Asistencia
            .Where(a => (a.Sesion.Horario.Curso.IdCurso == idCurso && a.Sesion.AsistenciaDocente == 1))
            .Include(a => a.Sesion).Count();



        

        /*
         *  Buscar asistencia por ID
         */
        public Asistencia BuscarAsistenciaPorID(int idAsistencia) => _context.Asistencia.Find(idAsistencia);







    }
}
