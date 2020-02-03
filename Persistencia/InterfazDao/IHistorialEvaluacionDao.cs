using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IHistorialEvaluacionDao
    {
        HistorialEvaluacion BuscarHistorialPorEstudianteYCurso(int idEstudiante, int idCurso);
        HistorialEvaluacion RegistrarHistorialEvaluacion(HistorialEvaluacion historial);
        bool EditarHistorialEvaluacion(HistorialEvaluacion historial);
        bool EliminarHistorialEvaluacion(int idHistorial);
    }
}
