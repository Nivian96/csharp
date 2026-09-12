namespace addressbook;

[TestFixture]
public class GroupRemovalTests : AuthTestBase
{
    [Test]
    public void GroupRemovalTest()
    {
        List<GroupData> oldGroups = app.Group.GetGroupList();
        
        app.Group.Remove(0);
        
        List<GroupData> newGroups = app.Group.GetGroupList();
        
        oldGroups.RemoveAt(0);
        Assert.AreEqual(oldGroups, newGroups);
    }
}