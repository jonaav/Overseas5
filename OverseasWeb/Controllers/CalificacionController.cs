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
        private readonly ICalificacionesService _calificacionService;

        public CalificacionController(
            IEstudianteService estudianteService,
            ICursoService cursoService,
            ICalificacionesService calificacionService
        )
        {
            _estudianteService = estudianteService;
            _cursoService = cursoService;
            _calificacionService = calificacionService;
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


        public IActionResult VerNotasDelEstudiantePorCurso(int idCurso, int idEstudiante)
        {
            List<Evaluacion> evaluaciones = _calificacionService.VerNotasDelEstudiantePorCurso(idCurso, idEstudiante);
            return Json(evaluaciones);
        }


        public IActionResult CalificacionDocente()
        {
            return View();
        }
    }
}