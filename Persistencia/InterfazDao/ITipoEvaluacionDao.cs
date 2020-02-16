using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ITipoEvaluacionDao
    {
        List<TipoEvaluacion> ListarTiposEvaluacion();
        bool RegistrarTipoEvaluacion(TipoEvaluacion tEvaluacion);
        bool EliminarTipoEvaluacion(int idTipoEvaluacion);
    }
}
