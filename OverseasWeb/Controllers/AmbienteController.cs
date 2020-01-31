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
    public class AmbienteController : Controller
    {
        private readonly IAmbienteService _ambienteService;

        public AmbienteController(IAmbienteService ambienteService)
        {
            _ambienteService = ambienteService;
        }
        public IActionResult ListarAmbientes()
        {
            return View();
        }
        public IActionResult Listar()
        {
            return Json(_ambienteService.ListarAmbientes());
        }

        // POST: Ambiente/Create
        [HttpPost]        
        public IActionResult Registrar(Ambiente ambiente)
        {
            if (_ambienteService.CrearAmbiente(ambiente))
                return Json("Registrado");
            else
                return Json("");
        }


        [HttpPost]
        public IActionResult Eliminar(int idAmbiente)
        {
            if (_ambienteService.EliminarAmbiente(idAmbiente))
                return Json("Eliminado");
            else
                return Json("");
        }

       

       
    }
}