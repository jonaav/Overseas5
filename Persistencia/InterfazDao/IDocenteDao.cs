﻿using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IDocenteDao
    {

        List<Docente> ListarDocentes();
        List<Docente> ListarDocentesHabilitados();
        Docente BuscarDocenteDNI(string dni);
        Docente BuscarDocenteID(int id);
        Docente BuscarDocenteCorreo(string correo);
        List<Especialidad> BuscarEspecialidadesDelDocente(int id);
        bool RegistrarDocente(Docente docente);
        bool EditarDocente(Docente docente);
        bool EliminarEspecialidadesDelDocente(int id);

        int CantidadDeDocentesActivos();
        List<Docente> BuscarCumpleañosCercanos(DateTime inicio, DateTime fin);
    }
}
