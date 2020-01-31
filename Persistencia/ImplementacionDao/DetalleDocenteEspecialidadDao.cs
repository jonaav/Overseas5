using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class DetalleDocenteEspecialidadDao: IDetalleDocenteEspecialidadDao
    {
        private readonly DB_OverseasContext _context;
        public DetalleDocenteEspecialidadDao(DB_OverseasContext context)
        {
            _context = context;
        }

        /**/
        public bool registrarDetalleDocenteEspecialidad(DetalleDocenteEspecialidad detalle)
        {
            try
            {
                _context.DetalleDocenteEspecialidad.Add(detalle);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /**/
        public bool EliminarDetalleDocenteEspecialidad(DetalleDocenteEspecialidad detalle)
        {
            try
            {
                _context.DetalleDocenteEspecialidad.Attach(detalle);
                _context.DetalleDocenteEspecialidad.Remove(detalle);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        /**/
        public List<DetalleDocenteEspecialidad> BuscarDetallesPorEspecialidad(int idEspecialidad)
        {
            List<DetalleDocenteEspecialidad> detalles = new List<DetalleDocenteEspecialidad>();

            try
            {
                detalles = (from d in _context.DetalleDocenteEspecialidad
                            where d.IdEspecialidad == idEspecialidad
                            select new DetalleDocenteEspecialidad
                            {
                                IdDetalleDocenteEspecialidad = d.IdDetalleDocenteEspecialidad,
                                IdEspecialidad = d.IdEspecialidad,
                                IdDocente = d.IdDocente
                            }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return detalles;
        }
    }
}
