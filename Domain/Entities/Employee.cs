using System;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Programation> Programations { get; set; }
    }
}