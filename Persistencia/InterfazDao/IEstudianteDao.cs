using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IEstudianteDao
    {
        List<Estudiante> ListarEstudiantes();
        Estudiante BuscarEstudianteDNI(string dni);
        Estudiante BuscarEstudianteID(int id);
        Estudiante BuscarEstudianteCorreo(string correo);
        bool RegistrarEstudiante(Estudiante estudiante);
        bool EditarEstudiante(Estudiante estudiante);



    }
}
