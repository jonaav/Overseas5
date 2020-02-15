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
        private readonly ITipoCursoDao _tipoCursoDao;
        private readonly ITipoEvaluacionDao _tipoEvaluacionDao;
        private readonly ITCursoTEvaluacionDao _tCursotEvaluacionDao;

        public CursoEvaluacionServiceImpl(
            ITipoCursoDao tipoCursoDao,
            ITipoEvaluacionDao tipoEvaluacionDao,
            ITCursoTEvaluacionDao tCursotEvaluacionDao
        )
        {
            _tipoCursoDao = tipoCursoDao;
            _tipoEvaluacionDao = tipoEvaluacionDao;
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
            String mensaje = "No pudo ser eliminado";
            if (_tipoEvaluacionDao.EliminarTipoEvaluacion(idTipoEvaluacion))
            {
                mensaje = "Eliminado";
            }
            return mensaje;
        }

        

        public String RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion tt)
        {
            String mensaje = "No pudo ser registrado";
            if (_tCursotEvaluacionDao.RegistrarTCursoTEvaluacion(tt))
            {
                mensaje = "Registrado";
            }
            return mensaje;
        }

        

        public String EliminarTCursoTEvaluacion(int idtt)
        {
            String mensaje = "No pudo ser eliminado";
            if (_tCursotEvaluacionDao.EliminarTCursoTEvaluacion(idtt))
            {
                mensaje = "Eliminado";
            }
            return mensaje;
        }



    }
}
