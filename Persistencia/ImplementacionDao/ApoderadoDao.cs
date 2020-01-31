using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class ApoderadoDao: IApoderadoDao
    {
        private readonly DB_OverseasContext _context;
        public ApoderadoDao(DB_OverseasContext context) => _context = context;


        public Apoderado BuscarApoderadoPorID(int id) => _context.Apoderado.Find(id);

        public int BuscarIDApoderado(Apoderado ap)
        {
            Apoderado apoderado = new Apoderado();
            try
            {
                apoderado = (from a in _context.Apoderado
                             where (a.NombresApoderado == ap.NombresApoderado) &&
                                    (a.ApellidosApoderado == ap.ApellidosApoderado) &&
                                    (a.CorreoApoderado == ap.CorreoApoderado)
                             select new Apoderado
                             {
                                 IdApoderado = a.IdApoderado
                             }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return apoderado.IdApoderado;
        }


        public bool RegistrarApoderado(Apoderado apoderado)
        {
            try
            {
                _context.Apoderado.Add(apoderado);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public bool EditarApoderado(Apoderado apoderado)
        {
            try
            {
                _context.Apoderado.Attach(apoderado);
                _context.Apoderado.Update(apoderado);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarApoderado(Apoderado apoderado)
        {
            try
            {
                _context.Apoderado.Attach(apoderado);
                _context.Apoderado.Remove(apoderado);
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
