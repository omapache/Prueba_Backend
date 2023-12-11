
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class ContactPersonRepository : GenericRepository<ContactPerson> , IContactPerson
    {
        private readonly Prueba_backendContext _context;
        public ContactPersonRepository(Prueba_backendContext context) : base(context)
        {
            _context = context;
        }
    }