using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class TipoCursoDao : ITipoCursoDao
    {

        private readonly DB_OverseasContext _context;
        public TipoCursoDao (DB_OverseasContext context) => _context = context;




        /*
         *  Listar TipoCurso
         */
        public List<TipoCurso> ListarTiposCurso() => _context.TipoCurso.ToList();


        /*
         *  Buscar Evaluaciones de un Tipo de Curso
         */
        public List<TipoEvaluacion> BuscarEvaluacionesDeUnTipoCurso(int idTipoCurso)
        {
            List<TipoCursoTipoEvaluacion> cursosEv = BuscarTipoCursoTipoEvaluaciones(idTipoCurso);
            List<TipoEvaluacion> tipoEvaluaciones = new List<TipoEvaluacion>();
            foreach(TipoCursoTipoEvaluacion tt in cursosEv)
            {
                tipoEvaluaciones.Add(tt.TipoEvaluacion);
            }

            return tipoEvaluaciones;
        }

        /*
         *  Buscar TipoCurso por idTipoCurso
         */
        public TipoCurso BuscarTipoCursoPorID(int idTipoCurso) => _context.TipoCurso
                                                                .Where(tc => tc.IdTipoCurso == idTipoCurso)
                                                                .FirstOrDefault();

        /*
         *  Crear TipoCurso
         */
        public bool RegistrarTipoCurso(TipoCurso tipoCurso)
        {
            try
            {
                _context.TipoCurso.Add(tipoCurso);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         *  Editar DetalleCursoDocente
         */
        public bool EditarTipoCurso(TipoCurso tipoCurso)
        {
            try
            {
                _context.TipoCurso.Attach(tipoCurso);
                _context.TipoCurso.Update(tipoCurso);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        /*
         *  Eliminar TipoCurso
         */
        public bool EliminarTipoCurso (int idTipoCurso)
        {
            try
            {
                TipoCurso tipoCurso = _context.TipoCurso.Find(idTipoCurso);
                if (tipoCurso != null)
                {
                    _context.TipoCurso.Remove(tipoCurso);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region private

        private List<TipoCursoTipoEvaluacion> BuscarTipoCursoTipoEvaluaciones (int idTipoCurso) => _context.TCursoTEvaluacion
            .Where(tt => tt.IdTipoCurso == idTipoCurso)
            .Include(tt => tt.TipoCurso).Include(tt => tt.TipoEvaluacion).ToList();




        #endregion private



    }
}
