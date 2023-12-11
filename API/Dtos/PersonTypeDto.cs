
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PersonTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Person> People { get; set; }
    }
}