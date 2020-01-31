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
        String RegistrarTipoEvaluacion(TipoEvaluacion tEvaluacion);
    }
}
