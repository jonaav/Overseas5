using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class InicioDocenteServiceImpl : IInicioDocenteService
    {

        private readonly ICursoDao _cursoDao;
        private readonly IInscripcionDao _inscripcionesDao;
        private readonly ITraduccionDao _traduccionDao;
        private readonly IDocenteDao _docenteDao;
        private readonly IPersonaDao _personaDao;
        private readonly ISesionDao _sesionDao;

        public InicioDocenteServiceImpl(
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
        public int CantidadHorasTrabajadas()
        {
            return _inscripcionesDao.CantidadDeEstudiantesActivos();
        }


        //Buscar horarios del dia

        public List<Sesion> BuscarHorariosDelDiaDocente(string username)
        {
            Docente docente = _docenteDao.BuscarDocenteCorreo(username);
            List<Sesion> sesiones = _sesionDao.BuscarHorariosDelDiaDocente(docente.IdDocente);
            return sesiones;
        }

    
    }
}
