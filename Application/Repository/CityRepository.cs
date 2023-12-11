using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Repository;

namespace Application.Repository;
public class CityRepository : GenericRepository<City> , ICity
    {
        private readonly Prueba_backendContext _context;
        public CityRepository(Prueba_backendContext context) : base(context)
        {
            _context = context;
        }
    }