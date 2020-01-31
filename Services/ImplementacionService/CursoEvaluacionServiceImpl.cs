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

        public CursoEvaluacionServiceImpl(
            ITipoCursoDao tipoCursoDao,
            ITipoEvaluacionDao tipoEvaluacionDao
        )
        {
            _tipoCursoDao = tipoCursoDao;
            _tipoEvaluacionDao = tipoEvaluacionDao;
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
        

        public String RegistrarTipoEvaluacion(TipoEvaluacion tEvaluacion)
        {
            String mensaje = "No pudo ser registrado";
            if (_tipoEvaluacionDao.RegistrarTipoEvaluacion(tEvaluacion))
            {
                mensaje = "Registrado";
            }
            return mensaje;
        }



    }
}
