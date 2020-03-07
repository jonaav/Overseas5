using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades;
using Services.InterfazService;
using Microsoft.AspNetCore.Authorization;

namespace OverseasWeb.Controllers
{
    public class DocenteController : Controller
    {
        private readonly IDocenteService _docenteService;
        private readonly IUsuarioService _usuarioService;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public DocenteController(
            IDocenteService docenteService,
            IUsuarioService usuarioService,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager
        )
        {
            _docenteService = docenteService;
            _usuarioService = usuarioService;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        #region IActionResult

        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult ListarDocentes()
        {
            List<Docente> docentes = _docenteService.ListarDocentes();
            return View(docentes);
        }

        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult BuscarDocente(int id)
        {
            Docente docente = _docenteService.BuscarDocenteID(id);
            return Json(docente);
        }

        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult BuscarEspecialidadesDelDocente(int id)
        {
            List<Especialidad> especialidades = _docenteService.BuscarEspecialidadesDelDocente(id);
            return Json(especialidades);
        }

        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult RegistrarDocente()
        {
            return View();
        }

        /**/
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegistrarDocente(Docente docente, List<Especialidad> especialidades)
        {
            var mensaje = _docenteService.RegistrarDocente(docente, especialidades);
            if(mensaje == "Registro Completado")
            {
                var user = new AppUser
                {
                    UserName = docente.Persona.CorreoPersona,
                    Email = docente.Persona.CorreoPersona,
                    StatusUser = 1,
                    IdPersona = docente.IdPersona,
                };
                var password = docente.Persona.GenerarContraseñaDefault();
                var result =await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    //var role = new AppRole
                    //{
                    //    Name = "Admin"
                    //};
                    //var createrol = await _roleManager.CreateAsync(role);
                    var res = await _userManager.AddToRoleAsync(user, "Docente");
                    //if (res.Succeeded)
                    //{
                    //    var xx = await _userManager.FindByNameAsync(user.UserName);
                    //}
                }
            }
            return Json(mensaje);
        }

        /**/
        [Authorize(Roles = "Admin")]
        public IActionResult EditarDocente(int id)
        {
            Docente docente = _docenteService.BuscarDocenteID(id);
            return View(docente);
        }

        /**/
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditarDocente(Docente docente, List<Especialidad> especialidades)
        {
            var mensaje = _docenteService.EditarDocente(docente, especialidades);
            return Json(mensaje);
        }



        [Authorize(Roles = "Admin")]
        public IActionResult HorasAcumuladasDelMesDocente(int mes,int año, int idDocente)
        {
            double totalHoras = _docenteService.ContarHorasAcumuladasDelMes(mes, año, idDocente);
            return Json(totalHoras);
        }





        #endregion IActionResult
    }
}
