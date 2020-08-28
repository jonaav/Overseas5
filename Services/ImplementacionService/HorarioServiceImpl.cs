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
        private readonly ICursoDao _cursoDao;

        public HorarioServiceImpl(IHorarioDao horarioDao, ISesionDao sesionDao, ICursoDao cursoDao)
        {
            _horarioDao = horarioDao;
            _sesionDao = sesionDao;
            _cursoDao = cursoDao;
        }
        /*
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
        */


        //Remake



        public List<Horario> BuscarHorariosCurso(int idCurso)
        {
            return _horarioDao.BuscarHorariosCurso(idCurso);
        }
        
        public Horario BuscarHorario(int idHorario)
        {
            return _horarioDao.BuscarHorario(idHorario);
        }


        public String CrearHorario(Horario horario)
        {
            String mensaje = "Datos no válidos";
            if (horario.EsHoraFinCorrecta())
            {
                List<Horario> listaHorarios = _horarioDao.BuscarHorariosPorAmbienteDia(horario);
                foreach (Horario h in listaHorarios)
                {
                    if (!horario.VerificarCruce(h))
                    {
                        Curso curso = _cursoDao.BuscarCursoPorID(horario.IdCurso);
                        if(!curso.ValidarFechaInicio(h.Curso.FechaFin))
                        {
                            mensaje = "Existe un cruce de horario";
                            return mensaje;
                        }
                    }
                }

                if (_horarioDao.CrearHorario(horario))
                    mensaje = "Registrado";
            }
            else
            {
                mensaje = "La hora de inicio y fin no son adecuadas";
            }

            return mensaje;
        }

        public String EditarHorario(Horario horario)
        {
            String mensaje = "Datos no válidos";
            if (horario.EsHoraFinCorrecta())
            {
                /*
                 * Busca todos los horarios del aula en el dia y compara con el nuevo horario para verificar un cruce
                 */
                List<Horario> listaHorarios = _horarioDao.BuscarHorariosPorAmbienteDia(horario);
                foreach (Horario h in listaHorarios)
                {
                    if (!horario.VerificarCruce(h))
                    {
                        /*
                         * busca el curso con el que se relaciona y 
                         * compara que la nueva fecha inicio sea posterior a la fecha fin del curso anterior con el mismo horario
                         */ 
                        Curso curso = _cursoDao.BuscarCursoPorID(horario.IdCurso);
                        if (!curso.ValidarFechaInicio(h.Curso.FechaFin) && (horario.IdHorario != h.IdHorario))
                        {
                            mensaje = "Existe un cruce de horario";
                            return mensaje;
                        }
                    }
                }

                if (_horarioDao.EditarHorario(horario))
                    mensaje = "Datos actualizados";
            }

            return mensaje;
        }


        

        public String AnularHorario(int idHorario)
        {
            String mensaje = "Error";
            Horario horario = _horarioDao.BuscarHorario(idHorario);
            horario.EstadoHorario = 0;
            if (_horarioDao.EditarHorario(horario))
                mensaje = "Horario Anulado";
            return mensaje;
        }


        public String EsHorarioPermitido(Horario horarioEvaluar)
        {
            String mensaje = "Horario no disponible";
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


    }
}
