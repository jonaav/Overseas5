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
    public class TraduccionController : Controller
    {
        private readonly ITraduccionService _traduccionService;

        public TraduccionController(ITraduccionService traduccionService)
        {
            _traduccionService = traduccionService;
        }

        public IActionResult ListarTraducciones()
        {            
            return View();
        }

        public IActionResult Listar( int estado)
        {
            return Json(_traduccionService.ListarTraducciones(estado));
        }

        public IActionResult BuscarTraduccion(int idTraduccion)
        {            
            return Json(_traduccionService.BuscarTraduccion(idTraduccion));
        }
        
        [HttpPost]
        public IActionResult RegistrarTraduccion(Traduccion traduccion)
        {            
            var mensaje = _traduccionService.CrearTraduccion(traduccion);
            return Json(mensaje);                            
        }



        [HttpPost]
        public IActionResult EditarTraduccion(Traduccion traduccion)
        {
            var mensaje = _traduccionService.EditarTraduccion(traduccion);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult ModificarEstadoTraduccion(int idTraduccion, int estado)
        {
            var mensaje = _traduccionService.ModificarEstadoTraduccion(idTraduccion, estado);
            return Json(mensaje);
        }

    }
}