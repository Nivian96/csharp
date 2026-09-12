namespace addressbook;

public record GroupData(string name, string header = "", string footer = "")
{
    public string Name { get; set; } = name;
    public string Header { get; set; } = header;
    public string Footer { get; set; } = footer;
}