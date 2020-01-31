using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;
using Services.InterfazService;
using OverseasWeb.Models;

namespace OverseasWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private UserManager<AppUser> _userManager;

        public UsuarioController(
            IUsuarioService usuarioService,
            UserManager<AppUser> userManager
        )
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
        }


        #region IActionResult
        // GET: Docente
        [Authorize(Roles = "Admin")]
        public IActionResult ListarUsuarios()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListaDeUsuarios()
        {
            List<AppUser> usuarios = _usuarioService.ListarUsuarios();
            //Asignar rol a cada usuario
            List<ViewModelUsuario> dataUsuarios = new List<ViewModelUsuario>();
            foreach(AppUser user in usuarios)
            {
                AppRole rol = _usuarioService.BuscarUserRole(user.Id);
                ViewModelUsuario dataUser = new ViewModelUsuario
                {
                    Id = user.Id,
                    Nombres = user.Persona.NombresPersona,
                    Apellidos = user.Persona.ApellidosPersona,
                    Rol = rol.NormalizedName,
                    Username = user.UserName,
                    StatusUser = user.StatusUser
                };
                dataUsuarios.Add(dataUser);
            }
            return Json(dataUsuarios);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult BuscarUserRole(int id)
        {
            AppRole rol = _usuarioService.BuscarUserRole(id);
            return Json(rol);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HabilitarUsuario(int idUsuario)
        {
            bool habilitado = _usuarioService.HabilitarUsuario(idUsuario);
            if (habilitado)
            {
                //Desbloquear a partir de la fecha actual
                DateTimeOffset fecha = DateTime.Now;
                var user = await _userManager.FindByIdAsync(idUsuario.ToString());
                await _userManager.SetLockoutEndDateAsync(user, fecha);

                return Json("Exito");
            }
            else
                return Json("Error");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeshabilitarUsuario(int idUsuario)
        {
            bool eliminado = _usuarioService.DeshabilitarUsuario(idUsuario);
            if (eliminado)
            {
                //Bloquear hasta fecha limite
                DateTimeOffset fecha = Convert.ToDateTime("01/01/3000");
                var user = await _userManager.FindByIdAsync(idUsuario.ToString());
                await _userManager.SetLockoutEndDateAsync(user, fecha);

                return Json("Exito");
            }
            else
                return Json("Error");
        }




        /* __ PERFIL DE USUARIO __*/

        [Authorize]
        public async Task<IActionResult> CambiarPassword()
        {
            var userInfo = HttpContext.User.Identity;
            var user = await _userManager.FindByNameAsync(userInfo.Name);

            ViewModelUsuario usuario = new ViewModelUsuario { Username = user.Email };
            if (await _userManager.IsInRoleAsync(user, "Admin"))
                ViewBag.urlLayout = "~/Views/Shared/_LayoutAdmin.cshtml";
            else
                ViewBag.urlLayout = "~/Views/Shared/_LayoutDocente.cshtml";

            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CambiarPassword(ViewModelUsuario model)
        {
            var userInfo = HttpContext.User.Identity;
            var user = await _userManager.FindByNameAsync(userInfo.Name);
            if (ModelState.IsValid)
            {
                model.Username = user.Email;
                var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Los datos no son validos");
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
                ViewBag.urlLayout = "~/Views/Shared/_LayoutAdmin.cshtml";
            else
                ViewBag.urlLayout = "~/Views/Shared/_LayoutDocente.cshtml";
            return View(model);
        }

        [Authorize]
        public IActionResult MostrarUsername()
        {
            var userInfo = HttpContext.User.Identity;
            return Json(userInfo.Name);
        }










        #endregion IActionResult
    }
}
