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
        private readonly IDocenteDao _docenteDao;
        private readonly ITipoCursoDao _tipoCursoDao;

        public CursoServiceImpl(
            ICursoDao cursoDao,
            IDocenteDao docenteDao,
            ITipoCursoDao tipoCursoDao
        )
        {
            _cursoDao = cursoDao;
            _docenteDao = docenteDao;
            _tipoCursoDao = tipoCursoDao;
        }



        /*
         *  Listar Cursos
         */
        public List<Curso> ListarCursos(string nombreCurso, string programa, int estado)
        {
            List<Curso> curso = _cursoDao.ListarCursos (nombreCurso, programa, estado);
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
         *  Listar Docentes Habiles - estado = 1
         */
        public List<Docente> ListarDocentes()
        {
            List<Docente> docentes = _docenteDao.ListarDocentesHabilitados();
            return docentes;
        }

        

        /*
         *  Buscar Docente
         */
        public Docente BuscarDocentePorID(int idDocente)
        {
            Docente docente = _docenteDao.BuscarDocenteID(idDocente);
            return docente;
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
         *  Buscar TipoCurso por nombre
         */
        public TipoCurso BuscarTipoCursoPorNombre(string nombreCurso)
        {
            TipoCurso tipoCurso = _tipoCursoDao.BuscarTipoCursoPorNombre(nombreCurso);
            return tipoCurso;
        }



        /*
         *  Crear Curso
         */
        public String RegistrarCurso(Curso curso)
        {
            String mensaje = "No se pudo registrar";
            if (curso.ValidarFechaFin())
            {
                if (_cursoDao.RegistrarCurso(curso))
                {
                    mensaje = "Registrado";
                }
            }
            else
            {
                mensaje = "La fecha fin debe ser mayor que la fecha inicio";
            }
            return mensaje;
        }

        /*
         *  Editar Curso
         */
        public String EditarCurso(Curso curso)
        {
            String mensaje = "No se pudo actualizar los datos";
            
            if (curso.ValidarFechaFin())
            {
                if (_cursoDao.EditarCurso(curso))
                {
                    mensaje = "Exito";
                }
            }
            else
            {
                mensaje = "La fecha fin debe ser mayor que la fecha inicio";
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
