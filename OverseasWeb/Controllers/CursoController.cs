using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;

namespace OverseasWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;        
        

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;            
        }


        #region Curso Regular

        public IActionResult ListarCursosPrivados()
        {
            return View();
        }

        public IActionResult ListarCursosRegular()
        {
            return View();
        }


        public IActionResult ListarCursos(string nombreCurso, string programa)
        {
            List<Curso> cursos = _cursoService.ListarCursos(nombreCurso, programa);
            return Json(cursos);

        }
        

        public IActionResult ListarDocentes()
        {
            List<Docente> docentes = _cursoService.ListarDocentes();
            return Json(docentes);

        }


        public IActionResult BuscarDocentePorID(int idDocente)
        {
            Docente docente = _cursoService.BuscarDocentePorID(idDocente);
            return Json(docente);
        }

        public IActionResult BuscarCursoPorID(int idCurso)
        {
            Curso curso = _cursoService.BuscarCursoPorID(idCurso);
            return Json(curso);
        }

        public IActionResult BuscarTipoCurso(string nombreCurso)
        {
            TipoCurso tipoCurso = _cursoService.BuscarTipoCursoPorNombre(nombreCurso);
            return Json(tipoCurso);
        }


        public IActionResult RegistrarCurso()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegistrarCurso(Curso curso)
        {
            var mensaje = _cursoService.RegistrarCurso(curso);
            return Json(mensaje);
        }


        [HttpPost]
        public IActionResult EditarCurso(Curso curso)
        {
            var mensaje = _cursoService.EditarCurso(curso);
            return Json(mensaje);
        }


        [HttpPost]
        public IActionResult EliminarCurso(int idCurso)
        {
            var mensaje = _cursoService.EliminarCurso(idCurso);
            return Json(mensaje);
        }

        #endregion Curso Regular






    }
}