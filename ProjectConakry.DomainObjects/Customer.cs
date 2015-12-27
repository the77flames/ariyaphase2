using System;

namespace ProjectConakry.DomainObjects
{
    public class Customer : MongoEntity, IPerson
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DOB {get; set;}
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool HasVoted { get; set; }
    }
}
