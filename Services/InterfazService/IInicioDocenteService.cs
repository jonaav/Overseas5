using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IInicioDocenteService
    {
        List<Sesion> BuscarHorariosDelDiaDocente(string username);
        //double ContarHorasAcumuladasDelMes(string username);
    }
}
