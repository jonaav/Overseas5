using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class AmbienteDao : IAmbienteDao
    {

        private readonly DB_OverseasContext _context;
        public AmbienteDao(DB_OverseasContext context) => _context = context;
        
        public Ambiente BuscarAmbiente(int idAmbiente) => _context.Ambiente
                                                          .Where(a => a.IdAmbiente == idAmbiente && a.Estado == 1)
                                                          .FirstOrDefault();

        public bool CrearAmbiente(Ambiente ambiente)
        {
            try
            {
                _context.Ambiente.Add(ambiente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarAmbiente(int idAmbiente)
        {
            try
            {
                Ambiente ambiente = BuscarAmbiente(idAmbiente);
                if (ambiente != null)
                {
                    ambiente.Estado = 0;
                    _context.Ambiente.Attach(ambiente);
                    _context.Ambiente.Update(ambiente);
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

        public List<Ambiente> ListarAmbientes() => _context.Ambiente
                                                   .Where(a => a.Estado == 1)
                                                   .ToList();
    }
}
