using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class TCursoTEvaluacionDao:ITCursoTEvaluacionDao
    {

        private readonly DB_OverseasContext _context;
        public TCursoTEvaluacionDao(DB_OverseasContext context)
        {
            _context = context;
        }


        public bool RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion tt)
        {
            try
            {
                _context.TCursoTEvaluacion.Add(tt);
                _context.SaveChanges();
                return true;
            }catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarTCursoTEvaluacion(int idTCurso, int idTEvaluacion)
        {
            TipoCursoTipoEvaluacion tt = _context.TCursoTEvaluacion
                .Where(t => (t.IdTipoCurso == idTCurso && t.IdTipoEvaluacion == idTEvaluacion)).FirstOrDefault();
            try
            {
                _context.TCursoTEvaluacion.Remove(tt);
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
