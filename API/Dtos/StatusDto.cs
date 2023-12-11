using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}