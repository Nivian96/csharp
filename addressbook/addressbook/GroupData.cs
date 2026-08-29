namespace addressbook;

public class GroupData(string name, string header, string footer)
{
    private string name = name;
    private string header = header;
    private string footer = footer;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public string Header
    {
        get { return header; }
        set { header = value; }
    }

    public string Footer
    {
        get { return footer; }
        set { footer = value; }
    }
}
