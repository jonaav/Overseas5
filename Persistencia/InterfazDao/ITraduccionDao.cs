using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ITraduccionDao
    {
        List<Traduccion> ListarTraducciones(int estado);

        Traduccion BuscarTraduccion(int idTraduccion);

        bool CrearTraduccion(Traduccion traduccion);

        bool EditarTraduccion(Traduccion traduccion);

        bool ModificarEstadoTraduccion(int idTraduccion, int estado);

        int CantidadDeTraduccionesPendientes();

    }
}
