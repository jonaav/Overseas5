using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IInscripcionService
    {
        List<Inscripcion> ListarInscripciones(int idCurso);
        List<Estudiante> BuscarEstudiantesNoInscritos(int idCurso);
        bool RegistrarInscripcion(int idCurso, int idEstudiante);
        bool AnularInscripcion(int id);
    }
}
