using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ICursoDao
    {
        List<Curso> ListarCursos(string nombreCurso, string programa);
        List<Curso> ListarCursosHabiles();
        Curso BuscarCursoPorID(int idCurso);
        bool RegistrarCurso(Curso curso);
        bool EditarCurso(Curso curso);
        bool EliminarCurso(int idCurso);

        int CantidadDeCursosActivos();



    }
}
