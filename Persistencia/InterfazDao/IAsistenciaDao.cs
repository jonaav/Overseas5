using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IAsistenciaDao
    {
        List<Asistencia> ListarAsistenciasPorSesion(int idCurso, DateTime fechaActual);
    }
}
