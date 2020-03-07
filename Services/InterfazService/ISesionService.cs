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
        bool CrearSesion(Sesion sesion);

        //bool EditarSesionesCurso(List<Sesion> sesiones);

        Sesion BuscarSesion(int idHorario);
    }
}
