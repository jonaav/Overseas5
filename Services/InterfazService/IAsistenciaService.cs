using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IAsistenciaService
    {
        List<Asistencia> ListarAsistenciasPorSesionCurso(int idCurso);
        List<Asistencia> ListarAsistenciasPorSesion(int idSesion);
        String EditarAsistencias(List<int> asistieron);
    }
}
