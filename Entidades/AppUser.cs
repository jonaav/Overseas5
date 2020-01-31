using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class AppUser : IdentityUser<int>
    {
        public int StatusUser { get; set; }
        [ForeignKey("IdPersona")]
        public int IdPersona { get; set; }

        public Persona Persona { get; set; }
    }
}
