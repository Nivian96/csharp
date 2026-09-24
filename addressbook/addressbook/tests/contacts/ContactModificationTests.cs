namespace addressbook;

public class ContactModificationTests : AuthTestBase
{
    [Test]
    public void ContactModificationTest()
    {
        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        app.Contact.EnsureContactExists(contact);
        
        List<ContactData> oldContacts = app.Contact.GetContactList();
        
        ContactData newData = new ContactData("new firstname", "new lastname", "new address", "new mail");
        app.Contact.Modify(0, newData);
        
        Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());
        
        List<ContactData> newContacts = app.Contact.GetContactList();
        oldContacts[0].LastName = newData.LastName;
        oldContacts[0].FirstName = newData.FirstName;
        oldContacts.Sort();
        newContacts.Sort();
        Assert.AreEqual(oldContacts, newContacts);
    }
}