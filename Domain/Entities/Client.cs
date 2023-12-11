using System;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}