using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;
using Persistencia.InterfazDao;
using Services.InterfazService;


namespace Services.ImplementacionService
{
    public class EstudianteServiceImpl : IEstudianteService
    {
        private readonly IEstudianteDao _estudianteDao;
        private readonly IPersonaDao _personaDao;
        private readonly IDetalleApoderadoEstudianteDao _detalleApoderadoEstudianteDao;
        public EstudianteServiceImpl(
            IEstudianteDao estudianteDao,
            IPersonaDao personaDao,
            IDetalleApoderadoEstudianteDao detalleApoderadoEstudianteDao
        ){
            _estudianteDao = estudianteDao;
            _personaDao = personaDao;
            _detalleApoderadoEstudianteDao = detalleApoderadoEstudianteDao;
        }
        public List<Estudiante> ListarEstudiantes()
        {
            List<Estudiante> estudiantes = _estudianteDao.ListarEstudiantes();
            return estudiantes;
        }

        public Estudiante BuscarEstudianteDNI(string dni)
        {
            Estudiante estudiante = _estudianteDao.BuscarEstudianteDNI(dni);
            return estudiante;
        }

        public Estudiante BuscarEstudianteID(int id)
        {
            Estudiante estudiante = _estudianteDao.BuscarEstudianteID(id);
            return estudiante;
        }
        public Apoderado BuscarApoderadoDeUnEstudiante(int id)
        {
            DetalleApoderadoEstudiante detalle = _detalleApoderadoEstudianteDao.BuscarApoderadoDeUnEstudiante(id);
            return detalle.Apoderado;
        }

        
        public String RegistrarEstudiante(Estudiante estudiante)
        {
            String mensaje = "No se pudo completar el registro";
            if (!VerificarDniRepetido(estudiante.Persona.DniPersona))
            {
                if (!VerificarCorreoRepetido(estudiante.Persona.CorreoPersona))
                {
                    bool registroCompleto = _estudianteDao.RegistrarEstudiante(estudiante);
                    if (registroCompleto)
                    {
                        mensaje = "Registro Completado";
                    }
                }
                else
                {
                    mensaje = "El correo ya se encuentra en uso";
                }
            }
            else
            {
                mensaje = "El estudiante ya se encuentra registrado o el DNI esta en uso";
            }
            return mensaje;
        }
        public String EditarEstudiante(Estudiante estudiante)
        {
            String mensaje = "No se pudo realizar los cambios";
            if (!VerificarDniRepetido(estudiante.Persona.DniPersona, estudiante.IdEstudiante))
            {
                if (!VerificarCorreoRepetido(estudiante.Persona.CorreoPersona, estudiante.IdEstudiante))
                {
                    if (_estudianteDao.EditarEstudiante(estudiante))
                    {
                        mensaje = "Datos Actualizados";
                    }
                }
                else
                {
                    mensaje = "El correo ya está en uso";
                }
            }
            else
            {
                mensaje = "El DNI ya está en uso";
            }
            return mensaje;
        }

        //ESTO DEBE IR EN INSCRIPCION
        public int CalcularTotalDeEstudiantes()
        {
            int count = 0;
            foreach(Estudiante e in ListarEstudiantes())
            {
                count++;
            }
            return count;
        }


        #region private
        private bool VerificarDniRepetido(string dni)
        {
            Estudiante estudiante = _estudianteDao.BuscarEstudianteDNI(dni);
            if (estudiante != null)
            {
                return true;
            }
            return false;
        }
        private bool VerificarDniRepetido(string dni, int idEstudiante)
        {
            Estudiante estudiante = _estudianteDao.BuscarEstudianteDNI(dni);
            if (estudiante != null && estudiante.IdEstudiante != idEstudiante)
            {
                return true;
            }
            return false;
        }

        private bool VerificarCorreoRepetido(string correo)
        {
            Estudiante estudiante = _estudianteDao.BuscarEstudianteCorreo(correo);
            if (estudiante != null)
            {
                return true;
            }
            return false;
        }

        private bool VerificarCorreoRepetido(string correo, int idEstudiante)
        {
            Estudiante estudiante = _estudianteDao.BuscarEstudianteCorreo(correo);
            if (estudiante != null && estudiante.IdEstudiante != idEstudiante)
            {
                return true;
            }
            return false;
        }
        #endregion private
    }
}
