using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace addressbook;

public class ApplicationManager
{
    private string baseURL;
    
    private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

    private ApplicationManager()
    {
        Driver = new FirefoxDriver();
        baseURL = "http://localhost";
        
        Auth = new LoginHelper(this);
        Navigation = new NavigationHelper(this, baseURL);
        Group = new GroupHelper(this);
        Contact = new ContactHelper(this);
    }

    ~ApplicationManager()
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

    public static ApplicationManager GetInstance()
    {
        if (! app.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            newInstance.Navigation.GoToStartPage();
            app.Value = newInstance;
        }
        return app.Value;
    }

    public IWebDriver Driver { get; }
    
    public LoginHelper Auth { get; }

    public NavigationHelper Navigation { get; }

    public GroupHelper Group { get; }
    
    public ContactHelper Contact { get; }
}