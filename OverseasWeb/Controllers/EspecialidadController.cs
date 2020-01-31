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
    [Authorize(Roles = "Admin")]
    public class EspecialidadController : Controller
    {

        private readonly IEspecialidadService _especialidadService;
        public EspecialidadController(
            IEspecialidadService especialidadService
        ){
            _especialidadService = especialidadService;
        }


        /**/
        public ActionResult ListarEspecialidades()
        {
            return View();
        }

        /**/
        public ActionResult ListarEspecialidad()
        {            
            List<Especialidad> especialidades = _especialidadService.ListaDeEspecialidades();
            if (especialidades != null)
                return Json(especialidades);
            else
                return Json("");
        }

        /*Se usa para la funcionalidad del docente*/
        public ActionResult BuscarEspecialidadPorID(int id)
        {
            Especialidad especialidad = _especialidadService.BuscarEspecialidadPorID(id);
            return Json(especialidad);
        }



        /**/
        [HttpPost]
        public ActionResult RegistrarEspecialidad(Especialidad especialidad)
        {
            bool registroCompletado = _especialidadService.RegistrarEspecialidad(especialidad);
            if (registroCompletado)
                return Json("Exito");
            else
                return Json("Error");
        }

        /**/
        [HttpPost]
        public ActionResult EliminarEspecialidad(int id)
        {
            bool eliminado = _especialidadService.EliminarEspecialidad(id);
            if (eliminado)
                return Json("Exito");
            else
                return Json("Error");
        }

    }
}