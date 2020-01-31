using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IEspecialidadDao
    {
        List<Especialidad> ListaDeEspecialidades();
        Especialidad BuscarEspecialidadPorID(int id);
        bool RegistrarEspecialidad(Especialidad especialidad);
        bool EliminarEspecialidad(Especialidad especialidad);
    }
}
