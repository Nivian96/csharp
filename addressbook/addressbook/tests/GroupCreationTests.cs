namespace addressbook;

[TestFixture]
public class GroupCreationTests : TestBase
{
    [Test]
    public void GroupCreationTest()
    {
        GroupData group = new GroupData("new name", "new header", "new footer");
        
        app.Group.Create(group);
    }
    
    [Test]
    public void EmptyGroupCreationTest()
    {
        GroupData group = new GroupData("", "", "");
        
        app.Group.Create(group);
    }
}