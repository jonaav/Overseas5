using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IHorarioDao
    {        

        bool CrearHorarios(List<Horario> listaHorarios);

        bool CrearHorario(Horario horario);

        bool DeshabilitarHorariosCurso(int idCurso);

        List<Horario> BuscarHorariosCurso(int idCurso);

        Horario BuscarHorario(int idHorario);

        int ObtenerIdUltimoHorario();

        void EliminarHorariosCurso(List<Horario> listaHorarios);

        void EliminarSesionesHorarioCurso(List<Sesion> listaSesionesActuales);

        bool EsHorarioPermitido(Horario horarioEvaluar);

        bool EsSesionPermitida(Sesion sesionEvaluar);
    }
}
