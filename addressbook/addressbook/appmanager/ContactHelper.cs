using OpenQA.Selenium;

namespace addressbook;

public class ContactHelper : HelperBase
{
    public ContactHelper(ApplicationManager manager) : base(manager)
    {
    }
    
    public ContactHelper Create(ContactData contact)
    {
        manager.Navigation.GoToContactsPage();
        
        FillContactForm(contact);
        SubmitContactCreation();
        ReturnToHomePage();
        return this;
    }
    
    public ContactHelper Modify(ContactData newData)
    {
        SelectContact();
        FillContactForm(newData);
        SubmitContactModification();
        ReturnToHomePage();
        return this;
    }

    public ContactHelper Remove()
    {
        SelectContact();
        RemoveContact();
        ReturnToHomePage();
        return this;
    }
    
    public ContactHelper FillContactForm(ContactData contact)
    {
        driver.FindElement(By.Name("firstname")).Click();
        driver.FindElement(By.Name("firstname")).Clear();
        driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
        driver.FindElement(By.Name("lastname")).Click();
        driver.FindElement(By.Name("lastname")).Clear();
        driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        driver.FindElement(By.Name("address")).Click();
        driver.FindElement(By.Name("address")).Clear();
        driver.FindElement(By.Name("address")).SendKeys(contact.Address);
        driver.FindElement(By.Name("email")).Click();
        driver.FindElement(By.Name("email")).Clear();
        driver.FindElement(By.Name("email")).SendKeys(contact.EMail);
        return this;
    }
    
    public ContactHelper SubmitContactCreation()
    {
        driver.FindElement(By.XPath("//input[19]")).Click();
        return this;
    }

    public ContactHelper ReturnToHomePage()
    {
        driver.FindElement(By.LinkText("home page")).Click();
        return this;
    }
    
    public ContactHelper SelectContact()
    {
        driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
        return this;
    }

    public ContactHelper RemoveContact()
    {
        driver.FindElement(By.Name("delete")).Click();
        return this;
    }
    
    public ContactHelper SubmitContactModification()
    {
        driver.FindElement(By.Name("update")).Click();
        return this;
    }
}