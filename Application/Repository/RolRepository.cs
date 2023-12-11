using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly Prueba_backendContext _context;
    public RolRepository(Prueba_backendContext context) : base(context)
    {
        _context = context;
    }
}