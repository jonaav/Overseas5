using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;


namespace Services.ImplementacionService
{
    public class InicioAdminServiceImpl: IInicioAdminService
    {

        private readonly ICursoDao _cursoDao;
        private readonly IInscripcionDao _inscripcionesDao;
        private readonly ITraduccionDao _traduccionDao;
        private readonly IDocenteDao _docenteDao;
        private readonly IPersonaDao _personaDao;
        private readonly ISesionDao _sesionDao;

        public InicioAdminServiceImpl(
            ICursoDao cursoDao,
            IInscripcionDao inscripcionesDao,
            ITraduccionDao traduccionDao,
            IDocenteDao docenteDao,
            IPersonaDao personaDao,
            ISesionDao sesionDao
        )
        {
            _cursoDao = cursoDao;
            _inscripcionesDao = inscripcionesDao;
            _traduccionDao = traduccionDao;
            _docenteDao = docenteDao;
            _personaDao = personaDao;
            _sesionDao = sesionDao;
        }


        //Cantidad de estudiantes matriculados
        public int ContarEstudiantesActivos()
        {
            return _inscripcionesDao.CantidadDeEstudiantesActivos();
        }

        //Cantidad de docentes activos
        public int ContarDocentesActivos()
        {
            return _docenteDao.CantidadDeDocentesActivos();
        }

        //Cantidad de Cursos activos
        public int ContarCursosActivos()
        {
            return _cursoDao.CantidadDeCursosActivos();
        }

        //Cantidad de Traducciones pendientes
        public int ContarTraduccionesPendientes()
        {
            return _traduccionDao.CantidadDeTraduccionesPendientes();
        }

        //Buscar cumpleaños cercanos

        public List<Docente> BuscarCumpleañosCercanos()
        {
            DateTime inicio = DateTime.Today;
            DateTime fin = inicio.AddDays(7);
            List<Docente> docentes = _docenteDao.BuscarCumpleañosCercanos(inicio,fin);
            return docentes;
        }
        

        //Buscar horarios del dia

        public List<Sesion> BuscarHorariosDelDia()
        {
            List<Sesion> sesiones = _sesionDao.BuscarHorariosDelDia();
            return sesiones;
        }


    }
}
