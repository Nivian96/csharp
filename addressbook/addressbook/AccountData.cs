namespace addressbook;

public class AccountData(string username, string password)
{
    private string username = username;
    private string password = password;

    public string  Username
    {
        get { return username; }
        set { username = value; }
    }
    
    public string  Password 
    {
        get { return password; }
        set { password = value; }
    }
}