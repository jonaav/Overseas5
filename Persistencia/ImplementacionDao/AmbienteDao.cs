using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class AmbienteDao : IAmbienteDao
    {

        private readonly DB_OverseasContext _context;
        public AmbienteDao(DB_OverseasContext context)
        {
            _context = context;
        }
        public Ambiente BuscarAmbiente(int idAmbiente)
        {
            Ambiente ambiente = new Ambiente();
            try
            {
                ambiente = (from a in _context.Ambiente
                            where a.Estado == 1 && a.IdAmbiente == idAmbiente
                            select a).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ambiente;
        }

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

        public List<Ambiente> ListarAmbientes()
        {
            List<Ambiente> ambientes = new List<Ambiente>();
            try
            {
                ambientes = (from a in _context.Ambiente
                             where a.Estado == 1
                             select a).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ambientes;
        }
    }
}
