using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ICalificacionesService
    {
        bool RegistrarHistorialEvaluacion(HistorialEvaluacion historial);
        String RegistrarEvaluacion(Evaluacion evaluacion);
        String EditarEvaluacion(Evaluacion evaluacion);
        String EliminarCalificaciones(int idHistorial);
    }
}
