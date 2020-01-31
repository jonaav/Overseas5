using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public partial class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string DniPersona { get; set; }
        public string NombresPersona { get; set; }
        public string ApellidosPersona { get; set; }
        public string CorreoPersona { get; set; }
        public DateTime FechaNacimientoPersona { get; set; }
        public string TelefonoPersona { get; set; }
        public string DireccionPersona { get; set; }

        //public ICollection<Docente> Docente { get; set; }
        //public ICollection<Estudiante> Estudiante { get; set; }
        //public ICollection<AppUser> Usuario { get; set; }


        public String GenerarContraseñaDefault()
        {
            String password  = ApellidosPersona.Substring(0, 1).ToUpper() +
                        NombresPersona.Substring(0, 1).ToLower() +
                        DniPersona.Substring(0, 4) + "!!";

            return password;
        }
    }
}
