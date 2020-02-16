using System;
using System.Collections.Generic;
using System.Text;
using Entidades;


namespace Services.InterfazService
{
    public interface ICursoService
    {
        List<Curso> ListarCursos(string nombreCurso, string programa, int estado);
        List<Curso> ListarCursosHabiles();
        Docente BuscarDocentePorID(int idDocente);
        Curso BuscarCursoPorID(int idCurso);
        TipoCurso BuscarTipoCursoPorNombre(string nombreCurso);
        List<Docente> ListarDocentes();
        String RegistrarCurso(Curso curso);
        String EditarCurso(Curso curso);
        String EliminarCurso(int idCurso);

    }
}
