using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DirPerson : BaseEntity
    {
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }


        public string TypeOfStreet { get; set; }
        public int FirstNumber { get; set; }
        public string Letter { get; set; }
        public string Bis { get; set; }
        public string SecondLetter { get; set; }
        public string Cardinal { get; set; }
        public int SecondNumber { get; set; }
        public string ThirdLetter { get; set; }
        public int ThirdNumber { get; set; }
        public string SecondCardinal { get; set; }
        public string Complement { get; set; }

        [Required]
        public int IdCity { get; set; }
        public City City { get; set; }
    }
}