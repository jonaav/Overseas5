using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IApoderadoDao
    {
        bool RegistrarApoderado(Apoderado apoderado);
        int BuscarIDApoderado(Apoderado ap);
        Apoderado BuscarApoderadoPorID(int idApoderado);
        bool EditarApoderado(Apoderado apoderado);
        bool EliminarApoderado(Apoderado apoderado);
    }
}
