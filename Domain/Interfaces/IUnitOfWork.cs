using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICity Cities {get;}
        IClient Clients {get;}
        IContactPerson ContactPersons {get;}
        IContactType ContactTypes {get;}
        IContract Contracts {get;}
        ICountry Countries {get;}
        IDirPerson DirPersons {get;}
        IEmployee Employees {get;}
        IPerson Persons {get;}
        IPersonType PersonTypes {get;}
        IProgramation Programations {get;}
        IRol Rols {get;}
        IShift Shifts {get;}
        IState States {get;}
        IStatus Statuses {get;}
        IUser Users {get;}
        Task<int> SaveAsync();
    }
}