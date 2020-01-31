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

        public bool EliminarTraduccion(int idTraduccion)
        {
            return _traduccionDao.EliminarTraduccion(idTraduccion);
        }

        public List<Traduccion> ListarTraducciones()
        {
            return _traduccionDao.ListarTraducciones();
        }
    }
}
