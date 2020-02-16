using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.InterfazDao;


namespace Persistencia.ImplementacionDao
{
    public class HistorialEvaluacionDao:IHistorialEvaluacionDao
    {

        private readonly DB_OverseasContext _context;
        public HistorialEvaluacionDao(DB_OverseasContext context)
        {
            _context = context;
        }


        /*
         *  Buscar Historial por idEstudiante y idCurso
         */

        public HistorialEvaluacion BuscarHistorialPorEstudianteYCurso(int idEstudiante, int idCurso) => _context.HistorialEvaluacion
            .Where(h => (h.Curso.IdCurso == idCurso && h.Estudiante.IdEstudiante == idEstudiante))
            .Include(h => h.Estudiante)
                .ThenInclude(e => e.Persona)
            .Include(h => h.Curso)
                .ThenInclude(c => c.TipoCurso)
            .FirstOrDefault();




        /*
         *  Registrar Historial
         */

        public bool RegistrarHistorialEvaluacion(HistorialEvaluacion historial)
        {
            try
            {
                _context.HistorialEvaluacion.Add(historial);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /*
         *  Editar Historial
         */

        public bool EditarHistorialEvaluacion(HistorialEvaluacion historial)
        {
            try
            {
                _context.HistorialEvaluacion.Attach(historial);
                _context.HistorialEvaluacion.Update(historial);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  Eliminar Historial
         */

        public bool EliminarHistorialEvaluacion(int idHistorial)
        {
            HistorialEvaluacion historial = _context.HistorialEvaluacion.Find(idHistorial);
            try
            {
                _context.HistorialEvaluacion.Remove(historial);
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
