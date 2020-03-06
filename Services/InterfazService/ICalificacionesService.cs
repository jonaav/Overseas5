using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ICalificacionesService
    {
        void RegistrarHistorialEvaluacion(HistorialEvaluacion historial);
        String EditarEvaluacion(int idEvaluacion, int nota );
        Evaluacion BuscarEvaluacion(int idEvaluacion);
        String EditarHistorial( HistorialEvaluacion historial);
        List<Evaluacion> VerNotasDelEstudiantePorCurso(int idCurso, int idEstudiante);
        HistorialEvaluacion BuscarHistorial(int idCurso, int idEstudiante);

        //String EliminarCalificaciones(int idHistorial);
    }
}
