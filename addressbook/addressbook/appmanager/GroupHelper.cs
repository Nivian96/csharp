using OpenQA.Selenium;

namespace addressbook;

public class GroupHelper : HelperBase
{
    public GroupHelper(ApplicationManager manager) : base(manager)
    {
    }
    
    public GroupHelper Create(GroupData group)
    {
        manager.Navigation.GoToGroupsPage();
        
        InitNewGroupCreation();
        FillGroupForm(group);
        SubmitGroupCreation();
        ReturnToGroupsPage();
        return this;
    }
    
    public GroupHelper Modify(int i, GroupData newData)
    {
        manager.Navigation.GoToGroupsPage();
        
        SelectGroup(i);
        InitGroupModification();
        FillGroupForm(newData);
        SubmitGroupModification();
        ReturnToGroupsPage();
        return this;
    }

    public GroupHelper Remove(int i)
    {
        manager.Navigation.GoToGroupsPage();
        
        SelectGroup(i);
        RemoveGroup();
        ReturnToGroupsPage();
        return this;
    }
    
    public GroupHelper InitNewGroupCreation()
    {
        driver.FindElement(By.Name("new")).Click();
        return this;
    }
    
    public GroupHelper FillGroupForm(GroupData group)
    {
        Type(By.Name("group_name"), group.Name);
        Type(By.Name("group_header"), group.Header);
        Type(By.Name("group_footer"), group.Footer);
        return this;
    }

    public GroupHelper SubmitGroupCreation()
    {
        driver.FindElement(By.Name("submit")).Click();
        return this;
    }
    
    public GroupHelper ReturnToGroupsPage()
    {
        driver.FindElement(By.LinkText("group page")).Click();
        return this;
    }
    
    public GroupHelper RemoveGroup()
    {
        driver.FindElement(By.Name("delete")).Click();
        return this;
    }

    public GroupHelper SelectGroup(int index)
    {
        driver.FindElement(By.XPath($"//div[@id='content']/form/span[{index}]/input")).Click();
        return this;
    }
    
    private GroupHelper SubmitGroupModification()
    {
        driver.FindElement(By.Name("update")).Click();
        return this;
    }

    private GroupHelper InitGroupModification()
    {
        driver.FindElement(By.Name("edit")).Click();
        return this;
    }
}