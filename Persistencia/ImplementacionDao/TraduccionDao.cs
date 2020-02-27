using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class TraduccionDao : ITraduccionDao
    {
        private readonly DB_OverseasContext _context;
        public TraduccionDao(DB_OverseasContext context) => _context = context;        

        public Traduccion BuscarTraduccion(int idTraduccion) => _context.Traduccion
                                                        .Where(t => t.IdTraduccion == idTraduccion)
                                                        .Include(t => t.Docente)
                                                            .ThenInclude(d => d.Persona)
                                                        .FirstOrDefault();

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

        public bool ModificarEstadoTraduccion(int idTraduccion, int estado)
        {
            try
            {
                Traduccion traduccion = BuscarTraduccion(idTraduccion);
                if (traduccion != null)
                {                    
                    traduccion.EstadoTraduccion = estado;
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

        public List<Traduccion> ListarTraducciones(int estado) => _context.Traduccion
                                                        .Where(t => t.EstadoTraduccion == estado)
                                                        .Include(t => t.Docente)
                                                            .ThenInclude(d => d.Persona)
                                                        .ToList();


        public int CantidadDeTraduccionesPendientes() => _context.Traduccion
                                                    .Where(t => t.EstadoTraduccion == 1)
                                                    .Count();



    }
}
