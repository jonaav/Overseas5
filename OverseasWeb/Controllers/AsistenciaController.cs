using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;
using Microsoft.AspNetCore.Authorization;

namespace OverseasWeb.Controllers
{
    public class AsistenciaController : Controller
    {
        private IAsistenciaService _asistenciaService;
        private ISesionService _sesionService;

        public AsistenciaController(
            IAsistenciaService asistenciaService,
            ISesionService sesionService
        )
        {
            _asistenciaService = asistenciaService;
            _sesionService = sesionService;
        }


        /*
         * ADMIN
         */

        [Authorize(Roles = "Admin")]
        public IActionResult AsistenciaAdmin()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ListarSesionesPorCurso(int idCurso)
        {
            List<Sesion> sesiones = _sesionService.ListarSesionesCurso(idCurso);
            return Json(sesiones);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult BuscarSesionPorID(int idSesion)
        {
            Sesion sesion = _sesionService.BuscarSesionPorID(idSesion);
            return Json(sesion);
        }



        [Authorize(Roles = "Admin")]
        public IActionResult ListarAsistenciasPorSesion(int idSesion)
        {
            List<Asistencia> asistencias = _asistenciaService.ListarAsistenciasPorSesion(idSesion);
            if (asistencias != null)
                return Json(asistencias);
            else
                return Json("");
        }


        /*
         * DOCENTE
         */

        [Authorize(Roles = "Docente")]
        public IActionResult AsistenciaDocente()
        {
            return View();
        }


        [Authorize(Roles = "Docente")]
        public IActionResult ListarAsistenciasPorSesionCurso(int idCurso)
        {
            List<Asistencia> asistencias = _asistenciaService.ListarAsistenciasPorSesionCurso(idCurso);
            if(asistencias != null)
                return Json(asistencias);
            else
                return Json("");
        }

        [HttpPost]
        [Authorize(Roles = "Docente")]
        public IActionResult EditarAsistencias(List<int> asistieron)
        {
            String mensaje = _asistenciaService.EditarAsistencias(asistieron);
            return Json(mensaje);
        }
        

        [HttpPost]
        [Authorize(Roles = "Docente")]
        public IActionResult MarcarAsistenciaDocente(int idCurso)
        {
            String mensaje = _asistenciaService.MarcarAsistenciaDocente(idCurso);
            return Json(mensaje);
        }

        [Authorize(Roles = "Docente")]
        public IActionResult VerificarSesionActiva(int idCurso)
        {
            bool activo = _asistenciaService.VerificarSesionActiva(idCurso);
            return Json(activo);
        }


    }
}