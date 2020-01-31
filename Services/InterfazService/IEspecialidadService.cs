using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IEspecialidadService
    {
        List<Especialidad> ListaDeEspecialidades();
        Especialidad BuscarEspecialidadPorID(int id);
        bool RegistrarEspecialidad(Especialidad especialidad);
        bool EliminarEspecialidad(int id);
    }
}
