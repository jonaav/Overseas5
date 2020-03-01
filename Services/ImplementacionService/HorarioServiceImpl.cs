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
            String mensaje = "Incorrecto";
            if (_horarioDao.EsHorarioPermitido(horarioEvaluar))
                mensaje = "Correcto";
            return mensaje;
        }

        public String EsSesionPermitida(Sesion sesionEvaluar)
        {
            String mensaje = "Incorrecto";
            if( _horarioDao.EsSesionPermitida(sesionEvaluar))
                mensaje = "Correcto";
            return mensaje;
        }

        public int ObtenerIdUltimoHorario()
        {
            return _horarioDao.ObtenerIdUltimoHorario();
        }

       
    }
}
