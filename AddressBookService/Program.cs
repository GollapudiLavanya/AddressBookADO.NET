using System;

namespace AddressBookService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Service");
            AddressBookRepository repository = new AddressBookRepository();
            bool result = repository.GetAllEmployee();
            if (result)
                Console.WriteLine("Successfully retrieved");
            else
                Console.WriteLine("Not retrived successfully");
        }
    }
}