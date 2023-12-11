using System;

namespace Domain.Entities
{
    public class PersonType : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<Person> People { get; set; }
    }
}