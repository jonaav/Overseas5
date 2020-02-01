using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class DocenteDao : IDocenteDao
    {
        private readonly DB_OverseasContext _context;
        private readonly IDetalleDocenteEspecialidadDao _detalleDocenteEspecialidadDao;
        public DocenteDao(
            DB_OverseasContext context,
            IDetalleDocenteEspecialidadDao detalleDocenteEspecialidadDao
        ) {
            _context = context;
            _detalleDocenteEspecialidadDao = detalleDocenteEspecialidadDao;
        }


        #region public


        /*
         *  Listar Docentes
         */

        public List<Docente> ListarDocentes() => _context.Docente
                                                    .Include(d => d.Persona)
                                                    .ToList();


        /*
         *  Listar Docentes Habilitados
         */

        public List<Docente> ListarDocentesHabilitados() => _context.Docente
                                                    .Where(d => d.Estado == 1)
                                                    .Include(d => d.Persona)
                                                    .ToList();



        /*
         *  Buscar Docente por DNI
         */

        public Docente BuscarDocenteDNI(string dni) => _context.Docente
                                                        .Where(d => d.Persona.DniPersona == dni)
                                                        .Include(d => d.Persona)
                                                        .FirstOrDefault();




        /*
         *  Buscar Docente por ID
         */

        public Docente BuscarDocenteID(int idDocente) => 
            _context.Docente.Where(d =>d.IdDocente == idDocente).Include(d => d.Persona).FirstOrDefault();



        /*
         *  Buscar Docente por Correo
         */

        public Docente BuscarDocenteCorreo(string correo) => _context.Docente
                                                        .Where(d => d.Persona.CorreoPersona == correo)
                                                        .Include(d => d.Persona)
                                                        .FirstOrDefault();



        /*  no se usa prob
         *  Buscar Docente por ID Persona
         */

        public Docente BuscarDocentePorIdPersona(int idPersona) => _context.Docente
                                                                    .Where(d => d.IdPersona == idPersona)
                                                                    .Include(d => d.Persona)
                                                                    .FirstOrDefault();



        /*
         *  Buscar Especialidades del docente
         */

        public List<Especialidad> BuscarEspecialidadesDelDocente(int id)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                especialidades = (from e in _context.Especialidad
                            join dt in _context.DetalleDocenteEspecialidad on e.IdEspecialidad equals dt.Especialidad.IdEspecialidad
                            join d in _context.Docente on dt.Docente.IdDocente equals d.IdDocente
                            where d.IdDocente == id
                            select new Especialidad
                            {
                                IdEspecialidad = e.IdEspecialidad,
                                DescripcionEspecialidad = e.DescripcionEspecialidad,
                            }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return especialidades;
        }




        /*
         *  Registrar Docente
         */

        public bool RegistrarDocente(Docente docente)
        {
            try
            {
                docente.Estado = 1;
                _context.Docente.Add(docente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        
        /*
         *  Editar Docente
         */

        public bool EditarDocente(Docente docente)
        {
            try
            {
                _context.Docente.Attach(docente);
                _context.Docente.Update(docente);
                _context.Persona.Attach(docente.Persona);
                _context.Persona.Update(docente.Persona);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  SE ELIMINAN LAS RELACIONES - DetalleDocenteEspecialidad
         */

        public bool EliminarEspecialidadesDelDocente(int idDocente)
        {
            List<DetalleDocenteEspecialidad> detalles = BuscarDetalleEspecialidadesDelDocente(idDocente);
            bool exito = false;
            try
            {
                foreach (DetalleDocenteEspecialidad detalle in detalles)
                {
                    exito = _detalleDocenteEspecialidadDao.EliminarDetalleDocenteEspecialidad(detalle);
                }
                return exito;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  Contar Docentes Activos
         */

        public int CantidadDeDocentesActivos() => _context.Docente
                                                    .Where(d => d.Estado == 1)
                                                    .Count();


        #endregion public


        #region private


        private List<DetalleDocenteEspecialidad> BuscarDetalleEspecialidadesDelDocente(int id)
        {
            List<DetalleDocenteEspecialidad> detalles = new List<DetalleDocenteEspecialidad>();
            try
            {
                detalles = (from dt in _context.DetalleDocenteEspecialidad
                            join d in _context.Docente on dt.Docente.IdDocente equals d.IdDocente
                            where d.IdDocente == id
                            select new DetalleDocenteEspecialidad
                            {
                                IdDetalleDocenteEspecialidad = dt.IdDetalleDocenteEspecialidad,
                                IdDocente = dt.IdDocente,
                                IdEspecialidad = dt.IdEspecialidad
                            }).ToList();
                return detalles;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion private
    }
}
