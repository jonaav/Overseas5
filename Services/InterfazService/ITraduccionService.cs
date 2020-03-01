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

        String CrearTraduccion(Traduccion traduccion);

        String EditarTraduccion(Traduccion traduccion);

        String ModificarEstadoTraduccion(int idTraduccion, int estado);
    }
}
