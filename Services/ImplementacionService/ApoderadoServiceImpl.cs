using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class ApoderadoServiceImpl: IApoderadoService
    {
        private readonly IApoderadoDao _apoderadoDao;
        private readonly IDetalleApoderadoEstudianteDao _detalleApoderadoEstudianteDao;
        private readonly IEstudianteDao _estudianteDao;

        public ApoderadoServiceImpl(
            IApoderadoDao apoderadoDao,
            IDetalleApoderadoEstudianteDao detalleApoderadoEstudianteDao,
            IEstudianteDao estudianteDao
        )
        {
            _apoderadoDao = apoderadoDao;
            _detalleApoderadoEstudianteDao = detalleApoderadoEstudianteDao;
            _estudianteDao = estudianteDao;
        }


        public String RegistrarDetalleApoderadoEstudiante(Estudiante estudiante, Apoderado apoderado)
        {
            DetalleApoderadoEstudiante detalle = new DetalleApoderadoEstudiante();
            String mensaje = "No se pudo registrar el apoderado";
            if (apoderado.NombresApoderado !="" && apoderado.ApellidosApoderado !="" && apoderado.CorreoApoderado !="" )
            {
                if (_apoderadoDao.RegistrarApoderado(apoderado))
                {
                    Estudiante estudianteBuscado = _estudianteDao.BuscarEstudianteDNI(estudiante.Persona.DniPersona);
                    detalle.IdEstudiante = estudianteBuscado.IdEstudiante;
                    detalle.IdApoderado = _apoderadoDao.BuscarIDApoderado(apoderado);
                    if (_detalleApoderadoEstudianteDao.RegistrarDetalle(detalle))
                    {
                        mensaje = "Registro Completado";
                    }
                    else
                    {
                        _apoderadoDao.EliminarApoderado(apoderado);
                    }
                }
            }
            else
            {
                mensaje = "Debe llenar los datos del apoderado";
            }
            return mensaje;
        }


        public String EditarApoderado(Apoderado apoderado)
        {
            String mensaje = "No se pudo actualizar los datos";
            if (_apoderadoDao.EditarApoderado(apoderado))
            {
                mensaje = "Datos actualizados";
            }
            return mensaje;
        }

        public String EliminarApoderado(Estudiante estudiante)
        {
            String mensaje = "No se pudo actualizar los datos";
            DetalleApoderadoEstudiante detalle = _detalleApoderadoEstudianteDao.BuscarDetalle(estudiante.IdEstudiante);
            Apoderado apoderado = _apoderadoDao.BuscarApoderadoPorID(detalle.IdApoderado);
            if (_detalleApoderadoEstudianteDao.EliminarDetalle(detalle))
            {
                if (_apoderadoDao.EliminarApoderado(apoderado))
                {
                    mensaje = "Apoderado eliminado";
                }
                else
                {
                    _detalleApoderadoEstudianteDao.RegistrarDetalle(detalle);
                }
            }
            return mensaje;
        }


    }
}
