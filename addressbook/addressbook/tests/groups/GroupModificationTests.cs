namespace addressbook;

[TestFixture]
public class GroupModificationTests : AuthTestBase
{
    [Test]
    public void GroupModificationTest()
    {
        GroupData newData = new GroupData("new name", "new header", "new footer");
        
        List<GroupData> oldGroups = app.Group.GetGroupList();

        app.Group.Modify(0, newData);
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        oldGroups[0].Name = newData.Name;
        oldGroups.Sort();
        newGroups.Sort();
        Assert.AreEqual(oldGroups, newGroups);
    }
}