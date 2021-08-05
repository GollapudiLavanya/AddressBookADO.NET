using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookService;

namespace AddressBookServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepository repository;
        ContactDetails details;
        [TestInitialize]
        public void SetUp()
        {
            repository = new AddressBookRepository();
            details = new ContactDetails();
        }

        /// <summary>
        /// Retrieve all the data
        /// </summary>
        [TestMethod]
        public void RetrieveAllData()
        {
            ///AAA Methodology
            //Arrange
            bool expected = true;
            //Act
            bool actual = repository.GetAllEmployee();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Update data in table 
        /// </summary>
        [TestMethod]
        public void UpdateTable()
        {
            ///AAA Methodology
            //Arrange
            bool expected = true;
            //Act
            bool actual = repository.UpdateDataInTable(details);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}