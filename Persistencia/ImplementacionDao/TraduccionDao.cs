using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class TraduccionDao : ITraduccionDao
    {
        private readonly DB_OverseasContext _context;
        public TraduccionDao(DB_OverseasContext context)
        {
            _context = context;
        }

        public Traduccion BuscarTraduccion(int idTraduccion)
        {
            Traduccion traduccion = new Traduccion();
            try
            {
                traduccion =    (from t in _context.Traduccion join
                                d in _context.Docente on t.IdDocente equals d.IdDocente join
                                p in _context.Persona on d.IdPersona equals p.IdPersona
                                where t.EstadoTraduccion == 1 && t.IdTraduccion == idTraduccion
                                select new Traduccion
                                {
                                    IdTraduccion = t.IdTraduccion,
                                    ClienteTraduccion = t.ClienteTraduccion,
                                    TipoTraduccion = t.TipoTraduccion,
                                    DetalleTraduccion = t.DetalleTraduccion,
                                    IdiomaOrigenTraduccion = t.IdiomaOrigenTraduccion,
                                    IdiomaDestinoTraduccion = t.IdiomaDestinoTraduccion,
                                    FechaTraduccion = t.FechaTraduccion,
                                    EstadoTraduccion = t.EstadoTraduccion,
                                    IdDocente = t.IdDocente,
                                    Docente = new Docente
                                    {
                                        Persona = t.Docente.Persona
                                    }
                                }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

            return traduccion;
        }

        public bool CrearTraduccion(Traduccion traduccion)
        {
            try
            {
                _context.Traduccion.Add(traduccion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditarTraduccion(Traduccion traduccion)
        {
            try
            {
                
                _context.Traduccion.Attach(traduccion);
                _context.Traduccion.Update(traduccion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarTraduccion(int idTraduccion)
        {
            try
            {
                Traduccion traduccion = BuscarTraduccion(idTraduccion);
                if (traduccion != null)
                {                    
                    traduccion.EstadoTraduccion = 0;
                    _context.Traduccion.Attach(traduccion);
                    _context.Traduccion.Update(traduccion);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Traduccion> ListarTraducciones()
        {
            List<Traduccion> traducciones = new List<Traduccion>();
            try
            {
                    traducciones = (from t in _context.Traduccion join 
                                    d in _context.Docente on t.IdDocente equals d.IdDocente join
                                    p in _context.Persona on d.IdPersona equals p.IdPersona
                                    where t.EstadoTraduccion == 1
                                select new Traduccion
                                {
                                    IdTraduccion = t.IdTraduccion,
                                    ClienteTraduccion = t.ClienteTraduccion,
                                    TipoTraduccion = t.TipoTraduccion,
                                    DetalleTraduccion = t.DetalleTraduccion,
                                    IdiomaOrigenTraduccion = t.IdiomaOrigenTraduccion,
                                    IdiomaDestinoTraduccion = t.IdiomaDestinoTraduccion,
                                    FechaTraduccion = t.FechaTraduccion,
                                    EstadoTraduccion = t.EstadoTraduccion,
                                    IdDocente = t.IdDocente,
                                    Docente = new Docente
                                    {
                                        Persona = t.Docente.Persona
                                    }
                                }).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }

            return traducciones;
        }





        public int CantidadDeTraduccionesPendientes() => _context.Traduccion
                                                    .Where(t => t.EstadoTraduccion == 1)
                                                    .Count();



    }
}
