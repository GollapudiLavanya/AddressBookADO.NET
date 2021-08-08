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
            details.FirstName = "Kiranmayi";
            details.LastName = "P";
            details.Address = "C.S.Puram Road";
            details.City = "Pamur";
            details.State = "AndhraPradesh";
            details.zip = 523108;
            details.PhoneNumber = 7867567856;
            details.Email = "kiranmayi@gmail.com";
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