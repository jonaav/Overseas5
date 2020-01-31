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
    [Authorize(Roles = "Admin")]
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IApoderadoService _apoderadoService;

        public EstudianteController(
            IEstudianteService estudianteService,
            IApoderadoService apoderadoService
        )
        {
            _estudianteService = estudianteService;
            _apoderadoService = apoderadoService;
        }

        #region IActionResult
        // GET: Estudiante
        public IActionResult ListarEstudiantes()
        {
            List<Estudiante> estudiantes = _estudianteService.ListarEstudiantes();
            ViewBag.Estudiantes = estudiantes;
            return View(estudiantes);
        }


        public IActionResult RegistrarEstudiante()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEstudiante(Estudiante estudiante)
        {
            var mensaje = _estudianteService.RegistrarEstudiante(estudiante);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult RegistrarApoderado(Estudiante estudiante, Apoderado apoderado)
        {
            var mensaje = _apoderadoService.RegistrarDetalleApoderadoEstudiante(estudiante, apoderado);
            return Json(mensaje);
        }


        public IActionResult EditarEstudiante(int id)
        {
            Estudiante estudiante = _estudianteService.BuscarEstudianteID(id);
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult EditarEstudiante(Estudiante estudiante)
        {
            var mensaje = _estudianteService.EditarEstudiante(estudiante);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult EditarApoderado(Apoderado apoderado)
        {
            var mensaje = _apoderadoService.EditarApoderado(apoderado);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult EliminarApoderado(Estudiante estudiante)
        {
            var mensaje = _apoderadoService.EliminarApoderado(estudiante);
            return Json(mensaje);
        }


        public IActionResult BuscarEstudiante(int id)
        {
            Estudiante estudiante = _estudianteService.BuscarEstudianteID(id);
            return Json(estudiante);
        }

        public IActionResult BuscarApoderadoDeUnEstudiante(int id)
        {
            Apoderado apoderado = _estudianteService.BuscarApoderadoDeUnEstudiante(id);
            return Json(apoderado);
        }

        

        #endregion IActionResult
    }
}
