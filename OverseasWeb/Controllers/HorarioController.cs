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
    public class HorarioController : Controller
    {
        private readonly IHorarioService _horarioService;
        private readonly ISesionService _sesionService;

        public HorarioController(
            IHorarioService horarioService, 
            ISesionService sesionService
        ){
            _horarioService = horarioService;
            _sesionService = sesionService;
        }


        public IActionResult BuscarHorariosCurso(int idCurso)
        {
            List<Horario> horarios = _horarioService.BuscarHorariosCurso(idCurso);
            return Json(horarios);
        }

        public IActionResult BuscarHorario(int idHorario)
        {
            Horario horario = _horarioService.BuscarHorario(idHorario);
            return Json(horario);
        }

        [HttpPost]
        public IActionResult CrearHorario(Horario horario)
        {
            var mensaje = _horarioService.CrearHorario(horario);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult EditarHorario(Horario horario)
        {
            var mensaje = _horarioService.EditarHorario(horario);
            return Json(mensaje);
        }
        

        [HttpPost]
        public IActionResult AnularHorario(int idHorario)
        {
            var mensaje = _horarioService.AnularHorario(idHorario);
            return Json(mensaje);
        }



        public IActionResult VerificarHorario(Horario horario)
        {
            var mensaje = _horarioService.EsHorarioPermitido(horario);
            return Json(mensaje);
        }





    }
}