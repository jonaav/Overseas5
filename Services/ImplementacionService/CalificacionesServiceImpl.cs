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
        private readonly ICursoDao _cursoDao;

        public CalificacionesServiceImpl(
            IHistorialEvaluacionDao historialEvaluacionDao,
            IEvaluacionDao evaluacionDao,
            ITipoEvaluacionDao tipoEvaluacionDao,
            ITipoCursoDao tipoCursoDao,
            ICursoDao cursoDao
        )
        {
            _historialEvaluacionDao = historialEvaluacionDao;
            _evaluacionDao = evaluacionDao;
            _tipoEvaluacionDao = tipoEvaluacionDao;
            _tipoCursoDao = tipoCursoDao;
            _cursoDao = cursoDao;
        }


        public void RegistrarHistorialEvaluacion(HistorialEvaluacion nuevoHistorial)
        {
            List<Evaluacion> evaluaciones = new List<Evaluacion>();
            if (_historialEvaluacionDao.RegistrarHistorialEvaluacion(nuevoHistorial))
            {
                HistorialEvaluacion historial = _historialEvaluacionDao.BuscarHistorialPorEstudianteYCurso(nuevoHistorial.IdEstudiante, nuevoHistorial.IdCurso);
                historial.Curso = _cursoDao.BuscarCursoPorID(historial.IdCurso);
                if (historial != null)
                {
                    List<TipoEvaluacion> tiposEvaluacion = _tipoCursoDao.BuscarEvaluacionesDeUnTipoCurso(historial.Curso.IdTipoCurso);
                    foreach (TipoEvaluacion te in tiposEvaluacion)
                    {
                        Evaluacion evaluacion = new Evaluacion
                        {
                            IdEvaluacion = 0,
                            CalificacionEvaluacion = 0,
                            IdHistorialEvaluacion = historial.IdHistorialEvaluacion,
                            IdTipoEvaluacion = te.IdTipoEvaluacion
                        };
                        evaluaciones.Add(evaluacion);
                    }

                    foreach (Evaluacion e in evaluaciones)
                    {
                        bool reg = _evaluacionDao.RegistrarEvaluacion(e);
                    }
                }
            }
            
        }


        public Evaluacion BuscarEvaluacion(int idEvaluacion)
        {
            Evaluacion evaluacion = _evaluacionDao.BuscarEvaluacion(idEvaluacion);
            return evaluacion;
        }



        public String EditarEvaluacion(int idEvaluacion, int nota )
        {
            String mensaje = "";
            Evaluacion evaluacion = _evaluacionDao.BuscarEvaluacion(idEvaluacion);
            evaluacion.CalificacionEvaluacion = nota;
            if (_evaluacionDao.EditarEvaluacion(evaluacion))
            {
                mensaje = "Calificacion Actualizada";
            }
            return mensaje;
        }

        //public String EliminarCalificaciones(int idHistorial)
        //{
        //    String mensaje = "";
        //    return mensaje;
        //}


        public List<Evaluacion> VerNotasDelEstudiantePorCurso(int idCurso, int idEstudiante)
        {
            List<Evaluacion> evaluaciones = _evaluacionDao.ListarEvaluacionesPorEstudianteYCurso(idEstudiante, idCurso);
            return evaluaciones;
        }


    }
}
