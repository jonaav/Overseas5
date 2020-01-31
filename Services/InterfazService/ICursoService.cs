using System;
using System.Collections.Generic;
using System.Text;
using Entidades;


namespace Services.InterfazService
{
    public interface ICursoService
    {
        List<Curso> ListarCursos(string nombreCurso, string programa);
        List<Curso> ListarCursosHabiles();
        Curso BuscarCursoPorID(int idCurso);
        String RegistrarCurso(Curso curso);
        String EditarCurso(Curso curso);
        String EliminarCurso(int idCurso);

    }
}
