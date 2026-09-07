namespace addressbook;

[TestFixture]
public class GroupModificationTests : TestBase
{
    [Test]
    public void GroupModificationTest()
    {
        GroupData newData = new GroupData("new name", "new header", "new footer");

        app.Group.Modify(1, newData);
    }
}