
using System;

namespace Domain.Entities
{
    public class Contract : BaseEntity
    {
        public DateOnly ContractDate { get; set; }
        public DateOnly ContractFinalDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public ICollection<Programation> Programations { get; set; }
    }
}