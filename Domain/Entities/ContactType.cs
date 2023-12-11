using System;

namespace Domain.Entities
{
    public class ContactType : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<ContactPerson> ContactPeople { get; set; }
    }
}