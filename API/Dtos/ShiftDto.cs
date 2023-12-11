
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ShiftDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftFinal{ get; set; }
        public ICollection<Programation> Programations { get; set; }
    }
}