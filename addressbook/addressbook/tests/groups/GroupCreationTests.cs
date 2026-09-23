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
        
        Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

        List<GroupData> newGroups = app.Group.GetGroupList();
        oldGroups.Add(group);
        oldGroups.Sort();
        newGroups.Sort();
        Assert.AreEqual(oldGroups, newGroups);
    }
    
    [Test]
    public void EmptyGroupCreationTest()
    {
        GroupData group = new GroupData("", "", "");
        
        List<GroupData> oldGroups = app.Group.GetGroupList();
        
        app.Group.Create(group);
        
        Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        oldGroups.Add(group);
        oldGroups.Sort();
        newGroups.Sort();
        Assert.AreEqual(oldGroups, newGroups);
    }
}