using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ITCursoTEvaluacionDao
    {
        bool RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion cursoEvaluacion);
        bool EliminarTCursoTEvaluacion(int idtcurso, int idtEvaluacion);
    }
}
