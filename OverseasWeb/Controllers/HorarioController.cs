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

        public HorarioController(IHorarioService horarioService, ISesionService sesionService)
        {
            _horarioService = horarioService;
            _sesionService = sesionService;
        }


        public IActionResult BuscarHorariosCurso(int idCurso)
        {
            List<Horario> listaHorarios;
            listaHorarios = _horarioService.BuscarHorariosCurso(idCurso);
            if (listaHorarios != null)
                return Json(listaHorarios);
            else
                return Json("");
        }

        public IActionResult BuscarSesionesCurso(int idCurso)
        {
            List<Sesion> listaSesiones;
            listaSesiones = _sesionService.ListarSesionesCurso(idCurso);
            if (listaSesiones != null)
                return Json(listaSesiones);
            else
                return Json("");
        }

        public IActionResult VerificarHorario(Horario horario)
        {
            var mensaje = _horarioService.EsHorarioPermitido(horario);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult VerificarSesion(Sesion sesion)
        {
            var mensaje = _horarioService.EsSesionPermitida(sesion);
            return Json(mensaje);
        }

        [HttpPost]
        public IActionResult CrearSesiones([FromBody] List<Sesion> listaDeSesiones)
        {
            var mensaje = _sesionService.CrearSesiones(listaDeSesiones);
            return Json(mensaje);            
        }


        [HttpPost]
        public IActionResult CrearSesionesCursoPrivado([FromBody] List<Sesion> listaDeSesiones)
        {
            var mensaje = _sesionService.CrearSesionesCursoPrivado(listaDeSesiones);
            return Json(mensaje);

        }

        [HttpPost]
        public IActionResult CrearHorarios([FromBody] List<Horario> listaDeHorarios)
        {
            var mensaje = _horarioService.CrearHorarios(listaDeHorarios);
            if (mensaje == "Correcto")
                return Json(listaDeHorarios);
            else
                return Json("");
        }
      

        [HttpPost]
        public IActionResult EliminarHorariosCurso(int idCurso)
        {            
            _horarioService.EliminarSesionesHorarioCurso(idCurso);
            _horarioService.EliminarHorariosCurso(idCurso);
            return Json("Eliminado");                     
        }

        [HttpPost]
        public IActionResult EliminarHorariosCursoPrivado(int idCurso)
        {
            _horarioService.EliminarSesionesHorarioCursoPrivado(idCurso);            
            return Json("Eliminado");
        }

        public IActionResult BuscarSesion(int idHorario)
        {
            Sesion sesion;
            sesion = _sesionService.BuscarSesion(idHorario);
            if (sesion != null)
                return Json(sesion);
            else
                return Json("");
        }

        [HttpPost]
        public IActionResult DeshabilitarHorariosCurso(int idCurso)
        {
            var mensaje = _horarioService.DeshabilitarHorariosCurso(idCurso);
            return Json(mensaje);
        }


    }
}