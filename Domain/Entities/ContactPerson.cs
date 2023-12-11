using System;

namespace Domain.Entities
{
    public class ContactPerson : BaseEntity
    {
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
        public int ContactTypeId { get; set; }
    }
}