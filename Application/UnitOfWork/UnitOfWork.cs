using System;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Prueba_backendContext _context;

    private ICity _Cities;
    private IClient _Clients;
    private IContactPerson _ContactPersons;
    private IContactType _ContactTypes;
    private IContract _Contracts;
    private ICountry _Countrys;
    private IDirPerson _DirPersons;
    private IEmployee _Employees;
    private IPerson _Persons;
    private IPersonType _PersonTypes;
    private IProgramation _Programations;
    private IRol _Rols;
    private IShift _Shifts;
    private IState _States;
    private IStatus _Statuses;
    private IUser _Users;

    public ICity Cities {
        get {
            if (_Cities == null) {
                _Cities = new CityRepository(_context);
            }
            return _Cities;
        }
    }

    public IClient Clients {
        get {
            if (_Clients == null) {
                _Clients = new ClientRepository(_context);
            }
            return _Clients;
        }
    }
    public IContactPerson ContactPersons {
        get {
            if (_ContactPersons == null) {
                _ContactPersons = new ContactPersonRepository(_context);
            }
            return _ContactPersons;
        }
    }
    public IContactType ContactTypes {
        get {
            if (_ContactTypes == null) {
                _ContactTypes = new ContactTypeRepository(_context);
            }
            return _ContactTypes;
        }
    }

    public IContract Contracts{
        get {
            if (_Contracts == null) {
                _Contracts = new ContractRepository(_context);
            }
            return _Contracts;
        }
    }

    public ICountry Countries {
        get {
            if (_Countrys == null) {
                _Countrys = new CountryRepository(_context);
            }
            return _Countrys;
        }
    }

    public IDirPerson DirPersons {
        get {
            if (_DirPersons == null) {
                _DirPersons = new DirPersonRepository(_context);
            }
            return _DirPersons;
        }
    }

    public IEmployee Employees {
        get {
            if (_Employees == null) {
                _Employees = new EmployeeRepository(_context);
            }
            return _Employees;
        }
    }

    public IPerson Persons {
        get {
            if (_Persons == null) {
                _Persons = new PersonRepository(_context);
            }
            return _Persons;
        }
    }

    public IPersonType PersonTypes {
        get {
            if (_PersonTypes == null) {
                _PersonTypes = new PersonTypeRepository(_context);
            }
            return _PersonTypes;
        }
    }

    public IProgramation Programations {
        get {
            if (_Programations == null) {
                _Programations = new ProgramationRepository(_context);
            }
            return _Programations;
        }
    }

    public IRol Rols {
        get {
            if (_Rols == null) {
                _Rols = new RolRepository(_context);
            }
            return _Rols;
        }
    }

    public IShift Shifts {
        get {
            if (_Shifts == null) {
                _Shifts = new ShiftRepository(_context);
            }
            return _Shifts;
        }
    }
    public IState States {
        get {
            if (_States == null) {
                _States = new StateRepository(_context);
            }
            return _States;
        }
    }

    public IStatus Statuses {
        get {
            if (_Statuses == null) {
                _Statuses = new StatusRepository(_context);
            }
            return _Statuses;
        }
    }

    public IUser Users {
        get {
            if (_Users == null) {
                _Users = new UserRepository(_context);
            }
            return _Users;
        }
    }


    public UnitOfWork(Prueba_backendContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}