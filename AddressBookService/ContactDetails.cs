using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    public class ContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal zip { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }
        public string AddressBookName { get; set; }
    }
}
