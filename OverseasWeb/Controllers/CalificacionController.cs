using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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


        // ADMIN

        #region Admin
        [Authorize(Roles = "Admin")]
        public IActionResult CalificacionAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListarCursos()
        {
            List<Curso> cursos = _cursoService.ListarCursosHabiles();
            return Json(cursos);
        }
               



        #endregion Admin



        // DOCENTE


        #region Docente
        [Authorize(Roles = "Docente")]
        public IActionResult CalificacionDocente()
        {
            return View();
        }

        
        [Authorize(Roles = "Docente")]
        public IActionResult ListarCursosHabilesDelDocente()
        {
            var userInfo = HttpContext.User.Identity;
            List<Curso> cursos = _cursoService.ListarCursosHabilesDelDocente(userInfo.Name);
            if (cursos != null)
                return Json(cursos);
            else
                return Json("");
        }

        
        
        [Authorize(Roles = "Docente")]
        public IActionResult BuscarEvaluacion(int idEvaluacion)
        {
            Evaluacion evaluacion = _calificacionService.BuscarEvaluacion(idEvaluacion);
            if (evaluacion != null)
                return Json(evaluacion);
            else
                return Json("");
        }

        
        [HttpPost]
        [Authorize(Roles = "Docente")]
        public IActionResult EditarEvaluacion(int idEvaluacion, int nota )
        {
            String mensaje = _calificacionService.EditarEvaluacion(idEvaluacion, nota);
            return Json(mensaje);
        }








        #endregion Docente


        [Authorize]
        public IActionResult VerNotasDelEstudiantePorCurso(int idCurso, int idEstudiante)
        {
            List<Evaluacion> evaluaciones = _calificacionService.VerNotasDelEstudiantePorCurso(idCurso, idEstudiante);
            return Json(evaluaciones);
        }



    }
}