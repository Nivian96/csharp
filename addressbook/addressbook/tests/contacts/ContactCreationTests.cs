namespace addressbook;

[TestFixture]
public class ContactCreationTests : AuthTestBase
{
    [Test]
    public void ContactCreationTest()
    {
        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        
        List<ContactData> oldContacts = app.Contact.GetContactList();
        
        app.Contact.Create(contact);
        
        Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

        List<ContactData> newContacts = app.Contact.GetContactList();
        oldContacts.Add(contact);
        oldContacts.Sort();
        newContacts.Sort();
        Assert.AreEqual(oldContacts, newContacts);
    }
    
    [Test]
    public void EmptyContactCreationTest()
    {
        ContactData contact = new ContactData("", "", "", "");
        
        List<ContactData> oldContacts = app.Contact.GetContactList();
        
        app.Contact.Create(contact);
        
        Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

        List<ContactData> newContacts = app.Contact.GetContactList();
        oldContacts.Add(contact);
        oldContacts.Sort();
        newContacts.Sort();
        Assert.AreEqual(oldContacts, newContacts);
    }
}