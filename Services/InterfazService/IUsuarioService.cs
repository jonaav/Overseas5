using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Services.InterfazService
{
    public interface IUsuarioService
    {
        List<AppUser> ListarUsuarios();
        bool RegistrarUsuarioDocente(Docente docente);
        bool EditarUsuario(AppUser usuario);
        bool HabilitarUsuario(int id);
        bool DeshabilitarUsuario(int id);
        AppRole BuscarUserRole(int id);
    }
}
