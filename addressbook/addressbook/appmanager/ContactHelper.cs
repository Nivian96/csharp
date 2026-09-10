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
        manager.Navigation.GoToHomePage();

        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        EnsureContactExists(contact);
        
        SelectContact();
        FillContactForm(newData);
        SubmitContactModification();
        ReturnToHomePage();
        return this;
    }

    public ContactHelper Remove()
    {
        manager.Navigation.GoToHomePage();

        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        EnsureContactExists(contact);
        
        SelectContact();
        RemoveContact();
        ReturnToHomePage();
        return this;
    }
    
    public ContactHelper FillContactForm(ContactData contact)
    {
        Type(By.Name("firstname"), contact.FirstName);
        Type(By.Name("lastname"), contact.LastName);
        Type(By.Name("address"), contact.Address);
        Type(By.Name("email"), contact.EMail);
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
        wait.Until(d => d.FindElement(By.XPath("//img[@alt='Edit']"))).Click();
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
    
    private void EnsureContactExists(ContactData contact)
    {
        if (wait.Until(d => d.FindElement(By.Id("search_count"))).Text == "0")
        {
            Create(contact);
        }
    }
}