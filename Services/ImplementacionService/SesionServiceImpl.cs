﻿using System;
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

        public Sesion BuscarSesionPorID(int idSesion)
        {
            return _sesionDao.BuscarSesionPorID(idSesion);
        }

        public List<Sesion> BuscarSesionesCurso(int idCurso)
        {
            return _sesionDao.BuscarSesionesCurso(idCurso);
        }

        public String CrearSesiones(List<Sesion> listaSesiones)
        {
            foreach (Sesion sesion in listaSesiones)                           
                _sesionDao.CrearSesion(sesion);            
            return "Correcto";
        }

        public List<Sesion> ListarSesionesCurso(int idCurso)
        {
            return _sesionDao.ListarSesionesCurso(idCurso);
        }

        public String CrearSesionesCursoPrivado(List<Sesion> listaSesiones)
        {
            foreach (Sesion sesion in listaSesiones)
            {
                if (BuscarSesion(sesion.IdHorario) == null)
                    _sesionDao.CrearSesion(sesion);                
            }
            return "Correcto";            
        }
    }
}
