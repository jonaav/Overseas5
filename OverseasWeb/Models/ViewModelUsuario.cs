using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverseasWeb.Models
{
    public class ViewModelUsuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "La contraseña debe tener 8 caracteres como minimo")]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden")]
        public string NewPasswordConfirm { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Rol { get; set; }
        public int StatusUser { get; set; }

    }
}
