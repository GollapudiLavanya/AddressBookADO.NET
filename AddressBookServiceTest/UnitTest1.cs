using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookService;

namespace AddressBookServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepository repository;
        [TestInitialize]
        public void SetUp()
        {
            repository = new AddressBookRepository();
        }

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
    }
}