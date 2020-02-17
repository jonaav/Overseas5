using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class CursoDao:ICursoDao
    {

        private readonly DB_OverseasContext _context;
        public CursoDao(DB_OverseasContext context) => _context = context;


        /*
         *  Listar Cursos
         */
        public List<Curso> ListarCursos (string nombreCurso, string programa, int estado) => _context.Curso
                                                                                .Where(c => (c.Programa == programa &&
                                                                                             c.TipoCurso.NombreCurso == nombreCurso &&
                                                                                             c.Estado == estado))
                                                                                .Include(c => c.TipoCurso)
                                                                                .Include(c => c.Docente)
                                                                                    .ThenInclude(d => d.Persona)
                                                                                .OrderByDescending(c => c.IdCurso).ToList();


        /*
         *  Listar Cursos Habiles
         */
        public List<Curso> ListarCursosHabiles () => _context.Curso
                                                    .Where(c => c.Estado == 1)
                                                    .Include(c => c.TipoCurso)
                                                    .Include(c => c.Docente)
                                                        .ThenInclude(d => d.Persona)
                                                    .ToList();
        
        /*
         *  Buscar Curso
         */
        public Curso BuscarCursoPorID(int idCurso) => _context.Curso
                                                    .Where(c => c.IdCurso == idCurso)
                                                    .Include(c => c.TipoCurso)
                                                    .Include(c => c.Docente)
                                                        .ThenInclude(d => d.Persona)
                                                    .FirstOrDefault();

        /*
         *  Registrar Curso
         */
        public bool RegistrarCurso(Curso curso)
        {
            try
            {
                _context.Curso.Add(curso);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                throw e;
            }
        }

        /*
         *  Editar Curso
         */
        public bool EditarCurso(Curso curso)
        {
            try
            {
                _context.Curso.Attach(curso);
                _context.Curso.Update(curso);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        

        /*
         *  Eliminar Curso
         */
        public bool EliminarCurso(int idCurso)
        {
            Curso curso = BuscarCursoPorID(idCurso);
            try
            {
                if( curso != null)
                {
                    _context.Curso.Remove(curso);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /*
         * Contar cursos Activos - estado = 1
         */

        public int CantidadDeCursosActivos() => _context.Curso
                                                    .Where(c => c.Estado == 1)
                                                    .Count();





    }
}
