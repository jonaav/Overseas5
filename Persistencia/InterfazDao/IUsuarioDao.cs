using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Persistencia.InterfazDao
{
    public interface IUsuarioDao
    {

        List<AppUser> ListarUsuarios();
        AppUser BuscarUsuarioID(int id);
        AppUser BuscarUsuarioCorreo(string correo);
        bool EditarUsuario(AppUser usuario);
        AppRole BuscarUserRole(int idUser);
        AppUser BuscarUsuarioPorPersona(int idPersona);
    }
}
