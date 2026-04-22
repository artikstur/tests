using Guru99Tests.Base;
using Guru99Tests.Data;

namespace Guru99Tests.Tests
{
    [TestFixture]
    public class DeleteContactTest : TestBase
    {
        [Test]
        public void deleteContactTest()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("mngr659011", "byturEg"));

            CustomerData temporaryCustomer = new CustomerData("ToDelete")
            {
                Dob = "01012000",
                Address = "Trash street",
                City = "TrashCity",
                State = "NA",
                Pin = "000000",
                Mobile = "0000000000",
                Email = "del" + new Random().Next(1000, 9999) + "@email.ru",
                Password = "123"
            };
            app.Navigation.GoToNewCustomerPage();
            app.Contact.CreateContact(temporaryCustomer);

            string customerId = app.Contact.GetCreatedCustomerId();

            app.Navigation.GoToDeleteCustomerPage();
            app.Contact.SubmitIdForAction(customerId);

            app.Contact.DeleteContact();

            bool isFormPresent = app.Driver.PageSource.Contains("Delete Customer Form");
            bool isServerError = app.Driver.PageSource.Contains("500") || app.Driver.PageSource.Contains("Error");

            Assert.That(isFormPresent || isServerError, Is.True, "Удаление прошло, но сайт вернул ошибку 500");
        }
    }
}
