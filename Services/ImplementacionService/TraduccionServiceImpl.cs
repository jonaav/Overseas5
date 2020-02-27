using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class TraduccionServiceImpl : ITraduccionService
    {
        private readonly ITraduccionDao _traduccionDao;

        public TraduccionServiceImpl(ITraduccionDao traduccionDao)
        {
            _traduccionDao = traduccionDao;
        }

        public Traduccion BuscarTraduccion(int idTraduccion)
        {
            return _traduccionDao.BuscarTraduccion(idTraduccion);
        }

        public bool CrearTraduccion(Traduccion traduccion)
        {
            return _traduccionDao.CrearTraduccion(traduccion);
        }

        public bool EditarTraduccion(Traduccion traduccion)
        {
            return _traduccionDao.EditarTraduccion(traduccion);
        }

        public bool ModificarEstadoTraduccion(int idTraduccion, int estado)
        {
            return _traduccionDao.ModificarEstadoTraduccion(idTraduccion, estado);
        }

        public List<Traduccion> ListarTraducciones(int estado)
        {
            return _traduccionDao.ListarTraducciones(estado);
        }
    }
}
