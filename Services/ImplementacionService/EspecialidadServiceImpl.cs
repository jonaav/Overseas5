using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class EspecialidadServiceImpl:IEspecialidadService
    {
        private readonly IEspecialidadDao _especialidadDao;
        private readonly IDetalleDocenteEspecialidadDao _detalleDocenteEspecialidadDao;
        public EspecialidadServiceImpl(
            IEspecialidadDao especialidadDao,
            IDetalleDocenteEspecialidadDao detalleDocenteEspecialidadDao
        )
        {
            _especialidadDao = especialidadDao;
            _detalleDocenteEspecialidadDao = detalleDocenteEspecialidadDao;
        }


        /**/
        public List<Especialidad> ListaDeEspecialidades()
        {
            List<Especialidad> especialidades = _especialidadDao.ListaDeEspecialidades();
            return especialidades;
        }

        /**/
        public Especialidad BuscarEspecialidadPorID(int id)
        {
            Especialidad especialidad = _especialidadDao.BuscarEspecialidadPorID(id);
            return especialidad;
        }

        /**/
        public bool RegistrarEspecialidad(Especialidad especialidad)
        {
            bool registroCompletado = _especialidadDao.RegistrarEspecialidad(especialidad);
            return registroCompletado;
        }

        /**/
        public bool EliminarEspecialidad(int idEspecialidad)
        {
            bool eliminado = false;
            List<DetalleDocenteEspecialidad> detalles = _detalleDocenteEspecialidadDao.BuscarDetallesPorEspecialidad(idEspecialidad);
            if(detalles!= null)
            {
                foreach(DetalleDocenteEspecialidad detalle in detalles)
                {
                    _detalleDocenteEspecialidadDao.EliminarDetalleDocenteEspecialidad(detalle);
                }
            }
            Especialidad especialidad = _especialidadDao.BuscarEspecialidadPorID(idEspecialidad);
            eliminado = _especialidadDao.EliminarEspecialidad(especialidad);
            return eliminado;
        }

    }
}
