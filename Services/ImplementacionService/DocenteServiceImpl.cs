using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class DocenteServiceImpl : IDocenteService
    {
        private readonly IDocenteDao _docenteDao;
        private readonly IPersonaDao _personaDao;
        private readonly IUsuarioService _usuarioService;
        private readonly IDetalleDocenteEspecialidadDao _detalleDocenteEspecialidadDao;
        public DocenteServiceImpl(
            IDocenteDao docenteDao,
            IPersonaDao personaDao,
            IUsuarioService usuarioService,
            IDetalleDocenteEspecialidadDao detalleDocenteEspecialidadDao
        )
        {
            _docenteDao = docenteDao;
            _personaDao = personaDao;
            _usuarioService = usuarioService;
            _detalleDocenteEspecialidadDao = detalleDocenteEspecialidadDao;
        }

        #region metodos

        /**/
        public List<Docente> ListarDocentes()
        {
            List<Docente> docentes = _docenteDao.ListarDocentes();
            
            return docentes;
        }


        /**/
        public Docente BuscarDocenteID(int id)
        {
            Docente docente = _docenteDao.BuscarDocenteID(id);
            return docente;
        }
        
        /**/
        public Docente BuscarDocenteDNI(string dni)
        {
            Docente docente = _docenteDao.BuscarDocenteDNI(dni);
            return docente;
        }

        /**/
        public List<Especialidad> BuscarEspecialidadesDelDocente(int id)
        {
            List<Especialidad> especialidades = _docenteDao.BuscarEspecialidadesDelDocente(id);
            return especialidades;
        }


        /**/
        public String RegistrarDocente(Docente docente, List<Especialidad> especialidades)
        {
            String mensaje = "No se pudo completar el registro";
            //Validar docente repetido
            if (!VerificarDniRepetido(docente.Persona.DniPersona))
            {
                if (!VerificarCorreoRepetido(docente.Persona.CorreoPersona))
                {
                    //Asignacion de especialidades
                    if (_docenteDao.RegistrarDocente(docente))
                    {
                        docente = _docenteDao.BuscarDocenteDNI(docente.Persona.DniPersona);
                        if (AgregarEspecialidadesDelDocente(docente.IdDocente, especialidades))
                            mensaje = "Registro Completado";
                    }
                }
                else
                {
                    mensaje = "El correo electronico ya esta en uso";
                }
            }
            else
            {
                mensaje = "El docente ya se encuentra registrado";
            }
            return mensaje;
        }

        /**/
        public String EditarDocente(Docente docente, List<Especialidad> especialidades)
        {
            String mensaje = "No se pudo guardar los datos";
            bool datosCorrectos = true;

            //Verificar datos repetidos
            if (VerificarDniRepetido(docente.Persona.DniPersona, docente.IdDocente))
            {
                datosCorrectos = false;
                mensaje = "El docente ya se encuentra registrado";
            }
            if (VerificarCorreoRepetido(docente.Persona.CorreoPersona, docente.IdDocente))
            {
                datosCorrectos = false;
                mensaje = "El correo electronico ya esta en uso";
            }

            //Actualizar datos
            if (datosCorrectos)
            {
                if (_docenteDao.EditarDocente(docente))
                {
                    if (_docenteDao.EliminarEspecialidadesDelDocente(docente.IdDocente))
                    {
                        if (AgregarEspecialidadesDelDocente(docente.IdDocente, especialidades))
                            mensaje = "Datos actualizados";
                    }
                }
            }

            return mensaje;
        }



        #endregion metodos


        #region metodos Privados

        /**/
        private bool AgregarEspecialidadesDelDocente(int idDocente, List<Especialidad> especialidades)
        {
            bool exito = false;
            int especialidadAgregada = 0;
            //Asignacion de especialidades
            
            foreach (Especialidad especialidad in especialidades)
            {
                DetalleDocenteEspecialidad detalle = new DetalleDocenteEspecialidad
                {
                    IdDocente = idDocente,
                    IdEspecialidad = especialidad.IdEspecialidad
                };
                if (!_detalleDocenteEspecialidadDao.registrarDetalleDocenteEspecialidad(detalle))
                    especialidadAgregada += 1;
            }

            if (especialidadAgregada == 0)
            {
                exito = true;
            }

            return exito;
        }

        /**/
        private bool VerificarDniRepetido(string dni)
        {
            Docente docente = _docenteDao.BuscarDocenteDNI(dni);
            if (docente != null)
            {
                return true;
            }
            return false;
        }
        /**/
        private bool VerificarDniRepetido(string dni, int idDocente)
        {
            Docente docente = _docenteDao.BuscarDocenteDNI(dni);
            if (docente != null && docente.IdDocente != idDocente)
            {
                return true;
            }
            return false;
        }

        /**/
        private bool VerificarCorreoRepetido(string correo)
        {
            Docente docente = _docenteDao.BuscarDocenteCorreo(correo);
            if (docente != null)
            {
                return true;
            }
            return false;
        }
        
        /**/
        private bool VerificarCorreoRepetido(string correo, int idDocente)
        {
            Docente docente = _docenteDao.BuscarDocenteCorreo(correo);
            if (docente != null && docente.IdDocente != idDocente)
            {
                return true;
            }
            return false;
        }


        #endregion metodos Privados
    }
}
