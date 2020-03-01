using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IHorarioDao
    {        

        bool CrearHorarios(List<Horario> listaHorarios);

        bool DeshabilitarHorariosCurso(int idCurso);

        List<Horario> BuscarHorariosCurso(int idCurso);

        int ObtenerIdUltimoHorario();

        void EliminarHorariosCurso(int idCurso);

        void EliminarSesionesHorarioCurso(List<Sesion> listaSesionesActuales);

        bool EditarHorariosCurso(List<Horario> listaHorarios, List<Sesion> listaSesionesActuales, int idCurso);

        bool EsHorarioPermitido(Horario horarioEvaluar);

        bool EsSesionPermitida(Sesion sesionEvaluar);
    }
}
