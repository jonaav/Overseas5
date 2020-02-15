using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ICalificacionesService
    {
        void RegistrarHistorialEvaluacion(HistorialEvaluacion historial);
        String EditarEvaluacion(Evaluacion evaluacion);
        String EliminarCalificaciones(int idHistorial);
        List<Evaluacion> VerNotasDelEstudiantePorCurso(int idCurso, int idEstudiante);
    }
}
