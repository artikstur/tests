using Guru99Tests.Base;
using Guru99Tests.Data;
using OpenQA.Selenium;

namespace Guru99Tests.Helpers
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(AppManager manager) : base(manager)
        {
        }

        public void CreateContact(CustomerData customer)
        {
            FillCustomerForm(customer);
            SubmitCustomerCreation();
        }

        public string GetCreatedCustomerId()
        {
            IWebElement idCell = driver.FindElement(By.XPath("//td[text()='Customer ID']/following-sibling::td"));
            return idCell.Text;
        }

        public void SubmitIdForAction(string id)
        {
            FillTheField(By.Name("cusid"), id);
            driver.FindElement(By.Name("AccSubmit")).Click();
            Thread.Sleep(2000);
        }

        public void EditContact(CustomerData newData)
        {
            FillTheField(By.Name("addr"), newData.Address);
            FillTheField(By.Name("city"), newData.City);
            FillTheField(By.Name("state"), newData.State);
            FillTheField(By.Name("pinno"), newData.Pin);
            FillTheField(By.Name("telephoneno"), newData.Mobile);

            driver.FindElement(By.Name("sub")).Click();
            Thread.Sleep(3000);
        }

        public void DeleteContact()
        {
            try
            {
                IAlert alertConfirmation = driver.SwitchTo().Alert();
                alertConfirmation.Accept();
                Thread.Sleep(1000);
            }
            catch (NoAlertPresentException) { }

            try
            {
                IAlert alertSuccess = driver.SwitchTo().Alert();
                alertSuccess.Accept();
                Thread.Sleep(1000);
            }
            catch (NoAlertPresentException)
            {
            }
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

        private void SubmitCustomerCreation()
        {
            IWebElement submitBtn = driver.FindElement(By.Name("sub"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            Thread.Sleep(1000);
            submitBtn.Click();
            Thread.Sleep(3000);
        }
    }
}
