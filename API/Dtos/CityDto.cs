using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class CityDto
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public int StateId { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<DirPerson> DirPeople { get; set; }
    }
}