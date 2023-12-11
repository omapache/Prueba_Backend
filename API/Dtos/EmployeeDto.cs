
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Programation> Programations { get; set; }
    }
}