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
        
        GroupData toBeRemoved = oldGroups[0];
        oldGroups.RemoveAt(0);
        Assert.AreEqual(oldGroups, newGroups);

        foreach (GroupData eachGroup in newGroups)
        {
            Assert.AreNotEqual(eachGroup.Id, toBeRemoved.Id);
        }
    }
}