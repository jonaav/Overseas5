using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IInscripcionDao
    {
        List<Inscripcion> ListarInscripciones(int idCurso);
        bool RegistrarInscripcion(Inscripcion inscripcion);
        bool BuscarInscripcion(Inscripcion inscripcion);
        Inscripcion BuscarInscripcionID(int id);
        bool AnularInscripcion(Inscripcion inscripcion);
        int CantidadDeEstudiantesActivos();
    }
}
