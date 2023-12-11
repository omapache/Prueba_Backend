using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class CountryRepository : GenericRepository<Country> , ICountry
    {
        private readonly Prueba_backendContext _context;
        public CountryRepository(Prueba_backendContext context) : base(context)
        {
            _context = context;
        }
    }
