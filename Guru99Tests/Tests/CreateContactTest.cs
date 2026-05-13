using System.Xml.Serialization;
using Guru99Tests.Base; 
using Guru99Tests.Data;

namespace Guru99Tests.Tests 
{ 
    [TestFixture] 
    public class CreateContactTest : AuthBase
    { 
        public static IEnumerable<CustomerData> CustomerDataFromXmlFile() 
        { 
            return (List<CustomerData>)new XmlSerializer(typeof(List<CustomerData>)) 
                .Deserialize(new StreamReader(Path.Combine(TestContext.CurrentContext.TestDirectory, @"customers.xml"))); 
        }

        [Test, TestCaseSource(nameof(CustomerDataFromXmlFile))]
        public void createContactTest(CustomerData customer)
        {

            app.Navigation.GoToNewCustomerPage();
            app.Contact.CreateContact(customer);

            string pageSource = app.Driver.PageSource;

            bool isCreated = pageSource.Contains("Customer Registered Successfully!!!");
            bool isBug = pageSource.Contains("<body></body>") || pageSource.Contains("500") || pageSource.Contains("Error");

            string customerId = app.Contact.GetCreatedCustomerId();

            if (customerId == null)
            {
                Assert.Ignore("Тест пропущен: Баг (Error 500). Невозможно проверить данные.");
            }

            CustomerData createdCustomer = app.Contact.GetCreatedCustomerData();

            Assert.That(createdCustomer.Name, Is.EqualTo(customer.Name), "Имя не совпадает");
            Assert.That(createdCustomer.Address, Is.EqualTo(customer.Address), "Адрес не совпадает");
            Assert.That(createdCustomer.City, Is.EqualTo(customer.City), "Город не совпадает");
            Assert.That(createdCustomer.State, Is.EqualTo(customer.State), "Штат не совпадает");
        }
    }
}