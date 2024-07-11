namespace RuculaX.Database;

public interface IQueryConfigurationInput
{
    /// <summary>
    /// Pagination Component Query 
    /// </summary>
    string Name { get;set; }
    string Options { get; set; }
    bool Next { get;set; }
}

public sealed class QueryConfigurationInput : IQueryConfigurationInput
{
    public string Name { get;set; }
    public string Options { get; set; }
    public bool Next { get;set; } = true;
}

public interface IQueryConfigurationOutput
{
    string Name { get;set; }
    string Description { get;set; }
    string Options { get; set; }
    string Data { get; set;}

}

public class QueryConfigurationOutput : IQueryConfigurationOutput
{
    public string Name { get; set;}
    public string Description {get; set;}
    public string Options { get; set; }
    public string Data { get; set;}
}

