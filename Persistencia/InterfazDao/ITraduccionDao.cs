using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ITraduccionDao
    {
        List<Traduccion> ListarTraducciones();

        Traduccion BuscarTraduccion(int idTraduccion);

        bool CrearTraduccion(Traduccion traduccion);

        bool EditarTraduccion(Traduccion traduccion);

        bool EliminarTraduccion(int idTraduccion);

        int CantidadDeTraduccionesPendientes();

    }
}
