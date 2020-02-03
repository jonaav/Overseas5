using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;

namespace OverseasWeb.Controllers
{
    public class CalificacionController : Controller
    {
        private readonly IEstudianteService _estudianteService;
        private readonly ICursoService _cursoService;

        public CalificacionController(
            IEstudianteService estudianteService,
            ICursoService cursoService
        )
        {
            _estudianteService = estudianteService;
            _cursoService = cursoService;
        }




        public IActionResult CalificacionAdmin()
        {
            return View();
        }


        public IActionResult ListarCursos()
        {
            List<Curso> cursos = _cursoService.ListarCursosHabiles();
            return Json(cursos);
        }





        public IActionResult CalificacionDocente()
        {
            return View();
        }
    }
}