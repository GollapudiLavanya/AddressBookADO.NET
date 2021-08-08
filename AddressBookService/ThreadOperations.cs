using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace AddressBookService
{
    public class ThreadOperations
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddContact(ContactDetails details)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using (sqlConnection)
                {
                    //Adding contact using stored procedure

                    SqlCommand command = new SqlCommand("dbo.AddContact", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", details.FirstName);
                    command.Parameters.AddWithValue("@LastName", details.LastName);
                    command.Parameters.AddWithValue("@Address", details.Address);
                    command.Parameters.AddWithValue("@City", details.City);
                    command.Parameters.AddWithValue("@State", details.State);
                    command.Parameters.AddWithValue("@Zip", details.zip);
                    command.Parameters.AddWithValue("@PhoneNumber", details.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", details.Email);
                    command.Parameters.AddWithValue("@AddressBookName", details.AddressBookName);
                    command.Parameters.AddWithValue("@RelationType", details.ContactType);
                    this.connection.Open(); //Opening the connection
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                        return true;
                    return false;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close(); //Closing the connection
            }
            return false;
        }
        //Method to add list without thread
        public void AddContactListToDBWithoutThread(List<ContactDetails> contactList)
        {
            contactList.ForEach(contact =>
            {
                Console.WriteLine("Contact being added : " + contact.FirstName);
                this.AddContact(contact);
                Console.WriteLine("Contact added : " + contact.FirstName);
            });
        }
        //Method to add list with thread
        public void AddContactListToDBWithThread(List<ContactDetails> contactList)
        {
            contactList.ForEach(contact =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Contact being added : " + contact.FirstName);
                    this.AddContact(contact);
                    Console.WriteLine("Contact added : " + contact.FirstName);
                });
                thread.Start();
                thread.Join();
            });
        }
    }
}