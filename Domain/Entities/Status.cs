using System;

namespace Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}