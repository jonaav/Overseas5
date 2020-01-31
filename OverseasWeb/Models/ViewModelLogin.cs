using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverseasWeb.Models
{
    public class ViewModelLogin
    {
        [EmailAddress]
        [Required(ErrorMessage ="Ingrese el correo de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña")]
        public string Password { get; set; }
    }
}
