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
            .Include(a => a.HistorialEvaluacion).ToList();


        /*
         *  Registrar Evaluacion
         */

        public void RegistrarEvaluacion(Evaluacion evaluacion)
        {
            try
            {
                _context.Evaluacion.Add(evaluacion);
                _context.SaveChanges();
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
    }
}
