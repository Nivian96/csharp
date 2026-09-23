namespace addressbook;

[TestFixture]
public class GroupRemovalTests : AuthTestBase
{
    [Test]
    public void GroupRemovalTest()
    {
        GroupData group = new GroupData("name", "header", "footer");
        app.Group.EnsureGroupExists(group);
        
        List<GroupData> oldGroups = app.Group.GetGroupList();
        
        app.Group.Remove(0);
        
        Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        
        oldGroups.RemoveAt(0);
        Assert.AreEqual(oldGroups, newGroups);
    }
}