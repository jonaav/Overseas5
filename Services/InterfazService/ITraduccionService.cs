using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ITraduccionService
    {
        List<Traduccion> ListarTraducciones( int estado);

        Traduccion BuscarTraduccion(int idTraduccion);

        bool CrearTraduccion(Traduccion traduccion);

        bool EditarTraduccion(Traduccion traduccion);

        bool ModificarEstadoTraduccion(int idTraduccion, int estado);
    }
}
