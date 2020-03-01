using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IHorarioService
    {        

        String CrearHorarios(List<Horario> listaHorarios);

        List<Horario> BuscarHorariosCurso(int idCurso);

        String DeshabilitarHorariosCurso(int idCurso);

        int ObtenerIdUltimoHorario();

        void EliminarHorariosCurso(int idCurso);

        void EliminarSesionesHorarioCurso(List<Sesion> listaSesionesActuales);

        bool EditarHorariosCurso(List<Horario> listaHorarios, List<Sesion> listaSesionesActuales, int idCurso);

        String EsHorarioPermitido(Horario horarioEvaluar);

        String EsSesionPermitida(Sesion sesionEvaluar);
    }
}
