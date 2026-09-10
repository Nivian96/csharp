using OpenQA.Selenium;

namespace addressbook;

public class NavigationHelper : HelperBase
{
    private string baseURL;
    
    public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
    {
        this.baseURL = baseURL;
    }
    
    public void GoToStartPage()
    {
        if (driver.Url == baseURL + "/addressbook/index.php")
        {
            return;
        }
        driver.Navigate().GoToUrl(baseURL + "/addressbook/index.php");
    }
    
    public void GoToGroupsPage()
    {
        if (driver.Url == baseURL + "/addressbook/group.php"
            &&
            IsElementPresent(By.Name("new")))
        {
            return;
        }
        driver.FindElement(By.LinkText("groups")).Click();
    }
    
    public void GoToContactsPage()
    {
        driver.FindElement(By.LinkText("add new")).Click();
    }

    public void GoToHomePage()
    {
        driver.FindElement(By.LinkText("home")).Click();
    }
}