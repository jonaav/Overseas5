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
        private ISesionDao _sesionDao;
        private IInscripcionDao _inscripcionDao;

        public AsistenciaServiceImpl(
            IAsistenciaDao asistenciaDao,
            ISesionDao sesionDao,
            IInscripcionDao inscripcionDao
        )
        {
            _asistenciaDao = asistenciaDao;
            _sesionDao = sesionDao;
            _inscripcionDao = inscripcionDao;
        }


        public List<Asistencia> ListarAsistenciasPorSesion(int idCurso)
        {
            DateTime fechaActual = DateTime.Today;
            List<Asistencia> asistencias = _asistenciaDao.ListarAsistenciasPorSesion(idCurso, fechaActual);
            //Verifica si ya estan creadas las asistencias
            if (asistencias.Count == 0)
            {
                if(RegistrarAsistencias(idCurso, fechaActual))
                    asistencias = _asistenciaDao.ListarAsistenciasPorSesion(idCurso, fechaActual);
            }
            return asistencias;

        }

        public bool RegistrarAsistencias(int idCurso, DateTime fecha)
        {
            Sesion sesion = _sesionDao.BuscarSesionPorFechaYCurso(idCurso, fecha);
            if(sesion != null)
            {
                //Crea las asistencias por sesion
                List<Inscripcion> inscripciones = _inscripcionDao.ListarInscripciones(idCurso);
                foreach (Inscripcion i in inscripciones)
                {
                    Asistencia asistencia = new Asistencia
                    {
                        AsistenciaEstudiante = 0,
                        IdEstudiante = i.IdEstudiante,
                        IdSesion = sesion.IdSesion
                    };
                    _asistenciaDao.RegistrarAsistencia(asistencia);
                }
                //Marca la asistencia del docente
                sesion.AsistenciaDocente = 1;
                _sesionDao.EditarSesion(sesion);
                return true;
            }
            else
            {
                return false;
            }

        }

        public String EditarAsistencias(List<int> asistieron)
        {
            string mensaje = "No se realizaron modificaciones";

            foreach (int id in asistieron)
            {
                Asistencia asistencia = _asistenciaDao.BuscarAsistenciaPorID(id);
                asistencia.AsistenciaEstudiante = 1;
                if (_asistenciaDao.EditarAsistencia(asistencia))
                {
                    mensaje = "Exito";
                }
            }
            return mensaje;
        }

    }
}
