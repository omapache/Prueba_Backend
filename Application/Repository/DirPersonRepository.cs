using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class DirPersonRepository : GenericRepository<DirPerson> , IDirPerson
    {
        private readonly Prueba_backendContext _context;
        public DirPersonRepository(Prueba_backendContext context) : base(context)
        {
            _context = context;
        }
    }