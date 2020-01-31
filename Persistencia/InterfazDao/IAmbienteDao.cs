using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IAmbienteDao
    {
        List<Ambiente> ListarAmbientes();
        bool CrearAmbiente(Ambiente ambiente);

        Ambiente BuscarAmbiente(int idAmbiente);        
        bool EliminarAmbiente(int idAmbiente);
    }
}
