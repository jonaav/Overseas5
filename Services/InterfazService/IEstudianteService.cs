using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IEstudianteService
    {
        List<Estudiante> ListarEstudiantes();
        Estudiante BuscarEstudianteDNI(string dni);
        Estudiante BuscarEstudianteID(int id);
        Apoderado BuscarApoderadoDeUnEstudiante(int id);
        String RegistrarEstudiante(Estudiante estudiante);
        String EditarEstudiante(Estudiante estudiante);
        int CalcularTotalDeEstudiantes();
         
    }
}
