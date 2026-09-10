namespace addressbook;

public class ContactModificationTests : AuthTestBase
{
    [Test]
    public void ContactModificationTest()
    {
        ContactData newData = new ContactData("new firstname", "new lastname", "new address", "new mail");

        app.Contact.Modify(newData);
    }
}