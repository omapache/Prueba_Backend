using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ContactPerson, ContactPersonDto>().ReverseMap();
            CreateMap<ContactType, ContactTypeDto>().ReverseMap();
            CreateMap<Contract, ContractDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<DirPerson, DirPersonDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<PersonType, PersonTypeDto>().ReverseMap();
            CreateMap<Programation, ProgramationDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Shift, ShiftDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}