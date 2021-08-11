using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    public class AddressBookRepository
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;";
        SqlConnection connection = new SqlConnection(connectionString);

        //Retrieve all data from AddressBook Table
        public bool GetAllEmployee()
        {
            try
            {
                ContactDetails details = new ContactDetails();
                using (this.connection)
                {
                    //Query to perfom
                    string query = @"select * from AddressBookTable";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open(); //Opening the connection
                    SqlDataReader dataReader = command.ExecuteReader();
                    //Checking if the table has data
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            details.FirstName = dataReader["FirstName"].ToString();
                            details.LastName = dataReader["LastName"].ToString();
                            details.Address = dataReader["Address"].ToString();
                            details.City = dataReader["City"].ToString();
                            details.State = dataReader["State"].ToString();
                            details.zip = Convert.ToDecimal(dataReader["zip"]);
                            details.PhoneNumber = Convert.ToDecimal(dataReader["phonenumber"]);
                            details.Email = dataReader["Email"].ToString();
                            details.ContactType = dataReader["RelationType"].ToString();
                            details.AddressBookName = dataReader["AddressBookName"].ToString();
                            Console.WriteLine(details.FirstName + " " + details.LastName + " " + details.Address + " " + details.City + " " + details.State + " " + details.zip + " " + details.PhoneNumber + " " + details.Email + " " + details.ContactType + " " + details.AddressBookName);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.connection.Close(); //closing the connection
            }
        }

        public bool UpdateDataInTable(ContactDetails details)
        {
            try
            {
                //Query to perform
                string query = @"update AddressBookTable set Address='TekkaMitta' where FirstName='Vindhya'";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                this.connection.Open(); //Opening the connection
                int result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close(); //Closing the connection
            }
        }
    }
}
