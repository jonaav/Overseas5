using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IAsistenciaDao
    {
        List<Asistencia> ListarAsistenciasPorSesionCurso(int idCurso, DateTime fechaActual);
        List<Asistencia> ListarAsistenciasPorSesion(int idSesion);
        void RegistrarAsistencia(Asistencia asistencia);
        bool EditarAsistencia(Asistencia asistencia);
        Asistencia BuscarAsistenciaPorID(int idAsistencia);
    }
}
