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
        private IDocenteDao _docenteDao;
        private IHorarioDao _horarioDao;

        public AsistenciaServiceImpl(
            IAsistenciaDao asistenciaDao,
            ISesionDao sesionDao,
            IInscripcionDao inscripcionDao,
            IDocenteDao docenteDao,
            IHorarioDao horarioDao
        )
        {
            _asistenciaDao = asistenciaDao;
            _sesionDao = sesionDao;
            _inscripcionDao = inscripcionDao;
            _docenteDao = docenteDao;
            _horarioDao = horarioDao;
        }


        public List<Asistencia> ListarAsistenciasPorSesionCurso(int idCurso)
        {
            DateTime fechaActual = DateTime.Today;
            List<Asistencia> asistencias = _asistenciaDao.ListarAsistenciasPorSesionCurso(idCurso, fechaActual);
            return asistencias;

        }



        public String MarcarAsistenciaDocente(int idCurso)
        {
            string mensaje = "No se pudo actualizar los datos";

            if (_sesionDao.BuscarSesionPorFechaYCurso(idCurso, DateTime.Today) != null)
            {
                mensaje = "Sesión activa";
                return mensaje;
            }

            List<Horario> horarios = _horarioDao.BuscarHorariosCurso(idCurso);
            foreach (Horario h in horarios)
            {
                if (h.EsDiaCorrespondiente())
                {
                    Sesion sesion = new Sesion
                    {
                        AsistenciaDocente = 1,
                        FechaSesion = DateTime.Today,
                        IdHorario = h.IdHorario,
                        NumeroSesion = 0
                    };
                    _sesionDao.CrearSesion(sesion);
                    mensaje = "Datos actualizados";

                    RegistrarAsistencias(idCurso, sesion.FechaSesion);
                }
            }
            return mensaje;
        }


        private void RegistrarAsistencias(int idCurso, DateTime fecha)
        {
            Sesion sesion = _sesionDao.BuscarSesionPorFechaYCurso(idCurso, fecha);
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

        public List<Asistencia> ListarAsistenciasPorSesion(int idSesion)
        {
            List<Asistencia> asistencias = _asistenciaDao.ListarAsistenciasPorSesion(idSesion);
            return asistencias;
        }


        public bool VerificarSesionActiva (int idCurso)
        {
            Sesion sesion = _sesionDao.BuscarSesionPorFechaYCurso(idCurso, DateTime.Today);
            return (sesion != null) ? true : false;
        }





    }
}
