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

        public bool CrearHorarios(List<Horario> listaHorarios, List<Sesion> listaSesiones)
        {
            return _horarioDao.CrearHorarios(listaHorarios, listaSesiones);
        }

        public bool CrearHorariosRegular(List<Horario> listaHorarios)
        {
            return _horarioDao.CrearHorariosRegular(listaHorarios);
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

        public bool EsHorarioPermitido(Horario horarioEvaluar)
        {
            return _horarioDao.EsHorarioPermitido(horarioEvaluar);
        }

        public int ObtenerIdUltimoHorario()
        {
            return _horarioDao.ObtenerIdUltimoHorario();
        }

        /*
        private readonly DB_OverseasContext _context;

        public HorarioServiceImpl(DB_OverseasContext context)
        {
            _context = context;
        }

        public List<HorarioC> BuscarHorariosCurso(int id)
        {
            List<HorarioC> horarios = new List<HorarioC>();
            try
            {
                horarios = null;
            }
            catch (Exception e)
            {
                throw e;
            }
            return horarios;
        }

        public List<Horario> BuscarHorariosParaIngresarDetalle(int id)
        {
            List<Horario> horarios = new List<Horario>();
            try
            {
                horarios       = (from h in _context.Horario
                                  join c in _context.Curso on h.Curso.IdCurso equals c.IdCurso
                                  where h.IdCurso == id

                                  select new Horario
                                  {
                                      IdHorario = h.IdHorario,
                                      Dia = h.Dia,
                                      HoraInicio = h.HoraInicio,
                                      HoraFin = h.HoraFin,
                                      IdCurso = h.IdCurso,                                      
                                  }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return horarios;
        }

        
        public void EditarHorariosCurso(List<Horario> horarios, int idAula, int idCurso) 
        {
            try
            {
                EliminarHorariosCurso(idCurso, idAula);
                RegistrarHorariosCurso(horarios, idAula, idCurso);                  
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarHorariosCurso(int id, int idAula)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RegistrarHorariosCurso(List<Horario> horarios, int idAula, int idCurso)
        {

        }*/
    }
}
