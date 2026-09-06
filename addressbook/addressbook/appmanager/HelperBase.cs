using OpenQA.Selenium;

namespace addressbook;

public class HelperBase
{
    protected IWebDriver driver;
    protected ApplicationManager manager;

    public HelperBase(ApplicationManager manager)
    {
        this.manager = manager;
        driver = manager.Driver;
    }
}