namespace addressbook;

[TestFixture]
public class ContactCreationTests : TestBase
{
    [Test]
    public void ContactCreationTest()
    {
        ContactData contact = new ContactData("firstname", "lastname", "address", "mail");
        
        app.Contact.Create(contact);
    }
    
    [Test]
    public void EmptyContactCreationTest()
    {
        ContactData contact = new ContactData("", "", "", "");
        
        app.Contact.Create(contact);
    }
}