namespace addressbook;

[TestFixture]
public class ContactRemovalTests : AuthTestBase
{
    [Test]
    public void ContactRemovalTest()
    {
        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        app.Contact.EnsureContactExists(contact);
        
        List<ContactData> oldContacts = app.Contact.GetContactList();
        
        app.Contact.Remove(0);
        
        Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());
        
        List<ContactData> newContacts = app.Contact.GetContactList();
        
        oldContacts.RemoveAt(0);
        Assert.AreEqual(oldContacts, newContacts);
    }
}