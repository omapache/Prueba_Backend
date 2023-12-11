using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public DateOnly RegisterDate { get; set; }
        public int IdPerson { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public int PersonTypeId { get; set; }
    }
}