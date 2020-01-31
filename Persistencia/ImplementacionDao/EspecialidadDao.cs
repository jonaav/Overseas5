using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class EspecialidadDao : IEspecialidadDao
    {

        private readonly DB_OverseasContext _context;
        public EspecialidadDao(DB_OverseasContext context)
        {
            _context = context;
        }



        /*
         *  Listar Especialidades
         */

        public List<Especialidad> ListaDeEspecialidades() => _context.Especialidad.ToList();




        /*
         *  Buscar Especialidad por ID
         */

        public Especialidad BuscarEspecialidadPorID(int id) => _context.Especialidad.Find(id);


        /*
         *  Registrar Especialidad
         */

        public bool RegistrarEspecialidad(Especialidad especialidad)
        {
            try
            {
                _context.Especialidad.Add(especialidad);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  Eliminar Especialidad
         */

        public bool EliminarEspecialidad(Especialidad especialidad)
        {
            try
            {
                _context.Especialidad.Remove(especialidad);
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
