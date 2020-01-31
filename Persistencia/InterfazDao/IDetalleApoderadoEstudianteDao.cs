using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IDetalleApoderadoEstudianteDao
    {
        bool RegistrarDetalle(DetalleApoderadoEstudiante detalle);
        DetalleApoderadoEstudiante BuscarApoderadoDeUnEstudiante(int id);
        DetalleApoderadoEstudiante BuscarDetalle(int idEstudiante);
        bool EliminarDetalle(DetalleApoderadoEstudiante detalle);
    }
}
