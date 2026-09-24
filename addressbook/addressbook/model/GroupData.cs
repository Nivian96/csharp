namespace addressbook;

public class GroupData(string name, string header = "", string footer = "") : IEquatable<GroupData>, IComparable<GroupData>
{
    public string Name { get; set; } = name;
    public string Header { get; set; } = header;
    public string Footer { get; set; } = footer;
    public string Id { get; set; }

    public bool Equals(GroupData other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
    
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        return Name == other.Name;
    }
    
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    
    public override string ToString()
    {
        return $"name = {Name}";
    }
    
    public int CompareTo(GroupData other)
    {
        if (ReferenceEquals(other, null))
        {
            return 1;
        }
        return Name.CompareTo(other.Name);
    }
}