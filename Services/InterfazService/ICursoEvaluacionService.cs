using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ICursoEvaluacionService
    {
        List<TipoCurso> ListarTiposCurso();
        List<TipoEvaluacion> ListarTiposEvaluacion();
        List<TipoCursoTipoEvaluacion> ListarTCursoTEvaluacion(int idCurso);
        List<TipoEvaluacion> ListarTEvaluacionFaltantes(int idCurso);
        String RegistrarTipoEvaluacion(TipoEvaluacion tEvaluacion);
        String EliminarTipoEvaluacion(int idTipoEvaluacion);
        String RegistrarTCursoTEvaluacion(TipoCursoTipoEvaluacion tt);
        String EliminarTCursoTEvaluacion(int idtt);
    }
}
