using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;


namespace Services.ImplementacionService
{
    public class InscripcionServiceImpl : IInscripcionService
    {
        private readonly IEstudianteDao _estudianteDao;
        private readonly IInscripcionDao _inscripcionDao;
        private readonly ICalificacionesService _calificacionesService;

        public InscripcionServiceImpl(
            IEstudianteDao estudianteDao,
            IInscripcionDao inscripcionDao,
            ICalificacionesService calificacionesService
        )
        {
            _estudianteDao = estudianteDao;
            _inscripcionDao = inscripcionDao;
            _calificacionesService = calificacionesService;
        }

        #region metodos
        public List<Inscripcion> ListarInscripciones(int idCurso)
        {
            List<Inscripcion> inscripciones = _inscripcionDao.ListarInscripciones(idCurso);
            return inscripciones;
        }



        public List<Estudiante> BuscarEstudiantesNoInscritos(int idCurso)
        {
            List<Estudiante> removerEstudiantes = new List<Estudiante>();
            List<Estudiante> estudiantes = _estudianteDao.ListarEstudiantes();
            List<Inscripcion> inscripciones = _inscripcionDao.ListarInscripciones(idCurso);

            foreach (Estudiante e in estudiantes)
            {
                foreach (Inscripcion i in inscripciones)
                {
                    if (e.IdEstudiante == i.IdEstudiante)
                    {
                        removerEstudiantes.Add(e);
                    }
                }
            }

            foreach (Estudiante e in removerEstudiantes)
            {
                estudiantes.Remove(e);
            }


            return estudiantes;
        }

        public bool RegistrarInscripcion(int idCurso, int idEstudiante)
        {
            bool registro = false;
            Inscripcion inscripcion = new Inscripcion
            {
                IdEstudiante = idEstudiante,
                IdCurso = idCurso
            };
            if(!_inscripcionDao.BuscarInscripcion(inscripcion))
                registro = _inscripcionDao.RegistrarInscripcion(inscripcion);
            HistorialEvaluacion historial = new HistorialEvaluacion
            {
                FeedbackHistorialEvaluacion = "",
                IdCurso = idCurso,
                IdEstudiante = idEstudiante
            };
            _calificacionesService.RegistrarHistorialEvaluacion(historial);
            return registro;
        }


        public bool AnularInscripcion(int id)
        {
            Inscripcion inscripcion = _inscripcionDao.BuscarInscripcionID(id);
            bool anulado = _inscripcionDao.AnularInscripcion(inscripcion);
            return anulado;
        }


        #endregion metodos




    }
}




