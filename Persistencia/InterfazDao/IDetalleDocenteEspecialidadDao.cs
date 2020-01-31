using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IDetalleDocenteEspecialidadDao
    {
        bool registrarDetalleDocenteEspecialidad(DetalleDocenteEspecialidad detalle);
        bool EliminarDetalleDocenteEspecialidad(DetalleDocenteEspecialidad detalle);
        List<DetalleDocenteEspecialidad> BuscarDetallesPorEspecialidad(int idEspecialidad);
    }
}
