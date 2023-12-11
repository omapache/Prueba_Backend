
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class DirPersonDto
    {
        public int Id { get; set; }
        public int IdCity { get; set; }
        public int PersonId { get; set; }
        public string TypeOfStreet { get; set; }
        public int FirstNumber { get; set; }
        public string Letter { get; set; }
        public int SecondNumber { get; set; }
        public int ThirdNumber { get; set; }
    }
}