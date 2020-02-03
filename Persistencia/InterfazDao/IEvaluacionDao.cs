using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IEvaluacionDao
    {
        void RegistrarEvaluacion(Evaluacion evaluacion);
        bool EditarEvaluacion(Evaluacion evaluacion);
        bool EliminarEvaluacion(int idEvaluacion);
    }
}
