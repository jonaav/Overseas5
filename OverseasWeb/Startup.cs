using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Entidades;
using Persistencia;
using Persistencia.InterfazDao;
using Persistencia.ImplementacionDao;
using Services.InterfazService;
using Services.ImplementacionService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace OverseasWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<DB_OverseasContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Login/Login");

            services.AddDbContext<DB_OverseasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
            //DAO
            services.AddScoped<IPersonaDao, PersonaDao>();
            services.AddScoped<IEstudianteDao, EstudianteDao>();
            services.AddScoped<IDocenteDao, DocenteDao>();
            services.AddScoped<IEspecialidadDao, EspecialidadDao>();
            services.AddScoped<IDetalleDocenteEspecialidadDao, DetalleDocenteEspecialidadDao>();
            services.AddScoped<IApoderadoDao, ApoderadoDao>();
            services.AddScoped<IDetalleApoderadoEstudianteDao, DetalleApoderadoEstudianteDao>();
            services.AddScoped<IInscripcionDao, InscripcionDao>();
            services.AddScoped<IUsuarioDao, UsuarioDao>();

            services.AddScoped<IAmbienteDao, AmbienteDao>();
            services.AddScoped<ICursoDao, CursoDao>();
            services.AddScoped<ITipoCursoDao, TipoCursoDao>();
            services.AddScoped<IHorarioDao, HorarioDao>();
            services.AddScoped<ISesionDao, SesionDao>();
            services.AddScoped<ITraduccionDao, TraduccionDao>();

            services.AddScoped<ITipoEvaluacionDao, TipoEvaluacionDao>();
            services.AddScoped<IHistorialEvaluacionDao, HistorialEvaluacionDao>();




            //SERVICE
            services.AddScoped<IEstudianteService, EstudianteServiceImpl>();
            services.AddScoped<IApoderadoService, ApoderadoServiceImpl>();
            services.AddScoped<IDocenteService, DocenteServiceImpl>();
            services.AddScoped<IEspecialidadService, EspecialidadServiceImpl>();
            services.AddScoped<IUsuarioService, UsuarioServiceImpl>();
            services.AddScoped<IInscripcionService, InscripcionServiceImpl>();
            services.AddScoped<IInicioAdminService, InicioAdminServiceImpl>();
            services.AddScoped<IInicioDocenteService, InicioDocenteServiceImpl>();

            services.AddScoped<ICursoService, CursoServiceImpl>();
            services.AddScoped<ICursoEvaluacionService, CursoEvaluacionServiceImpl>();
            //services.AddScoped<ITipoEvaluacionService, TipoEvaluacionServiceImpl>();
            services.AddScoped<ITraduccionService, TraduccionServiceImpl>();
            services.AddScoped<IAmbienteService, AmbienteServiceImpl>();
            services.AddScoped<IHorarioService, HorarioServiceImpl>();
            services.AddScoped<ISesionService, SesionServiceImpl>();


            services.AddScoped<ICalificacionesService, CalificacionesServiceImpl>();


            
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
