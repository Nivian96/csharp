using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace addressbook;

public class ApplicationManager
{
    private string baseURL;

    public ApplicationManager()
    {
        Driver = new FirefoxDriver();
        baseURL = "http://localhost";
        
        Auth = new LoginHelper(this);
        Navigation = new NavigationHelper(this, baseURL);
        Group = new GroupHelper(this);
        Contact = new ContactHelper(this);
    }

    public IWebDriver Driver { get; }

    public void Stop()
    {
        try
        {
            Driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
    }
    
    public LoginHelper Auth { get; }

    public NavigationHelper Navigation { get; }

    public GroupHelper Group { get; }
    
    public ContactHelper Contact { get; }
}