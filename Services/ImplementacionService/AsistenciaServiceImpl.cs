using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Services.InterfazService;
using Persistencia.InterfazDao;

namespace Services.ImplementacionService
{
    public class AsistenciaServiceImpl: IAsistenciaService
    {
        private IAsistenciaDao _asistenciaDao;

        public AsistenciaServiceImpl(
            IAsistenciaDao asistenciaDao
        )
        {
            _asistenciaDao = asistenciaDao;
        }


        public List<Asistencia> ListarAsistenciasPorSesion(int idCurso)
        {
            DateTime fechaActual = DateTime.Today; 
            List<Asistencia> asistencias = _asistenciaDao.ListarAsistenciasPorSesion(idCurso, fechaActual);
            return asistencias;
        }

    }
}
