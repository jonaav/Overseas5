using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Entidades;
using Services.InterfazService;
using OverseasWeb.Models;


namespace OverseasWeb.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IUsuarioService _usuarioService;

        public LoginController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUsuarioService usuarioService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioService = usuarioService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(ViewModelLogin model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password,false,false);
                
                if (result.Succeeded)
                {
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "El nombre de usuario o la cotraseña no son validos");
            }
            return View();
        }
        

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }








    }
}