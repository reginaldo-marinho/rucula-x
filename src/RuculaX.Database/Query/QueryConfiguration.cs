namespace RuculaX.Database;

public interface IQueryConfiguration
{
    string Name { get;set; }
    string Options { get; set; }
    int RowNumber { get;set; }
}

public interface IQueryConfigurationInput : IQueryConfiguration
{
    bool Next { get;set; }
}

public sealed class QueryConfigurationInput : IQueryConfigurationInput
{
    public string Name { get;set; }
    public int RowNumber { get;set; } = 50;
    public string Options { get; set; }
    public bool Next { get;set; } = true;
}

public interface IQueryConfigurationOutput : IQueryConfiguration
{
    string Description { get;set; }
    string Data { get; set;}
}

public class QueryConfigurationOutput : IQueryConfigurationOutput
{
    public string Name { get; set;}
    public string Description {get; set;}
    public string Options { get; set; }
    public string Data { get; set;}
    public int RowNumber { get;set; } = 50;
}

