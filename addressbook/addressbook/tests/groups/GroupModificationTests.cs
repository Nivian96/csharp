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
        GroupData oldData = oldGroups[0];
        
        GroupData newData = new GroupData("new name", "new header", "new footer");
        app.Group.Modify(0, newData);
        
        Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        oldGroups[0].Name = newData.Name;
        oldGroups.Sort();
        newGroups.Sort();
        Assert.AreEqual(oldGroups, newGroups);

        foreach (GroupData eachGroup in newGroups)
        {
            if (eachGroup.Id == oldData.Id)
            {
                Assert.AreEqual(newData.Name, eachGroup.Name);
            }
        }
    }
}