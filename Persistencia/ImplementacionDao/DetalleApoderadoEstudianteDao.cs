using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class DetalleApoderadoEstudianteDao: IDetalleApoderadoEstudianteDao
    {
        private readonly DB_OverseasContext _context;
        public DetalleApoderadoEstudianteDao(DB_OverseasContext context)
        {
            _context = context;
        }

        public DetalleApoderadoEstudiante BuscarApoderadoDeUnEstudiante(int id)
        {
            DetalleApoderadoEstudiante detalle = new DetalleApoderadoEstudiante();
            try
            {
                detalle = (from d in _context.DetalleApoderadoEstudiante
                              join e in _context.Estudiante on d.Estudiante.IdEstudiante equals e.IdEstudiante
                              join a in _context.Apoderado on d.Apoderado.IdApoderado equals a.IdApoderado
                              where d.IdEstudiante == id
                              select new DetalleApoderadoEstudiante
                              {
                                  Estudiante = d.Estudiante,
                                  Apoderado = d.Apoderado
                              }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return detalle;
        }

        public DetalleApoderadoEstudiante BuscarDetalle(int idEstudiante)
        {
            DetalleApoderadoEstudiante detalle = new DetalleApoderadoEstudiante();
            try
            {
                detalle = (from d in _context.DetalleApoderadoEstudiante
                           join e in _context.Estudiante on d.Estudiante.IdEstudiante equals e.IdEstudiante
                           join a in _context.Apoderado on d.Apoderado.IdApoderado equals a.IdApoderado
                           where d.IdEstudiante == idEstudiante
                           select new DetalleApoderadoEstudiante
                           {
                               IdDetalleApodEst = d.IdDetalleApodEst,
                               IdApoderado = d.IdApoderado,
                               IdEstudiante = d.IdEstudiante
                           }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return detalle;
        }

        public bool RegistrarDetalle(DetalleApoderadoEstudiante detalle)
        {
            try
            {
                _context.DetalleApoderadoEstudiante.Add(detalle);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool EliminarDetalle(DetalleApoderadoEstudiante detalle)
        {
            try
            {
                _context.DetalleApoderadoEstudiante.Attach(detalle);
                _context.DetalleApoderadoEstudiante.Remove(detalle);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}
