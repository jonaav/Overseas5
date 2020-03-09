using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ITCursoTEvaluacionDao
    {
        List<TipoCursoTipoEvaluacion> ListarTCursoTEvaluacion(int idCurso);
        List<TipoCursoTipoEvaluacion> ListarTCursoTEvaluacionPorTEvaluacion(int idTEvaluacion);
        bool RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion cursoEvaluacion);
        bool EliminarTCursoTEvaluacion(int idtt);
        TipoCursoTipoEvaluacion BuscarTipoCursoTipoEvaluacion(int idtt);
    }
}
