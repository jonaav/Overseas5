using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ISesionService
    {
        List<Sesion> ListarSesionesCurso(int idCurso);
        List<Sesion> BuscarSesionesCurso(int idCurso);
        String CrearSesiones(List<Sesion> listaSesiones);

        String CrearSesionesCursoPrivado(List<Sesion> listaSesiones);

        //bool EditarSesionesCurso(List<Sesion> sesiones);

        Sesion BuscarSesion(int idHorario);
        Sesion BuscarSesionPorID(int idSesion);
    }
}
