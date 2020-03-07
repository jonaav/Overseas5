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
        Docente BuscarDocentePorCorreo(string correo);
        List<Especialidad> BuscarEspecialidadesDelDocente(int id);
        String RegistrarDocente(Docente docente, List<Especialidad> especialidades);
        String EditarDocente(Docente docente, List<Especialidad> especialidades);
        double ContarHorasAcumuladasDelMes(int mes, int año, int idDocente);
    }
}
