using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class TipoEvaluacionDao: ITipoEvaluacionDao
    {
        private readonly DB_OverseasContext _context;
        public TipoEvaluacionDao(DB_OverseasContext context) => _context = context;


        /*
         *  Listar TipoEvaluacion
         */
        public List<TipoEvaluacion> ListarTiposEvaluacion() => _context.TipoEvaluacion.ToList();

        /*
         *  Buscar TipoEvaluacion por idTipoEvaluacion
         */
        public TipoEvaluacion BuscarTipoEvaluacionPorID(int idTipoEvaluacion) => _context.TipoEvaluacion
                                                                        .Where(c => c.IdTipoEvaluacion == idTipoEvaluacion)
                                                                        .FirstOrDefault();

        /*
         *  Crear TipoEvaluacion
         */
        public bool RegistrarTipoEvaluacion(TipoEvaluacion tipoEvaluacion)
        {
            try
            {
                _context.TipoEvaluacion.Add(tipoEvaluacion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  Eliminar TipoEvaluacion
         */
        public bool EliminarTipoEvaluacion(int idTipoEvaluacion)
        {
            try
            {
                TipoEvaluacion tipoEvaluacion = _context.TipoEvaluacion.Find(idTipoEvaluacion);
                if (tipoEvaluacion != null)
                {
                    _context.TipoEvaluacion.Remove(tipoEvaluacion);
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





    }
}
