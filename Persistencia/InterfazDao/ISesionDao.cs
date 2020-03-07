using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ISesionDao
    {
        List<Sesion> ListarSesionesCurso(int idCurso);
        List<Sesion> BuscarHorariosDelDia();
        List<Sesion> BuscarHorariosDelDiaDocente(int idDocente);
        List<Sesion> BuscarSesionesCurso(int idCurso);
        bool CrearSesion(Sesion sesion);

        //bool EditarSesionesCurso(List<Sesion> sesiones);
        bool EditarSesion(Sesion sesion);

        Sesion BuscarSesion(int idHorario);
        Sesion BuscarSesionPorID(int idSesion);
        Sesion BuscarSesionPorFechaYCurso(int idCurso, DateTime fecha);
        List<Sesion> BuscarSesionesDelDocentePorMes(int mes, int año, int idDocente);





    }
}
