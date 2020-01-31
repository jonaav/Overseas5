using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IApoderadoService
    {
        String RegistrarDetalleApoderadoEstudiante(Estudiante estudiante, Apoderado apoderado);
        String EditarApoderado(Apoderado apoderado);
        String EliminarApoderado(Estudiante estudiante);
    }
}
