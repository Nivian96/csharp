namespace addressbook;

[TestFixture]
public class GroupCreationTests : TestBase
{
    [Test]
    public void GroupCreationTest()
    {
        GoToHomePage();
        Login(new AccountData("admin", "secret"));
        GoToGroupsPage();
        InitNewGroupCreation();
        FillGroupForm(new GroupData("new name", "new header", "new footer"));
        SubmitGroupCreation();
        ReturnToGroupsPage();
    }
}