using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IInicioAdminService
    {
        int ContarEstudiantesActivos();
        int ContarDocentesActivos();
        int ContarCursosActivos();
        int ContarTraduccionesPendientes();
        List<Persona> BuscarCumpleañosCercanos();
    }
}
