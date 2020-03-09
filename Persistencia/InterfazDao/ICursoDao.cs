using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface ICursoDao
    {
        List<Curso> ListarCursos(string nombreCurso, string programa, int estado);
        List<Curso> ListarCursosHabiles();
        List<Curso> ListarCursosHabilesDelDocente(string correo);
        List<Curso> BuscarCursosActivosPorTipo(int idTCurso);
        Curso BuscarCursoPorID(int idCurso);
        bool RegistrarCurso(Curso curso);
        bool EditarCurso(Curso curso);
        bool ModificarEstadoCurso(int idCurso, int estado);

        int CantidadDeCursosActivos();



    }
}
