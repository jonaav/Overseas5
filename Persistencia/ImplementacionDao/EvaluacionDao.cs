using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.InterfazDao;


namespace Persistencia.ImplementacionDao
{
    public class EvaluacionDao: IEvaluacionDao
    {

        private readonly DB_OverseasContext _context;
        public EvaluacionDao(DB_OverseasContext context)
        {
            _context = context;
        }


        /*
         *  Listar Evaluaciones de un estudiante en un curso
         */
        public List<Evaluacion> ListarEvaluacionesPorEstudianteYCurso(int idEstudiante, int idCurso) => _context.Evaluacion
            .Where(e => (e.HistorialEvaluacion.IdEstudiante == idEstudiante && e.HistorialEvaluacion.Curso.IdCurso == idCurso))
            .Include(e => e.HistorialEvaluacion).ThenInclude(h => h.Estudiante).ThenInclude(e => e.Persona)
            .Include(e => e.TipoEvaluacion)
            .ToList();


        /*
         *  Buscar Evaluacion
         */

        public Evaluacion BuscarEvaluacion(int idEvaluacion) => _context.Evaluacion
            .Where(e => e.IdEvaluacion == idEvaluacion)
            .Include(e => e.TipoEvaluacion)
            .FirstOrDefault();

        

        /*
         *  Registrar Evaluacion
         */

        public bool RegistrarEvaluacion(Evaluacion evaluacion)
        {
            try
            {
                _context.Evaluacion.Add(evaluacion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        /*
         *  Editar Evaluacion
         */

        public bool EditarEvaluacion(Evaluacion evaluacion)
        {
            try
            {
                _context.Evaluacion.Attach(evaluacion);
                _context.Evaluacion.Update(evaluacion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }





        /*
         *  Eliminar Evaluacion
         */

        public bool EliminarEvaluacion(int idEvaluacion)
        {
            Evaluacion evaluacion = _context.Evaluacion.Find(idEvaluacion);
            try
            {
                _context.Evaluacion.Remove(evaluacion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /*
         *  Buscar evaluacion por historial y tipo de evaluacion
         */

        public Evaluacion BuscarEvaluacionPorHistorialTipo(int idHistorial, int idTEvaluacion) => _context.Evaluacion
            .Where(e => (e.IdHistorialEvaluacion == idHistorial && e.IdTipoEvaluacion == idTEvaluacion))
            .FirstOrDefault();
    }
}
