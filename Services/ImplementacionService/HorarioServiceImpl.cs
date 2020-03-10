using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class HorarioServiceImpl : IHorarioService
    {

        private readonly IHorarioDao _horarioDao;
        private readonly ISesionDao _sesionDao;

        public HorarioServiceImpl(IHorarioDao horarioDao, ISesionDao sesionDao)
        {
            _horarioDao = horarioDao;
            _sesionDao = sesionDao;
        }

        public List<Horario> BuscarHorariosCurso(int idCurso)
        {
            return _horarioDao.BuscarHorariosCurso(idCurso);
        }
        

        public String CrearHorarios(List<Horario> listaHorarios)
        {
            String mensaje = "Incorrecto";
            if( _horarioDao.CrearHorarios(listaHorarios))
                mensaje = "Correcto";
            return mensaje;
        }
        

        public String DeshabilitarHorariosCurso(int idCurso)
        {
            String mensaje = "Incorrecto";
            if(_horarioDao.DeshabilitarHorariosCurso(idCurso))
                mensaje = "Correcto";
            return mensaje;
        }      


        public void EliminarHorariosCurso( int idCurso)
        {
            List<Horario> listaHorarios = _horarioDao.BuscarHorariosCurso(idCurso);
            _horarioDao.EliminarHorariosCurso(listaHorarios);
        }

        public void EliminarSesionesHorarioCurso(int idCurso)
        {
            List<Sesion> listaSesionesActuales = _sesionDao.BuscarSesionesCurso(idCurso);
            _horarioDao.EliminarSesionesHorarioCurso(listaSesionesActuales);
        }

        public void EliminarSesionesHorarioCursoPrivado(int idCurso)
        {
            List<Sesion> listaSesionesActuales = _sesionDao.BuscarSesionesCursoNoRegistradas(idCurso);
            List<Horario> listaHorarios = new List<Horario>();
            foreach (Sesion sesion in listaSesionesActuales)
                listaHorarios.Add(sesion.Horario);
            _horarioDao.EliminarSesionesHorarioCurso(listaSesionesActuales);
            _horarioDao.EliminarHorariosCurso(listaHorarios);
            
        }

        public String EsHorarioPermitido(Horario horarioEvaluar)
        {
            String mensaje = "Horario no disponible :( ";
            if (horarioEvaluar.EsHoraFinCorrecta())
            {
                if (_horarioDao.EsHorarioPermitido(horarioEvaluar))
                    mensaje = "Correcto";
            }
            else
            {
                mensaje = "La Hora Fin debe ser mayor que la Hora Inicio";
            }
            
            return mensaje;
        }

        public String EsSesionPermitida(Sesion sesionEvaluar)
        {
            String mensaje = "Sesión no disponible :( ";
            if (sesionEvaluar.EsFechaSesionValida())
            {
                if (sesionEvaluar.Horario.EsHoraFinCorrecta())
                {
                    if (sesionEvaluar.EsHoraInicioSesionValida())
                    {
                        if (_horarioDao.EsSesionPermitida(sesionEvaluar))
                            mensaje = "Correcto";
                    }
                    else
                    {
                        mensaje = "Sesión programada para Hoy. La Hora Inicio debe ser mayor a la actual";
                    }                    
                }
                else
                {
                    mensaje = "La Hora Fin debe ser mayor que la Hora Inicio";
                }
            }
            else
            {
                mensaje = "La Fecha de Sesión debe ser mayor o igual a la Fecha Actual";
            }            
            return mensaje;
        }

        public int ObtenerIdUltimoHorario()
        {
            return _horarioDao.ObtenerIdUltimoHorario();
        }

       
    }
}
