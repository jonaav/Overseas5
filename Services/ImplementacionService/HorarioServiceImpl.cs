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

        public HorarioServiceImpl(IHorarioDao horarioDao)
        {
            _horarioDao = horarioDao;            
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

        public string DeshabilitarHorariosCurso(int idCurso)
        {
            String mensaje = "Incorrecto";
            if(_horarioDao.DeshabilitarHorariosCurso(idCurso))
                mensaje = "Correcto";
            return mensaje;
        }

        public bool EditarHorariosCurso(List<Horario> listaHorarios, List<Sesion> listaSesionesActuales, int idCurso)
        {
            return _horarioDao.EditarHorariosCurso(listaHorarios, listaSesionesActuales, idCurso);
        }



        public void EliminarHorariosCurso( int idCurso)
        {
            _horarioDao.EliminarHorariosCurso(idCurso);
        }

        public void EliminarSesionesHorarioCurso(List<Sesion> listaSesionesActuales)
        {
            _horarioDao.EliminarSesionesHorarioCurso(listaSesionesActuales);
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
