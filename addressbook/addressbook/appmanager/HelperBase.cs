using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace addressbook;

public class HelperBase
{
    protected IWebDriver driver;
    protected ApplicationManager manager;
    
    private WebDriverWait wait;

    public HelperBase(ApplicationManager manager)
    {
        this.manager = manager;
        driver = manager.Driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    
    public void Type(By locator, string text)
    {
        var element = wait.Until(d => d.FindElement(locator));
    
        element.Click();
        element.Clear();
        element.SendKeys(text);
    }
    
    public bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}