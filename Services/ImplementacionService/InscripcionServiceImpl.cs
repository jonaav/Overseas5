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

        public InscripcionServiceImpl(
            IEstudianteDao estudianteDao,
            IInscripcionDao inscripcionDao
        ){
            _estudianteDao = estudianteDao;
            _inscripcionDao = inscripcionDao;
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
            Inscripcion inscripcion = new Inscripcion
            {
                IdEstudiante = idEstudiante,
                IdCurso = idCurso
            };
            bool registro = false;
            if(!_inscripcionDao.BuscarInscripcion(inscripcion))
                registro = _inscripcionDao.RegistrarInscripcion(inscripcion);
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




