using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        public DateOnly ContractDate { get; set; }
        public DateOnly ContractFinalDate { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public ICollection<Programation> Programations { get; set; }
    }
}