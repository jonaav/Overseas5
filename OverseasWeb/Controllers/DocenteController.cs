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
        public IActionResult ListarDocentes()
        {
            List<Docente> docentes = _docenteService.ListarDocentes();
            return View(docentes);
        }


        /**/
        public IActionResult ListarDocentesParaCurso()
        {
            List<Docente> docentes = _docenteService.ListarDocentes();            
            return Json(docentes);
        }

        /**/
        public IActionResult BuscarDocente(int id)
        {
            Docente docente = _docenteService.BuscarDocenteID(id);
            return Json(docente);
        }

        /**/
        public IActionResult BuscarEspecialidadesDelDocente(int id)
        {
            List<Especialidad> especialidades = _docenteService.BuscarEspecialidadesDelDocente(id);
            return Json(especialidades);
        }

        /**/
        public IActionResult RegistrarDocente()
        {
            return View();
        }

        /**/
        [HttpPost]
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
        public IActionResult EditarDocente(int id)
        {
            Docente docente = _docenteService.BuscarDocenteID(id);
            return View(docente);
        }

        /**/
        [HttpPost]
        public IActionResult EditarDocente(Docente docente, List<Especialidad> especialidades)
        {
            var mensaje = _docenteService.EditarDocente(docente, especialidades);
            return Json(mensaje);
        }
        #endregion IActionResult
    }
}
