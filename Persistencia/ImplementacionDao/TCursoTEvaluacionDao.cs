using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Microsoft.EntityFrameworkCore;
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


        public List<TipoCursoTipoEvaluacion> ListarTCursoTEvaluacion(int idCurso) => _context.TipoCursoTipoEvaluacion
            .Where(tt => tt.TipoCurso.IdTipoCurso == idCurso)
            .Include(tt => tt.TipoCurso)
            .Include(tt => tt.TipoEvaluacion)
            .ToList();
        

        public bool RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion tt)
        {
            try
            {
                _context.TipoCursoTipoEvaluacion.Add(tt);
                _context.SaveChanges();
                return true;
            }catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarTCursoTEvaluacion(int idtt)
        {
            TipoCursoTipoEvaluacion tt = _context.TipoCursoTipoEvaluacion.Find(idtt);
            try
            {
                _context.TipoCursoTipoEvaluacion.Remove(tt);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TipoCursoTipoEvaluacion BuscarTipoCursoTipoEvaluacion(int idtt) => _context.TipoCursoTipoEvaluacion.Find(idtt);

        public List<TipoCursoTipoEvaluacion> ListarTCursoTEvaluacionPorTEvaluacion(int idTEvaluacion) => _context.TipoCursoTipoEvaluacion
            .Where(tt => (tt.IdTipoEvaluacion == idTEvaluacion))
            .ToList();
    }
}
