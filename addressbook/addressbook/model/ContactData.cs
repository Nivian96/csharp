namespace addressbook;

public class ContactData(string first_name, string last_name, string address = "", string e_mail = ""): IEquatable<ContactData>, IComparable<ContactData>
{
    public string FirstName { get; set; } = first_name;

    public string LastName { get; set; } = last_name;

    public string Address { get; set; } = address;

    public string EMail { get; set; } = e_mail;
    
    public bool Equals(ContactData other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return FirstName == other.FirstName && LastName == other.LastName;
    }
    
    public override int GetHashCode()
    {
        return FirstName.GetHashCode() ^ LastName.GetHashCode();
    }
    
    public override string ToString()
    {
        return $"first_name = {FirstName}, last_name = {LastName}";
    }
    
    public int CompareTo(ContactData other)
    {
        if (ReferenceEquals(other, null))
        {
            return 1;
        }

        int cmp = LastName.CompareTo(other.LastName);
        if (cmp != 0)
        {
            return cmp;
        }

        return FirstName.CompareTo(other.FirstName);
    }
}