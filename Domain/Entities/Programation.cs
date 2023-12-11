using System;

namespace Domain.Entities
{
    public class Programation : BaseEntity
    {
        public Contract Contract { get; set; }
        public int ContractId { get; set; }
        public Shift Shift { get; set; }
        public int ShiftId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}