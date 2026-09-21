namespace addressbook;

public class ContactModificationTests : AuthTestBase
{
    [Test]
    public void ContactModificationTest()
    {
        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        app.Contact.EnsureContactExists(contact);
        
        ContactData newData = new ContactData("new firstname", "new lastname", "new address", "new mail");
        app.Contact.Modify(newData);
    }
}