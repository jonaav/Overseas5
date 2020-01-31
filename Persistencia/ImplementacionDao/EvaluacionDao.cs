using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.InterfazDao;


namespace Persistencia.ImplementacionDao
{
    public class EvaluacionDao
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



    }
}
