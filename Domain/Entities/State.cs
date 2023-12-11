using System;

namespace Domain.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}