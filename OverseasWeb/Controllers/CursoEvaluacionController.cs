using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;


namespace OverseasWeb.Controllers
{
    public class CursoEvaluacionController : Controller
    {
        private readonly ICursoEvaluacionService _cursoEvaluacionService;

        public CursoEvaluacionController(ICursoEvaluacionService cursoEvaluacionService)
        {
            _cursoEvaluacionService = cursoEvaluacionService;
        }




        public IActionResult CursoEvaluacion()
        {
            return View();
        }


        public IActionResult ListarTiposCurso()
        {
            List <TipoCurso> tiposCurso= _cursoEvaluacionService.ListarTiposCurso();
            return Json(tiposCurso);
        }


        public IActionResult ListarTiposEvaluacion()
        {
            List <TipoEvaluacion> tiposEvaluacion= _cursoEvaluacionService.ListarTiposEvaluacion();
            return Json(tiposEvaluacion);
        }

        [HttpPost]
        public IActionResult RegistrarTipoEvaluacion(TipoEvaluacion tEvaluacion)
        {
            var mensaje = _cursoEvaluacionService.RegistrarTipoEvaluacion(tEvaluacion);
            return Json(mensaje);
        }


    }
}