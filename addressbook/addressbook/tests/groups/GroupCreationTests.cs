namespace addressbook;

[TestFixture]
public class GroupCreationTests : AuthTestBase
{
    [Test]
    public void GroupCreationTest()
    {
        GroupData group = new GroupData("name", "header", "footer");
        
        List<GroupData> oldGroups = app.Group.GetGroupList();
        
        app.Group.Create(group);

        List<GroupData> newGroups = app.Group.GetGroupList();
        Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
    }
    
    [Test]
    public void EmptyGroupCreationTest()
    {
        GroupData group = new GroupData("", "", "");
        
        List<GroupData> oldGroups = app.Group.GetGroupList();
        
        app.Group.Create(group);
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
    }
}