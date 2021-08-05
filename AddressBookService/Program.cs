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
            bool result = repository.InsertDataIntoTable(details);
            if (result)
                Console.WriteLine("Inserted Successfully\n");
            else
                Console.WriteLine("Not inserted\n");
            repository.GetAllEmployee();
        }
    }
}