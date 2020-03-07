using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class SesionServiceImpl : ISesionService
    {
        private readonly ISesionDao _sesionDao;

        public SesionServiceImpl(ISesionDao sesionDao)
        {
            _sesionDao = sesionDao;
        }

        public Sesion BuscarSesion(int idHorario)
        {
            return _sesionDao.BuscarSesion(idHorario);
        }

        public List<Sesion> BuscarSesionesCurso(int idCurso)
        {
            return _sesionDao.BuscarSesionesCurso(idCurso);
        }

        public bool CrearSesion(Sesion sesion)
        {
            return _sesionDao.CrearSesion (sesion);
        }

        //public bool EditarSesionesCurso(List<Sesion> sesiones)
        //{
        //    return _sesionDao.EditarSesionesCurso(sesiones);
        //}

        public List<Sesion> ListarSesionesCurso(int idCurso)
        {
            return _sesionDao.ListarSesionesCurso(idCurso);
        }
    }
}
