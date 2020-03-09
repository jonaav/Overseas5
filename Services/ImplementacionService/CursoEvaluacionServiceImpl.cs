using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class CursoEvaluacionServiceImpl: ICursoEvaluacionService 
    {
        private readonly ICursoDao _cursoDao;
        private readonly ITipoCursoDao _tipoCursoDao;
        private readonly IInscripcionDao _inscripcionDao;
        private readonly ITipoEvaluacionDao _tipoEvaluacionDao;
        private readonly IEvaluacionDao _EvaluacionDao;
        private readonly IHistorialEvaluacionDao _historialEvaluacion;
        private readonly ITCursoTEvaluacionDao _tCursotEvaluacionDao;

        public CursoEvaluacionServiceImpl(
            ITipoCursoDao tipoCursoDao,
            ICursoDao cursoDao,
            IInscripcionDao inscripcionDao,
            ITipoEvaluacionDao tipoEvaluacionDao,
            IEvaluacionDao EvaluacionDao,
            IHistorialEvaluacionDao historialEvaluacion,
            ITCursoTEvaluacionDao tCursotEvaluacionDao
        )
        {
            _cursoDao = cursoDao;
            _tipoCursoDao = tipoCursoDao;
            _inscripcionDao = inscripcionDao;
            _tipoEvaluacionDao = tipoEvaluacionDao;
            _EvaluacionDao = EvaluacionDao;
            _historialEvaluacion = historialEvaluacion;
            _tCursotEvaluacionDao = tCursotEvaluacionDao;
        }

        public List<TipoCurso> ListarTiposCurso()
        {
            List<TipoCurso> tiposCurso = _tipoCursoDao.ListarTiposCurso();
            return tiposCurso;
        }
        

        public List<TipoEvaluacion> ListarTiposEvaluacion()
        {
            List<TipoEvaluacion> tiposEvaluacion = _tipoEvaluacionDao.ListarTiposEvaluacion();
            return tiposEvaluacion;
        }
        

        public List<TipoCursoTipoEvaluacion> ListarTCursoTEvaluacion(int idCurso)
        {
            List<TipoCursoTipoEvaluacion> tt = _tCursotEvaluacionDao.ListarTCursoTEvaluacion(idCurso);
            return tt;
        }
        

        public List<TipoEvaluacion> ListarTEvaluacionFaltantes(int idCurso)
        {
            List<TipoEvaluacion> tiposEvaluacion = _tipoEvaluacionDao.ListarTiposEvaluacion();
            List <TipoCursoTipoEvaluacion> tt = _tCursotEvaluacionDao.ListarTCursoTEvaluacion(idCurso);
            List<TipoEvaluacion> tEvaluaciones = new List<TipoEvaluacion>();

            foreach (TipoEvaluacion te in tiposEvaluacion)
            {
                bool existe = false;
                foreach (TipoCursoTipoEvaluacion tcte in tt)
                {
                    if (te.IdTipoEvaluacion == tcte.TipoEvaluacion.IdTipoEvaluacion)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe) tEvaluaciones.Add(te);
            }

            return tEvaluaciones;
        }
        

        public String RegistrarTipoEvaluacion(TipoEvaluacion tEvaluacion)
        {
            String mensaje = "No pudo ser registrado";
            if (_tipoEvaluacionDao.RegistrarTipoEvaluacion(tEvaluacion))
            {
                mensaje = "Registrado";
            }
            return mensaje;
        }

        

        public String EliminarTipoEvaluacion(int idTipoEvaluacion)
        {
            String mensaje = "No puede ser eliminado, probablemente se encuentra incluido en algun tipo de curso";
            List<TipoCursoTipoEvaluacion> tts = _tCursotEvaluacionDao.ListarTCursoTEvaluacionPorTEvaluacion(idTipoEvaluacion);
            if (tts.Count == 0)
            {
                if (_tipoEvaluacionDao.EliminarTipoEvaluacion(idTipoEvaluacion))
                {
                    mensaje = "Eliminado";
                }
            }
            return mensaje;
        }

        

        public String RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion tt)
        {
            String mensaje = "No pudo ser registrado";
            if (_tCursotEvaluacionDao.RegistrarTCursoTEvaluacion(tt))
            {
                List<Curso> cursos = _cursoDao.BuscarCursosActivosPorTipo(tt.IdTipoCurso);
                foreach (Curso c in cursos)
                {
                    List<Inscripcion> inscripciones = _inscripcionDao.ListarInscripciones(c.IdCurso);
                    foreach(Inscripcion i in inscripciones)
                    {
                        HistorialEvaluacion historial = _historialEvaluacion.BuscarHistorialPorEstudianteYCurso(i.IdEstudiante, i.IdCurso);
                        Evaluacion evaluacion = new Evaluacion
                        {
                            CalificacionEvaluacion = 0,
                            IdTipoEvaluacion = tt.IdTipoEvaluacion,
                            IdHistorialEvaluacion = historial.IdHistorialEvaluacion,
                        };
                        _EvaluacionDao.RegistrarEvaluacion(evaluacion);
                    }
                }
                mensaje = "Registrado";
            }
            return mensaje;
        }

        

        public String EliminarTCursoTEvaluacion(int idtt)
        {
            String mensaje = "No pudo ser eliminado";
            TipoCursoTipoEvaluacion tt = _tCursotEvaluacionDao.BuscarTipoCursoTipoEvaluacion(idtt);
            if (_tCursotEvaluacionDao.EliminarTCursoTEvaluacion(idtt))
            {
                List<Curso> cursos = _cursoDao.BuscarCursosActivosPorTipo(idtt);
                foreach (Curso c in cursos)
                {
                    List<Inscripcion> inscripciones = _inscripcionDao.ListarInscripciones(c.IdCurso);
                    foreach (Inscripcion i in inscripciones)
                    {
                        HistorialEvaluacion historial = _historialEvaluacion.BuscarHistorialPorEstudianteYCurso(i.IdEstudiante, i.IdCurso);
                        
                        Evaluacion ev =  _EvaluacionDao.BuscarEvaluacionPorHistorialTipo(historial.IdHistorialEvaluacion, tt.IdTipoEvaluacion);
                        _EvaluacionDao.EliminarEvaluacion(ev.IdEvaluacion);
                    }
                }
                mensaje = "Eliminado";
            }
            return mensaje;
        }



    }
}
