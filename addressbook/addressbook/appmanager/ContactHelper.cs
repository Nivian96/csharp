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
    
    public ContactHelper Modify(int i, ContactData newData)
    {
        manager.Navigation.GoToHomePage();
        
        SelectContact(i);
        FillContactForm(newData);
        SubmitContactModification();
        ReturnToHomePage();
        return this;
    }

    public ContactHelper Remove(int i)
    {
        manager.Navigation.GoToHomePage();
        
        SelectContact(i);
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
        contactCache = null;
        return this;
    }

    public ContactHelper ReturnToHomePage()
    {
        driver.FindElement(By.LinkText("home page")).Click();
        return this;
    }
    
    public ContactHelper SelectContact(int index)
    {
        wait.Until(d => d.FindElement(By.XPath($"//tr[{index+2}]//img[@alt='Edit']"))).Click();
        return this;
    }

    public ContactHelper RemoveContact()
    {
        driver.FindElement(By.Name("delete")).Click();
        contactCache = null;
        return this;
    }
    
    public ContactHelper SubmitContactModification()
    {
        driver.FindElement(By.Name("update")).Click();
        contactCache = null;
        return this;
    }
    
    public void EnsureContactExists(ContactData contact)
    {
        if (wait.Until(d => d.FindElement(By.Id("search_count"))).Text == "0")
        {
            Create(contact);
        }
    }

    private List<ContactData> contactCache = null;

    public List<ContactData> GetContactList()
    {
        if (contactCache == null)
        {
            contactCache = new List<ContactData>();
            manager.Navigation.GoToStartPage();
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("tr[name='entry']"));
            foreach (IWebElement row in rows)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                string lastName = cells[1].Text;
                string firstName = cells[2].Text;
                contactCache.Add(new ContactData(firstName, lastName));
            }
        }
        return new List<ContactData>(contactCache);
    }

    public int GetContactCount()
    {
        return driver.FindElements(By.Name("entry")).Count;
    }
}