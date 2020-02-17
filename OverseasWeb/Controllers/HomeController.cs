using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;
using OverseasWeb.Models;

namespace OverseasWeb.Controllers
{
    public class HomeController : Controller
    {
        private IInicioAdminService _inicioAdminService;
        private IInicioDocenteService _inicioDocenteService;

        public HomeController(
            IInicioAdminService inicioAdminService,
            IInicioDocenteService inicioDocenteService
        )
        {
            _inicioAdminService = inicioAdminService;
            _inicioDocenteService = inicioDocenteService;
        }


        /**/
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("InicioAdmin", "Home");
                }
                else
                {
                    return RedirectToAction("InicioDocente", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
                
        }


        /*
         * ADMIN 
         */
        [Authorize(Roles = "Admin")]
        public IActionResult InicioAdmin()
        {
            return View();
        }
        
        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult ContarEstudiantesActivos()
        {
            int cantidad = _inicioAdminService.ContarEstudiantesActivos();
            return Json(cantidad);
        }
        
        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult ContarDocentesActivos()
        {
            int cantidad = _inicioAdminService.ContarDocentesActivos();
            return Json(cantidad);
        }
        
        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult ContarCursosActivos()
        {
            int cantidad = _inicioAdminService.ContarCursosActivos();
            return Json(cantidad);
        }
        
        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult ContarTraduccionesPendientes()
        {
            int cantidad = _inicioAdminService.ContarTraduccionesPendientes();
            return Json(cantidad);
        }
        
        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult BuscarCumpleañosCercanos()
        {
            List<Docente> docentes = _inicioAdminService.BuscarCumpleañosCercanos();
            return Json(docentes);
        }
        

        /*Horarios del dia*/
        [Authorize(Roles = "Admin")]
        public IActionResult BuscarHorariosDelDia()
        {
            List<Sesion> sesiones = _inicioAdminService.BuscarHorariosDelDia();
            return Json(sesiones);
        }


        /*
         * DOCENTE 
         */
        [Authorize(Roles = "Docente")]
        public IActionResult InicioDocente()
        {
            return View();
        }
    }
}
