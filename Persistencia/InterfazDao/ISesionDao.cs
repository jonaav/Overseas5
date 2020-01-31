using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ISesionDao
    {
        List<Sesion> ListarSesionesCurso(int idCurso);

        List<Sesion> BuscarSesionesCurso(int idCurso);
        bool CrearSesion(Sesion sesion);

        bool EditarSesionesCurso(List<Sesion> sesiones);

        Sesion BuscarSesion(int idHorario);
        


        
    }
}
