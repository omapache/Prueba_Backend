using System;

namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
    }
}