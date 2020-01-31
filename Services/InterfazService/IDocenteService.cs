using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IDocenteService
    {
        List<Docente> ListarDocentes();
        Docente BuscarDocenteID(int id);
        Docente BuscarDocenteDNI(string dni);
        List<Especialidad> BuscarEspecialidadesDelDocente(int id);
        String RegistrarDocente(Docente docente, List<Especialidad> especialidades);
        String EditarDocente(Docente docente, List<Especialidad> especialidades);
    }
}
