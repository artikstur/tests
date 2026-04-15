using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Guru99Tests
{
    [TestFixture]
    public class CreateContactTest : TestBase
    {
        [Test]
        public void createContactTest()
        {
            OpenHomePage();

            AccountData admin = new AccountData("mngr659011", "byturEg");
            Login(admin);

            CustomerData customer = new CustomerData("Artur")
            {
                Dob = "01042026",
                Address = "Baker street 221b",
                City = "London",
                State = "UK",
                Pin = "123123",
                Mobile = "123456789",
                Email = "test" + new Random().Next(1000, 9999) + "@email.ru",
                Password = "aaaaaa"
            };

            InitCustomerCreation();
            FillCustomerForm(customer);
            SubmitCustomerCreation();

            Assert.That(driver.PageSource, Does.Contain("Customer Registered Successfully!!!"));
        }

        private void FillCustomerForm(CustomerData customer)
        {
            FillTheField(By.Name("name"), customer.Name);
            FillTheField(By.Id("dob"), customer.Dob);
            FillTheField(By.Name("addr"), customer.Address);
            FillTheField(By.Name("city"), customer.City);
            FillTheField(By.Name("state"), customer.State);
            FillTheField(By.Name("pinno"), customer.Pin);
            FillTheField(By.Name("telephoneno"), customer.Mobile);
            FillTheField(By.Name("emailid"), customer.Email);
            FillTheField(By.Name("password"), customer.Password);
        }
    }
}
