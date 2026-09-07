namespace addressbook;

public class ContactData(string first_name, string last_name, string address, string e_mail)
{
    private string first_name = first_name;
    private string last_name = last_name;
    private string address = address;
    private string e_mail = e_mail;

    public string FirstName
    {
        get { return first_name; }
        set { first_name = value; }
    }

    public string LastName
    {
        get { return last_name; }
        set { last_name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    
    public string EMail
    {
        get { return e_mail; }
        set { e_mail = value; }
    }
}