using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia
{
    public class DB_OverseasContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DB_OverseasContext(DbContextOptions<DB_OverseasContext> options) 
            : base(options)
        {

        }


        public DbSet<Apoderado> Apoderado { get; set; }
        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Ambiente> Ambiente { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<TipoCurso> TipoCurso { get; set; }
        public DbSet<DetalleApoderadoEstudiante> DetalleApoderadoEstudiante { get; set; }
        public DbSet<DetalleDocenteEspecialidad> DetalleDocenteEspecialidad { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<TipoEvaluacion> TipoEvaluacion { get; set; }
        public DbSet<TipoCursoTipoEvaluacion> TCursoTEvaluacion { get; set; }
        public DbSet<HistorialEvaluacion> HistorialEvaluacion { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Sesion> Sesion { get; set; }
        public DbSet<AppRole> TipoUsuario { get; set; }
        public virtual DbSet<Traduccion> Traduccion { get; set; }
        public DbSet<AppUser> Usuario { get; set; }
        //public DbSet<AppUser> UserRole { get; set; }






    }
}
