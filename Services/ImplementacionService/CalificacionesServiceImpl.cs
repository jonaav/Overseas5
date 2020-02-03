using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class CalificacionesServiceImpl : ICalificacionesService
    {
        private readonly IHistorialEvaluacionDao _historialEvaluacionDao;
        private readonly IEvaluacionDao _evaluacionDao;
        private readonly ITipoEvaluacionDao _tipoEvaluacionDao;
        private readonly ITipoCursoDao _tipoCursoDao;

        public CalificacionesServiceImpl(
            IHistorialEvaluacionDao historialEvaluacionDao,
            IEvaluacionDao evaluacionDao,
            ITipoEvaluacionDao tipoEvaluacionDao,
            ITipoCursoDao tipoCursoDao
        )
        {
            _historialEvaluacionDao = historialEvaluacionDao;
            _evaluacionDao = evaluacionDao;
            _tipoEvaluacionDao = tipoEvaluacionDao;
            _tipoCursoDao = tipoCursoDao;
        }


        public bool RegistrarHistorialEvaluacion(HistorialEvaluacion nuevoHistorial)
        {
            HistorialEvaluacion historial = _historialEvaluacionDao.RegistrarHistorialEvaluacion(nuevoHistorial);
            if (historial != null)
            {
                List<TipoEvaluacion> tiposEvaluacion = _tipoCursoDao.BuscarEvaluacionesDeUnTipoCurso(historial.Curso.IdTipoCurso);
                foreach(TipoEvaluacion te in tiposEvaluacion)
                {
                    Evaluacion evaluacion = new Evaluacion
                    {
                        CalificacionEvaluacion = 0,
                        IdHistorialEvaluacion = historial.IdHistorialEvaluacion,
                        IdTipoEvaluacion = te.IdTipoEvaluacion
                    };
                    _evaluacionDao.RegistrarEvaluacion(evaluacion);
                }
            }
            return false;
        }

        public String RegistrarEvaluacion(Evaluacion evaluacion)
        {
            String mensaje = "";
            return mensaje;
        }

        public String EditarEvaluacion(Evaluacion evaluacion)
        {
            String mensaje = "";
            return mensaje;
        }

        public String EliminarCalificaciones(int idHistorial)
        {
            String mensaje = "";
            return mensaje;
        }





    }
}
