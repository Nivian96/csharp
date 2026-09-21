namespace addressbook;

[TestFixture]
public class ContactRemovalTests : AuthTestBase
{
    [Test]
    public void ContactRemovalTest()
    {
        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        app.Contact.EnsureContactExists(contact);
        
        app.Contact.Remove();
    }
}