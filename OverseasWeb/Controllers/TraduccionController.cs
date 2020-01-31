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

        public IActionResult Listar()
        {
            return Json(_traduccionService.ListarTraducciones());
        }

        public IActionResult BuscarTraduccion(int idTraduccion)
        {            
            return Json(_traduccionService.BuscarTraduccion(idTraduccion));
        }
        
        [HttpPost]
        public IActionResult RegistrarTraduccion(Traduccion traduccion)
        {            
            bool registrado = _traduccionService.CrearTraduccion(traduccion);
            if (registrado)
                return Json("Correcto");
            else
                return Json("Incorrecto");
        }



        [HttpPost]
        public IActionResult EditarTraduccion(Traduccion traduccion)
        {
            bool editado = _traduccionService.EditarTraduccion(traduccion);
            if (editado)
                return Json("Correcto");
            else
                return Json("Incorrecto");
        }

        [HttpPost]
        public IActionResult EliminarTraduccion(int idTraduccion)
        {
            if(_traduccionService.EliminarTraduccion(idTraduccion))
                return Json("Eliminado");
            else
                return Json("");
        }

    }
}