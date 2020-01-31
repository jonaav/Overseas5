using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ITipoCursoDao
    {

        List<TipoCurso> ListarTiposCurso();
        List<TipoEvaluacion> BuscarEvaluacionesDeUnTipoCurso(int idTipoCurso);
        TipoCurso BuscarTipoCursoPorID(int idTipoCurso);
        bool RegistrarTipoCurso(TipoCurso tipoCurso);
        bool EditarTipoCurso(TipoCurso tipoCurso);
        bool EliminarTipoCurso(int idTipoCurso);
    }
}
