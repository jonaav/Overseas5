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

        public AsistenciaController(
            IAsistenciaService asistenciaService
        )
        {
            _asistenciaService = asistenciaService;
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
        public IActionResult Details(int id)
        {
            return View();
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
        public IActionResult ListarAsistenciasPorSesion(int idCurso)
        {
            List<Asistencia> asistencias = _asistenciaService.ListarAsistenciasPorSesion(idCurso);
            if(asistencias != null)
                return Json(asistencias);
            else
                return Json("");
        }


    }
}