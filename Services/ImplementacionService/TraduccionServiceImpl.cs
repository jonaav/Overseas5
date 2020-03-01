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

        public String CrearTraduccion(Traduccion traduccion)
        {
            String mensaje = "No se pudo registrar";
            if (_traduccionDao.CrearTraduccion(traduccion))
                mensaje = "Correcto";
            return mensaje;
        }

        public String EditarTraduccion(Traduccion traduccion)
        {
            String mensaje = "No se pudo editar";
            if (_traduccionDao.EditarTraduccion(traduccion))
                mensaje = "Exito";
            return mensaje;
        }

        public String ModificarEstadoTraduccion(int idTraduccion, int estado)
        {
            String mensaje = "No se pudo modificar";
            if (_traduccionDao.ModificarEstadoTraduccion(idTraduccion, estado))
                mensaje = "Correcto";
            return mensaje;

        }

        public List<Traduccion> ListarTraducciones(int estado)
        {
            return _traduccionDao.ListarTraducciones(estado);
        }
    }
}
