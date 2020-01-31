using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia.InterfazDao;
using Services.InterfazService;

namespace Services.ImplementacionService
{
    public class AmbienteServiceImpl : IAmbienteService
    {

        private readonly IAmbienteDao _ambienteDao;

        public AmbienteServiceImpl(IAmbienteDao ambienteDao)
        {
            _ambienteDao = ambienteDao;
        }

        public Ambiente BuscarAmbiente(int idAmbiente)
        {                       
            return _ambienteDao.BuscarAmbiente(idAmbiente);
        }

        public bool CrearAmbiente(Ambiente ambiente)
        {
            return _ambienteDao.CrearAmbiente(ambiente);            

        }


        public bool EliminarAmbiente(int idAmbiente)
        {
            return _ambienteDao.EliminarAmbiente(idAmbiente);
        }

        public List<Ambiente> ListarAmbientes()
        {
            return _ambienteDao.ListarAmbientes();
        }
    }
}
