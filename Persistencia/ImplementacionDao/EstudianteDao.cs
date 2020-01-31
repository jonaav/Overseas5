using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class EstudianteDao: IEstudianteDao
    {
        private readonly DB_OverseasContext _context;
        public EstudianteDao(DB_OverseasContext context)
        {
            _context = context;
        }


        /*
         *  Listar Estudiantes
         */

        public List<Estudiante> ListarEstudiantes() => _context.Estudiante
            .Include(e => e.Persona).ToList();



        /*
         *  Buscar estudiante por DNI
         */


        public Estudiante BuscarEstudianteDNI(string dni) => _context.Estudiante
            .Where(e => e.Persona.DniPersona == dni).Include(e => e.Persona).FirstOrDefault();




        /*
         *  Buscar estudiante por ID 
         */

        public Estudiante BuscarEstudianteID(int id) => _context.Estudiante
            .Where(e => e.IdEstudiante == id).Include(e => e.Persona).FirstOrDefault();


        /*
         *  Buscar estudiante por Correo
         */

        public Estudiante BuscarEstudianteCorreo(string correo) => _context.Estudiante
            .Where(e => e.Persona.CorreoPersona == correo).Include(e => e.Persona).FirstOrDefault();




        /*
         *  Registrar Estudiante
         */

        public bool RegistrarEstudiante(Estudiante estudiante)
        {
            try
            {
                _context.Estudiante.Add(estudiante);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /*
         *  Editar Estudiante
         */

        public bool EditarEstudiante(Estudiante estudiante)
        {
            try
            {
                _context.Estudiante.Attach(estudiante);
                _context.Estudiante.Update(estudiante);
                _context.Persona.Attach(estudiante.Persona);
                _context.Persona.Update(estudiante.Persona);
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
