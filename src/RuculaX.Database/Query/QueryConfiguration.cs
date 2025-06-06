namespace RuculaX.Database.Query;

public interface IQueryConfiguration
{
    string Name { get;set; }
    string Options { get; set; }
    int RowNumber { get;set; }
    string Text { get;set; }
}

public interface IQueryConfigurationInput : IQueryConfiguration
{
    byte Page { get;set; }
}

public sealed class QueryConfigurationInput : IQueryConfigurationInput
{
    public string Name { get; set; }
    public int RowNumber { get; set; } = 50;
    public string Options { get; set; } = "{}";
    public byte Page { get; set; } = (byte)OptionPagination.Next;
    public string Text { get; set; } = "";
}

public class QueryConfigurationOutput
{
}
public class QueryConfigurationOutput<T> : QueryConfigurationOutput, IQueryConfiguration
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Options { get; set; }
    public List<T> Data { get; set; }
    public int RowNumber { get; set; } = 50;
    public string Text { get; set; } = "";
}
