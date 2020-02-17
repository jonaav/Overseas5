using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entidades;
using Persistencia;
using Persistencia.InterfazDao;

namespace Persistencia.ImplementacionDao
{
    public class PersonaDao: IPersonaDao
    {

        private readonly DB_OverseasContext _context;
        public PersonaDao(DB_OverseasContext context) => _context = context;



                                                                                
    }
}
