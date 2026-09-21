namespace addressbook;

[TestFixture]
public class GroupModificationTests : AuthTestBase
{
    [Test]
    public void GroupModificationTest()
    {
        GroupData group = new GroupData("name", "header", "footer");
        app.Group.EnsureGroupExists(group);
        
        List<GroupData> oldGroups = app.Group.GetGroupList();
        
        GroupData newData = new GroupData("new name", "new header", "new footer");
        app.Group.Modify(0, newData);
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        oldGroups[0].Name = newData.Name;
        oldGroups.Sort();
        newGroups.Sort();
        Assert.AreEqual(oldGroups, newGroups);
    }
}