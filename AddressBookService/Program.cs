using System;
using System.Collections.Generic;

namespace AddressBookService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Service");
            AddressBookRepository repository = new AddressBookRepository();
            ContactDetails details = new ContactDetails();
            details.FirstName = "Priya";
            details.LastName = "S";
            details.Address = "Gandhi Road";
            details.City = "Ongole";
            details.State = "AndhraPradesh";
            details.zip = 523001;
            details.PhoneNumber = 8976345620;
            details.Email = "PriyaP@gmail.com";
            details.ContactType = "Professsion";
            details.AddressBookName = "Office";
            bool result = repository.AddContact(details);
            if (result)
                Console.WriteLine("Contact added successfully");
            else
                Console.WriteLine("Contact not added");

            ThreadOperations threadOperations = new ThreadOperations();
            List<ContactDetails> contactList = new List<ContactDetails>();
            contactList.Add(details);

            //Add list of contacts to DB without thread
            threadOperations.AddContactListToDBWithoutThread(contactList);
            //Add list of contacts to DB with thread
            threadOperations.AddContactListToDBWithThread(contactList);
        }
    }
}
