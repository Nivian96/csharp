using OpenQA.Selenium;

namespace addressbook;

public class NavigationHelper : HelperBase
{
    private string baseURL;
    
    public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
    {
        this.baseURL = baseURL;
    }
    
    public void GoToHomePage()
    {
        driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
    }
    
    public void GoToGroupsPage()
    {
        driver.FindElement(By.LinkText("groups")).Click();
    }
    
    public void GoToContactsPage()
    {
        driver.FindElement(By.LinkText("add new")).Click();
    }
}