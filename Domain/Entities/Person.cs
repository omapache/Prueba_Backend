using System;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public DateOnly RegisterDate { get; set; }
        public DirPerson DirPerson { get; set; }
        public int IdPerson { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public PersonType PersonType { get; set; }
        public int PersonTypeId { get; set; }
        public ICollection<ContactPerson> ContactPeople  { get; set; }
    }
}