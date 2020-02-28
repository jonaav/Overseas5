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
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;        
        

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;            
        }


        #region Curso Regular

        [Authorize(Roles = "Admin")]
        public IActionResult ListarCursosPrivados()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListarCursosRegular()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ListarCursos(string nombreCurso, string programa, int estado)
        {
            List<Curso> cursos = _cursoService.ListarCursos(nombreCurso, programa, estado);
            return Json(cursos);

        }


        [Authorize(Roles = "Admin")]
        public IActionResult ListarDocentes()
        {
            List<Docente> docentes = _cursoService.ListarDocentes();
            return Json(docentes);

        }


        [Authorize(Roles = "Admin")]
        public IActionResult BuscarDocentePorID(int idDocente)
        {
            Docente docente = _cursoService.BuscarDocentePorID(idDocente);
            return Json(docente);
        }

        [Authorize]
        public IActionResult BuscarCursoPorID(int idCurso)
        {
            Curso curso = _cursoService.BuscarCursoPorID(idCurso);
            return Json(curso);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult BuscarTipoCurso(string nombreCurso)
        {
            TipoCurso tipoCurso = _cursoService.BuscarTipoCursoPorNombre(nombreCurso);
            return Json(tipoCurso);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult RegistrarCurso()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RegistrarCurso(Curso curso)
        {
            var mensaje = _cursoService.RegistrarCurso(curso);
            return Json(mensaje);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditarCurso(Curso curso)
        {
            var mensaje = _cursoService.EditarCurso(curso);
            return Json(mensaje);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EliminarCurso(int idCurso)
        {
            var mensaje = _cursoService.EliminarCurso(idCurso);
            return Json(mensaje);
        }

        #endregion Curso Regular

    }
}