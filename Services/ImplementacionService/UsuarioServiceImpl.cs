using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly IUsuarioDao _usuarioDao;
        private readonly IDocenteDao _docenteDao;

        public UsuarioServiceImpl(
            IUsuarioDao usuarioDao,
            IDocenteDao docenteDao
        )
        { 
            _usuarioDao = usuarioDao;
            _docenteDao = docenteDao;
        }

        #region metodos
        //public List<AppUser> ListarUsuarios()
        //{
        //    List<AppUser> usuarios = _usuarioDao.ListarUsuarios();
        //    return usuarios;
        //}
        public List<AppUser> ListarUsuarios()
        {
            List<AppUser> usuarios = _usuarioDao.ListarUsuarios();
            return usuarios;
        }

        public AppRole BuscarUserRole(int id)
        {
            AppRole rol = _usuarioDao.BuscarUserRole(id);
            return rol;
        }

        /**/
        public bool RegistrarUsuarioDocente(Docente docente)
        {
            bool registro = false;
            return registro;
        }
        public bool EditarUsuario(AppUser usuario)
        {
            bool edicion = _usuarioDao.EditarUsuario(usuario);
            return edicion;
        }

        public bool HabilitarUsuario(int id)
        {
            AppUser usuario = _usuarioDao.BuscarUsuarioID(id);
            usuario.StatusUser = 1;
            bool habilitado = _usuarioDao.EditarUsuario(usuario);
            return habilitado;
        }

        public bool DeshabilitarUsuario(int id)
        {
            AppUser usuario = _usuarioDao.BuscarUsuarioID(id);
            usuario.StatusUser = 0;
            bool deshabilitado = _usuarioDao.EditarUsuario(usuario);
            return deshabilitado;
        }
        #endregion metodos
    }
}

