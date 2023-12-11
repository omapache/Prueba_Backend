using System;

namespace Domain.Entities
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftFinal{ get; set; }
        public ICollection<Programation> Programations { get; set; }
    }
}