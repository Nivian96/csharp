using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace addressbook;

public class LoginHelper : HelperBase
{
    public LoginHelper(ApplicationManager manager) : base(manager)
    {
    }
    
    public void Login(AccountData account)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(By.Name("user"))).Click();
        driver.FindElement(By.Name("user")).Clear();
        driver.FindElement(By.Name("user")).SendKeys(account.Username);
        driver.FindElement(By.Name("pass")).Click();
        driver.FindElement(By.Name("pass")).Clear();
        driver.FindElement(By.Name("pass")).SendKeys(account.Password);
        driver.FindElement(By.XPath("//input[@value='Login']")).Click();
    }
}