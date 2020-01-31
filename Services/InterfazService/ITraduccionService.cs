using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface ITraduccionService
    {
        List<Traduccion> ListarTraducciones();

        Traduccion BuscarTraduccion(int idTraduccion);

        bool CrearTraduccion(Traduccion traduccion);

        bool EditarTraduccion(Traduccion traduccion);

        bool EliminarTraduccion(int idTraduccion);
    }
}
