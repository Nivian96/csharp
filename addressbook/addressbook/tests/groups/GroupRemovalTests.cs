namespace addressbook;

[TestFixture]
public class GroupRemovalTests : AuthTestBase
{
    [Test]
    public void GroupRemovalTest()
    {
        app.Group.Remove(1);
    }
}