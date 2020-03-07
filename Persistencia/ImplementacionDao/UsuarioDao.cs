using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.ImplementacionDao
{
    public class UsuarioDao:IUsuarioDao
    {
        private readonly DB_OverseasContext _context;

        public UsuarioDao(DB_OverseasContext context)
        {
            _context = context;
        }

        #region metodos


        /*
         *  Listar Usuarios 
         */
         
        public List<AppUser> ListarUsuarios() => _context.Usuario
                                                .Include(u => u.Persona)
                                                .ToList();



        /*
         *  Buscar Usuario por ID 
         */

        public AppUser BuscarUsuarioID(int id) => _context.Usuario.Find(id);


        /*
         *  Buscar Usuario por correo 
         */

        public AppUser BuscarUsuarioCorreo(string correo) => _context.Usuario
                                                            .Where(u => u.UserName == correo)
                                                            .Include(u => u.Persona)
                                                            .FirstOrDefault();
        

        /*
         *  Buscar Usuario por persona 
         */

        public AppUser BuscarUsuarioPorPersona(int idPersona) => _context.Usuario
                                                            .Where(u => u.IdPersona == idPersona)
                                                            .Include(u => u.Persona)
                                                            .FirstOrDefault();

        /*
         *  Editar Usuario 
         */

        public bool EditarUsuario(AppUser usuario)
        {
            try
            {
                _context.Usuario.Attach(usuario);
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /*
         *  Buscar Rol de un usuario
         */

        public AppRole BuscarUserRole(int idUser)
        {
            AppRole rol = new AppRole();
            try
            {
                rol = (from ur in _context.UserRoles
                           join r in _context.Roles on ur.RoleId equals r.Id
                           where ur.UserId == idUser
                           select new AppRole
                           {
                               Id = r.Id,
                               NormalizedName = r.NormalizedName
                           }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rol;
        }

        #endregion metodos
    }
}
