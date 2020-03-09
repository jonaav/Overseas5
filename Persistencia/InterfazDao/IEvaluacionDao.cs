using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IEvaluacionDao
    {
        bool RegistrarEvaluacion(Evaluacion evaluacion);
        bool EditarEvaluacion(Evaluacion evaluacion);
        bool EliminarEvaluacion(int idEvaluacion);
        Evaluacion BuscarEvaluacion(int idEvaluacion);
        Evaluacion BuscarEvaluacionPorHistorialTipo(int idHistorial, int tipoEvaluacion);
        List<Evaluacion> ListarEvaluacionesPorEstudianteYCurso(int idEstudiante, int idCurso);
    }
}
