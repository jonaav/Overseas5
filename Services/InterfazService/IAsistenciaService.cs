using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IAsistenciaService
    {
        List<Asistencia> ListarAsistenciasPorSesion(int idCurso);
        String EditarAsistencias(List<int> asistieron);
    }
}
