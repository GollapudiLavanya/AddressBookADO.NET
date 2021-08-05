using System;

namespace AddressBookService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Service");
            AddressBookRepository repository = new AddressBookRepository();
            ContactDetails details = new ContactDetails();
            bool result = repository.UpdateDataInTable(details);
            if (result)
                Console.WriteLine("Successfully Updated");
            else
                Console.WriteLine("Not Updated");
        }
    }
}