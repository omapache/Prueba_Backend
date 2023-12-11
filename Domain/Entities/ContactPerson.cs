using System;

namespace Domain.Entities
{
    public class ContactPerson : BaseEntity
    {
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
        public int ContactTypeId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}