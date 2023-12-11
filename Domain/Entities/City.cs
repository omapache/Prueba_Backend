using System;

namespace Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<DirPerson> DirPeople { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
    }
}