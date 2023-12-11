
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ProgramationDto
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
    }
}