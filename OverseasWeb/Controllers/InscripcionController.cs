using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades;
using Services.InterfazService;

namespace OverseasWeb.Controllers
{
    public class InscripcionController : Controller
    {
        private readonly IInscripcionService _inscripcionService;
        private readonly ICursoService _cursoService;
        private readonly IEstudianteService _estudianteService;

        public InscripcionController(
            IInscripcionService inscripcionService,
            ICursoService cursoService,
            IEstudianteService estudianteService
        )
        {
            _inscripcionService = inscripcionService;
            _cursoService = cursoService;
            _estudianteService = estudianteService;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ListarInscripciones()
        {
            return View();
        }

        [Authorize]
        public IActionResult ListarInscripcionesPorCurso(int idCurso)
        {
            List<Inscripcion> inscripciones = _inscripcionService.ListarInscripciones(idCurso);
            if (inscripciones != null)
                return Json(inscripciones);
            else
                return Json("");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ListarEstudiantesNoInscritos(int idCurso)
        {
            List<Estudiante> estudiantes = _inscripcionService.BuscarEstudiantesNoInscritos(idCurso);
            if (estudiantes != null)
                return Json(estudiantes);
            else
                return Json("");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListarCursosHabiles()
        {
            List<Curso> cursos = _cursoService.ListarCursosHabiles();
            if (cursos != null)
                return Json(cursos);
            else
                return Json("");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult BuscarCurso(int idCurso)
        {
            Curso curso = _cursoService.BuscarCursoPorID(idCurso);
            if (curso != null)
                return Json(curso);
            else
                return Json("");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RegistrarInscripcion()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RegistrarInscripcion(int idCurso, int idEstudiante)
        {
            bool registroCompletado = _inscripcionService.RegistrarInscripcion(idCurso, idEstudiante);
            if (registroCompletado)
                return Json("Exito");
            else
                return Json("Error");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AnularInscripcion(int id)
        {
            if (_inscripcionService.AnularInscripcion(id))
            {
                return Json("Exito");
            }
            else
            {
                return Json("Error");
            }
        }
    }
}
