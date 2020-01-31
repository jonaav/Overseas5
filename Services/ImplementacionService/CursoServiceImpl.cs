using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class CursoServiceImpl:ICursoService
    {
        private readonly ICursoDao _cursoDao;

        public CursoServiceImpl(
            ICursoDao cursoDao
        )
        {
            _cursoDao = cursoDao;
        }



        /*
         *  Listar Cursos
         */
        public List<Curso> ListarCursos(string nombreCurso, string programa)
        {
            List<Curso> curso = _cursoDao.ListarCursos (nombreCurso, programa);
            return curso;
        }


        /*
         *  Listar Cursos Habiles - estado = 1
         */
        public List<Curso> ListarCursosHabiles()
        {
            List<Curso> cursos = _cursoDao.ListarCursosHabiles();
            return cursos;
        }





        /*
         *  Buscar Curso
         */
        public Curso BuscarCursoPorID(int idCurso)
        {
            Curso curso = _cursoDao.BuscarCursoPorID(idCurso);
            return curso;
        }



        /*
         *  Crear Curso
         */
        public String RegistrarCurso(Curso curso)
        {
            String mensaje = "No se pudo registrar";
            if (_cursoDao.RegistrarCurso(curso))
            {
                mensaje = "Registrado";
            }
            return mensaje;
        }

        /*
         *  Editar Curso
         */
        public String EditarCurso(Curso curso)
        {
            String mensaje = "No se pudo actualizar los datos";
            if (_cursoDao.EditarCurso(curso))
            {
                mensaje = "Exito";
            }
            return mensaje;
        }


        
        /*
         *  Eliminar Curso
         */
        public String EliminarCurso(int idCurso)
        {
            String mensaje = "No se pudo eliminar el curso";
            if (_cursoDao.EliminarCurso(idCurso))
            {
                mensaje = "Eliminado";
            }
            return mensaje;
        }











    }
}
